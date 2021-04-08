using Algebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Doom3D.Algebra
{
    public class Ray//Луч
    {
        //Луч задается системой из двух уравнений {x = startX + K * A ; y = startY + K * b}, где a,b - направляющий вектор
        //Точка лежит на луче, если K в обоих уравнениях >= 0
        //Если a=0, то x должен быть равен startX
        //Если b=0, то y должен быть равен startY

        private PointF startPoint;
        private double direction;
        private double sinDirection;
        private double cosDirection;
        private double T;//праметр

        public Ray(PointF startPoint, double direction)
        {
            this.startPoint = startPoint;
            this.direction = direction;
            cosDirection = Math.Cos(direction);
            sinDirection = Math.Sin(direction);
        }

        public bool isIntersect(Segment segment)
        {
            //Метод Крамера
            var d = (segment.X2 - segment.X1) * sinDirection - (segment.Y2 - segment.Y1) * cosDirection;
            var d1 = (segment.X2 - segment.X1) * (segment.Y1 - startPoint.Y) - (segment.X1 - startPoint.X) * (segment.Y2 - segment.Y1);
            var d2 = cosDirection * (segment.Y1 - startPoint.Y) - sinDirection * (segment.X1 - startPoint.X);

            if (d == 0) return false;
            T = d1 / d;
            var K = d2 / d;

            return K >= 0 && K <= 1 && T >= 0;
        }

        public bool IsPointOnRay(PointF point)
        {
            if(Math.Abs(cosDirection - 0) < 1e-7)
            {
                var t = (point.Y - startPoint.Y) / sinDirection;
                return point.X == startPoint.X && t >= 0;
            }
            if (Math.Abs(sinDirection - 0) < 1e-7)
            {
                var t = (point.X - startPoint.X) / cosDirection;
                return point.Y == startPoint.Y && t >= 0;
            }
            var t1 = (point.X - startPoint.X) / cosDirection;
            var t2 = (point.Y - startPoint.Y) / sinDirection;
            return Math.Abs(t1 - t2) < 1e-7 && t1 >= 0;
        }

        /// <summary>
        /// Возвращает точку пересечения с отрезком.
        /// </summary>
        /// <param name="s - отрезок"></param>
        /// <returns></returns>
        public PointF GetIntersectionPoint(Segment s)
        {
            if (!isIntersect(s)) return PointF.Empty;
            return new PointF((float)(startPoint.X + T * cosDirection), (float)(startPoint.Y + T * sinDirection));
        }
    }
}
