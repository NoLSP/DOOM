using Algebra;
using System;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Doom3D.Algebra
{
    public class Segment
    {
        public double X1;
        public double X2;
        public double Y1;
        public double Y2;

        public Segment(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }

        public Segment(PointF point1, PointF point2)
        {
            X1 = point1.X;
            X2 = point2.X;
            Y1 = point1.Y;
            Y2 = point2.Y;
        }

        public bool IsPointOnSegment(PointF point)
        {
            var K1 = (point.X - X1) / (X2 - X1);
            var K2 = (point.Y - Y1) / (Y2 - Y1);
            return K1 == K2 && K1 >= 0 && K1 <= 1;
        }

        //public PointF GetIntersectionPoint(Line line)
        //{
        //    var k1 = -line.A * X1 - line.B * Y1 - line.C; //числитель
        //    var k2 = -line.A * X1 + line.A * X2 - line.B * Y1 + line.B * Y2;//знаменатель
        //    var K = k1 / k2;
        //    if (!(K >= 0 && K <= 1)) return PointF.Empty;
        //    double X = (1 - K) * X1 + K * X2;
        //    double Y = (1 - K) * Y1 + K * Y2;
        //    return new PointF((float)X, (float)Y);
        //}

        public PointF GetIntersectionPoint(Segment s)
        {
            throw new Exception();
        }
    }
}
