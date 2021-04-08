using Doom3D.Constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Doom3D.Core
{
    public static class DataBase
    {
        public static List<LevelCard> LevelCards { get; private set; }

        /// <summary>
        /// По ID и номеру столбца возвращает столбец текстуры
        /// </summary>
        public static Dictionary<string, Dictionary<int, Image>> WallsTextures { get; private set; }

        public static Dictionary<string, Image> MobsTextures { get; private set; }//тут просто возвращает картинку по ID
        public static Dictionary<string, Image> WeaponsTextures { get; private set; }//0 - огонь от выстрела

        internal static void Initialize()
        {
            SetLevelCards();
            SetTextures();
        }

        public static GameField GetGameField(string path)
        {
            var lines = File.ReadAllLines(path);
            PointF playerLocation= new PointF(int.Parse(lines[0].Split(',')[0]), int.Parse(lines[0].Split(',')[1]));
            List<Tuple<PointF, string>> mobs = new List<Tuple<PointF, string>>();
            var MobsCount = int.Parse(lines[1]);
            for(int i = 2; i < 2+MobsCount; i++)
            {
                PointF mobLocation = new PointF(int.Parse(lines[i].Split(',')[0]), int.Parse(lines[i].Split(',')[1]));
                mobs.Add(Tuple.Create(mobLocation, lines[i].Split(',')[2]));
            }
            lines = lines.Skip(1 + MobsCount + 1).ToArray();
            var rawMap = lines;
            return new GameField(playerLocation, mobs, rawMap);
        }

        public static void SetLevelCards()
        {
            LevelCards = new List<LevelCard>();
            foreach (var file in Directory.GetFiles(Paths.LevelsDescriptionsFolder))
            {
                var lines = File.ReadAllLines(file);
                var levelName = lines[0];
                var levelDescr = lines[1];
                //Потом добавить миниатюру
                LevelCards.Add(new LevelCard(levelName, levelDescr));
            }
        }

        public static void SetTextures()
        {
            WallsTextures = new Dictionary<string, Dictionary<int, Image>>();
            MobsTextures = new Dictionary<string, Image>();
            WeaponsTextures = new Dictionary<string, Image>();

            foreach (var file in Directory.GetFiles(Paths.WallsTexturesFolder))
            {
                if (Path.GetExtension(file) == ".bmp")
                {
                    var texture = Image.FromFile(file);
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    WallsTextures.Add(fileName, new Dictionary<int, Image>());
                    for (int i = 0; i < texture.Width; i++)
                    {
                        var bmp = new Bitmap(1, 64);//64px - высота текстуры; да, это плохо
                        var g = Graphics.FromImage(bmp);
                        g.DrawImage(texture, new Rectangle(0, 0, 1, texture.Height), new Rectangle(i, 0, 1, texture.Height), GraphicsUnit.Pixel);
                        WallsTextures[fileName].Add(i, bmp);
                    }
                }
            }

            foreach (var filePath in Directory.GetFiles(Paths.MobsTexturesFolder))
            {
                if (Path.GetExtension(filePath) == ".png")
                {
                    var fileName = Path.GetFileNameWithoutExtension(filePath);
                    MobsTextures.Add(fileName, Image.FromFile(filePath));
                }
            }

            foreach (var filePath in Directory.GetFiles(Paths.WeaponsTexturesFolder))
            {
                if (Path.GetExtension(filePath) == ".png")
                {
                    var fileName = Path.GetFileNameWithoutExtension(filePath);
                    WeaponsTextures.Add(fileName, Image.FromFile(filePath));
                }
            }
        }

        //public static Image GetFloorTexture()
        //{
        //    //todo
        //}
    }
}
