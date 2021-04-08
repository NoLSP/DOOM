using Doom3D.Objects;
using System;
using System.Drawing;

namespace Algebra
{
  public  class Vector
    {
        public float X;
        public float Y;
        public float Length { get => (float)Math.Sqrt(X * X + Y * Y); }

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector(Entity point1, Entity point2)
        {
            X = point2.X - point1.X;
            Y = point2.Y - point1.Y;
        }

        public Vector(Entity point1, PointF point2)
        {
            X = point2.X - point1.X;
            Y = point2.Y - point1.Y;
        }

        public Vector(PointF start, double angle)
        {
            X = (float)(start.X + Math.Cos(angle));
            Y = (float)(start.Y + Math.Sin(angle));
        }

        public Vector Normalize()
        {
            X = X / Length;
            Y = Y / Length;
            return this;
        }

        public static float GetLength(PointF p1, PointF p2)
        {
            return (float)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
    }
}
