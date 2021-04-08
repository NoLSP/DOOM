using Doom3D.Objects;
using Doom3D.Objects.Mobs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace Doom3D.Constants
{
    public class GameState
    {
        public Map Map { get; private set; }
        public List<Mob> Monsters { get; private set; }
        public Player Player { get; private set; }

        public GameState(Map map, List<Mob> mobs, Player player)
        {
            Map = map;
            Monsters = mobs;
            Player = player;
        }
    }
}
