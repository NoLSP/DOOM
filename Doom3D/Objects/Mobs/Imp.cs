using Algebra;
using Doom3D;
using Doom3D.Constants;
using Doom3D.Objects;
using Doom3D.Objects.Mobs;
using System.Collections.Generic;
using System.Drawing;

namespace Game.Objects.Mobs
{
    public class Imp :  Mob
    {
        public string[] TextureId;
        public int actualTextureId = 0;
        public double Health = Values.ImpDefaultHealth;
        public bool IsDead { get => Health <= 0; }
        public int recharge = 0;

        public Imp(PointF location)
        {
            X = location.X;
            Y = location.Y;
        }

        public void Hurt()
        {
            if (IsDead) return;
            Health -= 25;//еще задать тип оружия
            if (Health <= 50 && Health > 0) actualTextureId = 1;
            if (Health <= 0)
            {
                actualTextureId = 2;
            }
        }

        public void Update(Player player, Map map)//Здесь прописать логику движения монстра
        {
            
        }

        private PointF GetPathToPlayer(Player player, Map map)//возвращает центр клетки карты, в которую нужно сместиться
        {
            return PointF.Empty;
        }
    }
}