using Doom3D.Objects;
using Doom3D.Objects.Buildings;
using Doom3D.Objects.Mobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doom3D.Core.Models
{
    public abstract class GameModel
    {
        //Заполнить методами, которые обязательно должна иметь модель
        protected Map Map { get; set; }
        protected List<Mob> Monsters { get; set; }
        protected Player Player { get; set; }
        //protected List<Wall> VisibleWalls { get; set; }
        protected Screen screen;


        public abstract void Start();

        public Player GetPlayer() =>  Player;
    }
}
