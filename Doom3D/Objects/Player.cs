using Doom3D.Constants;
using Doom3D.Core.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Doom3D.Objects
{
    public class Player : Entity
    {
        public double Direction { get; private set; }
        public double ViewAngle { get; private set; }// угол обзора персонажа
        public double Health  { get; private set; }
        public PointF Location { get => new PointF(X, Y); }
        public bool IsDead { get => Health <= 0; }
        public string WeaponId = "1";
        private GameModel gameModel;

        public bool goAhead = false;
        public bool goBackward = false;
        public bool goLeft = false;
        public bool goRight = false;
        public bool camRotateLeft = false;
        public bool camRotateRight = false;
        public double offsetValue = Values.PLayerDefaultMovingOffset;
        public double offsetAngle = Values.PLayerDefaultAngleOffset;

        public void Init(GameModel model)
        {
            Direction = Values.PLayerDefaultDirection;
            Health = Values.PLayerDefaultHealth;
            ViewAngle = Values.PLayerViewAngle;
            gameModel = model;
        }

        public Player(float x, float y, GameModel model)
        {
            X = x;
            Y = y;
            Init(model);
        }

        public Player(PointF p, GameModel model)
        {
            X = p.X;
            Y = p.Y;
            Init(model);
        }

        public void Hurt(int damage)
        {
            Health -= damage;
        }
        
        public void Update()
        {
            Move();
        }

        private void Move()
        {
            bool isPlayerMoving = false;
            bool isCamRotate = false;//Эти два флага, для того, чтобы методы MovePlayer и RotateCamera не вызывались ВСЕГДА одновременно
            float deltaX = 0;
            float deltaY = 0;
            if (goAhead)
            {
                deltaX = (float)(offsetValue * Math.Cos(Direction));
                deltaY = (float)(offsetValue * Math.Sin(Direction));
                isPlayerMoving = true;
            }
            if (goBackward)
            {
                deltaX = (float)(offsetValue * Math.Cos(Direction + Math.PI));
                deltaY = (float)(offsetValue * Math.Sin(Direction + Math.PI));
                isPlayerMoving = true;
            }
            if (goLeft)
            {
                deltaX = (float)(offsetValue * Math.Cos(Direction - Math.PI / 2));
                deltaY = (float)(offsetValue * Math.Sin(Direction - Math.PI / 2));
                isPlayerMoving = true;
            }
            if (goRight)
            {
                deltaX = (float)(offsetValue * Math.Cos(Direction + Math.PI / 2));
                deltaY = (float)(offsetValue * Math.Sin(Direction + Math.PI / 2));
                isPlayerMoving = true;
            }
            if (camRotateLeft)
            {
                offsetAngle = Values.PLayerDefaultAngleOffset * (-1);
                isCamRotate = true;
            }
            if (camRotateRight)
            {
                offsetAngle = Values.PLayerDefaultAngleOffset;
                isCamRotate = true;
            }
            if (isPlayerMoving) ChangeLocation(deltaX, deltaY);
            if (isCamRotate) ChangeDirection(offsetAngle);
        }

        internal void ChangeLocation(float deltaX, float deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }

        internal void ChangeDirection(double offsetAngle)
        {
            Direction += offsetAngle;
        }
    }
}