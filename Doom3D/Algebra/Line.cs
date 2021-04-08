using System;
using System.Drawing;

namespace Algebra
{
    public class Line
    {
        public double A;
        public double B;
        public double C;


        ///<summary>
        ///Задает уравнение по значениям коэффициентов A,B,C
        ///</summary>
        public Line(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        ///<summary>
        ///Задает уравнение по начальной точке и углу
        ///</summary>
        public Line(PointF pointZero, double angle)
        {
            var x1 = pointZero.X + Math.Cos(angle);
            var y1 = pointZero.Y + Math.Sin(angle);
            A = y1 - pointZero.Y;
            B = -(x1 - pointZero.X);
            C = pointZero.Y * x1 - pointZero.X * y1;
        }

        ///<summary>
        ///Задает уравнение по начальной точке и углу
        ///</summary>
        public Line(float pointX, float pointY, double angle)
        {
            var x1 = pointX + Math.Cos(angle);
            var y1 = pointY + Math.Sin(angle);
            A = y1 - pointY;
            B = -(x1 - pointX);
            C = pointY * x1 - pointX * y1;
        }

        ///<summary>
        ///Задает уравнение по двум точкам
        ///</summary>
        public Line(double x1, double y1, double x2, double y2)
        {
            A = y2 - y1;
            B = x1 - x2;
            C = y1 * x2 - x1 * y2;
        }

        ///<summary>
        ///Возвращает значение, полученное при подставлении точки в уравнение прямой. 
        ///Если 0 - точка лежит на прямой.
        ///</summary>
        public double GetValue(float x, float y)
        {
            return A * x + B * y + C;
        }

        public PointF GetIntersection(Line line)
        {
            if (Math.Abs(A / line.A - B / line.B) < 1e-9) return PointF.Empty;//Не пересекаются
            var x = (B * line.C - C * line.B) / (A * line.B - B * line.A);
            var y = (C * line.A - A * line.C) / (A * line.B - line.A * B);
            return new PointF((float)x, (float) y);
        }
    }
}
