using Doom3D.Constants;
using Doom3D.Core.Models;
using Doom3D.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doom3D.Core
{
    partial class Controller
    {
        //Этот класс - контроллер движения игрока
        //Он имеет прямой доступ к игроку, чтобы движения обрабатывались максимально качественно
        public void HandleKey(Keys e, bool isDown)
        {
            var player = gameModel.GetPlayer();

            //switch (e)//Цифры от 1 до 3 - виды оружия
            //{
            //    case Keys.D1:
            //        gameModel.Player.WeaponId = "1";
            //        break;
            //    case Keys.D2:
            //        gameModel.Player.WeaponId = "2";
            //        break;
            //    case Keys.D3:
            //        gameModel.Player.WeaponId = "3";
            //        break;
            //}

            switch (e)
            {
                case Keys.Space:
                    //todo
                    break;
                case Keys.W:
                    player.goAhead = isDown;
                    break;
                case Keys.S:
                    player.goBackward = isDown;
                    break;
                case Keys.A:
                    player.goLeft = isDown;
                    break;
                case Keys.D:
                    player.goRight = isDown;
                    break;
                case Keys.Left:
                    player.camRotateLeft = isDown;
                    break;
                case Keys.Right:
                    player.camRotateRight = isDown;
                    break;
            }            
        }
    }
}
