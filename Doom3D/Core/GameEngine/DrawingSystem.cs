using Doom3D.Constants;
using Doom3D.Objects.Mobs;
using Algebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doom3D.Objects;
using Doom3D.Objects.Buildings;
using Doom3D.Algebra;
using System.Windows.Forms;

namespace Doom3D.Core.GameEngine
{
	/*!
	/brief Класс, реализующий основную логику отрисовки игровых обектов на экран
	/detailed Реализует весьма сложную логику, так сразу все не расскажешь 
	*/
    static class DrawingSystem
    {
        static Size gameWindowSize = Values.GameWindowSize;
        static Bitmap GameBitmap = new Bitmap(gameWindowSize.Width, gameWindowSize.Height);
        static Graphics GameGarphics = Graphics.FromImage(GameBitmap);

	/*!
	Возвращает готовое изображение экрану
	@param game - Состояние игрового поля
	@return Image - готовое изображение
	*/
        public static Image GetFrame(GameState game)
        {
            var deepMap = new List<DeepMapItem>();
            GameGarphics.Clear(Color.White);

            for (int i = 0; i < gameWindowSize.Width; i++)
            {
                var angle = game.Player.Direction - game.Player.ViewAngle / 2 +
                           game.Player.ViewAngle * i / gameWindowSize.Width;//куда смотрим)
                var viewRay = new Ray(game.Player.Location, angle);
                
                var dmItem = GetObstacle(game.Player, game.Map, viewRay, angle, i);
                deepMap.Add(dmItem);

                //var monsters = mobs
                //    .Where(Monster => Math.Abs(Monster.X * ViewLine.A + Monster.Y * ViewLine.B + ViewLine.C) <= 0.4);
                //foreach (var Monster in monsters)
                //    if (!monsterPoints.ContainsKey(Monster))
                //    {
                //        monsterPoints.Add(Monster, i);
                //        deepMap.Add(Tuple.Create(new Vector(Monster, game.Player).Length, i,
                //                         DataBase.MobsTextures[Monster.TextureIDs[Monster.ActualTexture]], angle));
                //    }
            }
            DrawFrame(game.Player, deepMap);
            //if (game.shot)
            //{
            //    var shot = DataBase.WeaponsTexture["Shot"];
            //    GameGarphics.DrawImage(shot, new Point((gameWindowSize.Width - shot.Width) / 2 + 15, gameWindowSize.Height - shot.Height - 64));
            //    game.shot = false;
            //}
            //var weapon = DataBase.WeaponsTextures[game.Player.WeaponId];
            //GameGarphics.DrawImage(weapon, new Point((gameWindowSize.Width - weapon.Width) / 2, gameWindowSize.Height - weapon.Height));


            return GameBitmap;
        }

	/*!
	Вспомогательный метод, возвращающий карту глубин объектов игрового поля

	@param player - игрок
	@param map - карта
	@param vieRay - лучь обзора
	@param angle - угол
	@param columnNumber - номер столбца экрана
	@return DeepMap - карта глубин
	*/
        private static DeepMapItem GetObstacle(Player player, Map map, Ray viewRay, double angle, int columnNumber)
        {
            var walls = map.Walls.Select(w => Tuple.Create( w, w.GetIntersection(viewRay)))
                .Where(t => t.Item2 != PointF.Empty);//Нашли стены, с которыми есть точка пересечения
            var nearestWall = walls.OrderBy(w => Vector.GetLength(w.Item2, player.Location)).FirstOrDefault();

            var point = nearestWall.Item2;
            var distance = Vector.GetLength(player.Location, point);
            //var columnHeigth = (int)(gameWindowSize.Height / (distance * Math.Cos(angle - player.Direction)));

            //var hitX = point.X - Math.Floor(point.X);
            //var hitY = point.Y - Math.Floor(point.Y);
            ////Здесь в дальнейшем пропишем функцию отрисовки произвольно ориентированных стен
            //var XtexCoordinate = hitX == 0 ? (int)Math.Truncate(hitY * 64) : (int)Math.Truncate(hitX * 64);// 64 -размер текстуры

            var hitX = point.X - Math.Floor(point.X + 0.5);
            var hitY = point.Y - Math.Floor(point.Y + 0.5);
            var XtexCoordinate = (int)Math.Truncate(hitX * 64);// 64 -размер текстуры
            if (Math.Abs(hitY) > Math.Abs(hitX))
                XtexCoordinate = (int)Math.Truncate(hitY * 64);
            if (XtexCoordinate < 0) XtexCoordinate += 64;

            var texture = DataBase.WallsTextures[nearestWall.Item1.TextureID][XtexCoordinate];
            return new DeepMapItem(distance, columnNumber, texture, angle);
        }

        private static void DrawFrame(Player player, List<DeepMapItem> deepMap)
        {
            //var floor = DataBase.GetFloorTexture();
            //GameGarphics.DrawImage(ImageEditor.sky, PointF.Empty);
            //GameGarphics.DrawImage(floor, new Point(0, 256));


            foreach (var obj in deepMap.OrderByDescending(item => item.Distance))//сортируем подальности(сначала рисуем дальние)
            {
                if (obj.Texture.Width == 1)
                {
                    var wallHeight = (int)(gameWindowSize.Height / (obj.Distance * Math.Cos(obj.Angle - player.Direction)));
                    var scale = (double)wallHeight / obj.Texture.Height;
                    GameGarphics.DrawImage(obj.Texture, new Rectangle(obj.ColumnNumber, (gameWindowSize.Height - wallHeight) / 2, 1, wallHeight),
                                    new Rectangle(0, 0, 1, 64), GraphicsUnit.Pixel);
                }
                else
                {
                    var monsterHeight = (int)(obj.Texture.Height * 2.5 / obj.Distance);
                    var scale = (double)monsterHeight / obj.Texture.Height;
                    GameGarphics.DrawImage(obj.Texture, new Rectangle(obj.ColumnNumber, (gameWindowSize.Height - monsterHeight) / 2,
                        (int)(obj.Texture.Width * scale), monsterHeight), new Rectangle(0, 0, 124, 128), GraphicsUnit.Pixel);
                    //128 на 134 - размер текстуры моба
                }
            }
            PaintHealth(player);

        }

        private static void PaintHealth(Player player)
        {
            GameGarphics.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(77, 467, 106, 26));
            GameGarphics.FillRectangle(Brushes.Red, new Rectangle(80, 470, (int)player.Health, 20));
        }
    }
}
