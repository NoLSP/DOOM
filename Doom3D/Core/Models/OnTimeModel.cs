using Doom3D.Constants;
using Doom3D.Core.GameEngine;
using Doom3D.Core.Models;
using Doom3D.Objects;
using Doom3D.Objects.Mobs;
using Game.Objects.Mobs;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Doom3D.Core
{
    public class OnTimeModel : GameModel
    {
        public OnTimeModel(Screen screen, GameField game)
        {
            this.screen = screen;
            Map = new Map(game.RawMap);
            Player = new Player(game.PlayerLocation, this);
            
            InitMonsters(game);
            InitVisibleWalls(game);
            

        }

        private void InitVisibleWalls(GameField game)
        {
            //VisibleWalls = new List<Wall>();

        }

        private void InitMonsters(GameField game)
        {
            Monsters = new List<Mob>();
            foreach (var mob in game.Mobs)
            {
                switch (mob.Item2)//добавить разных мобов
                {
                    case Values.ImpID:
                        Monsters.Add(new Imp(mob.Item1));
                        break;
                }
            }
        }

        public override void Start()
        {
            //здесь идет тестирование
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 20;
            timer.Tick += Tick;
            timer.Start();

            //var thread = new Thread(new ThreadStart(Draw));
            //thread.Start();
        }

        private void Tick(object sender, System.EventArgs e)
        {
            Player.Update();
            screen.ChangeGameWindowImage(Engine.GetFrame(new GameState(Map, Monsters, Player)));
        }

        private void Draw()
        {
            //Создаем GameState текущей игры
            //Через движок отправляем картинку экрану
            while (true)
            {
                //GameState game;
                //lock (Map)
                //{
                //    lock (Monsters)
                //    {
                //        lock (Player)
                //        {
                //            game = new GameState(Map, Monsters, Player);
                //        }
                //    }
                //}
                Player.Update();
                screen.ChangeGameWindowImage(Engine.GetFrame(new GameState(Map, Monsters, Player)));
                //Thread.Sleep(10);
            }
            //screen.ChangeGameWindowImage(Engine.GetFrame(new GameState(Map, Monsters, Player)));
        }
    }
}
