using Algebra;
using Doom3D.Algebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doom3D.Objects.Buildings
{
    public class Wall
    {
        public string TextureID;

        private Segment wall;
        private PointF point1;
        private PointF point2;

        public Wall(PointF pointF1, PointF pointF2, string textureID)
        {
            point1 = pointF1;
            point2 = pointF2;
            TextureID = textureID;
            wall = new Segment(point1, point2);
        }

        /// <summary>
        /// Возвращает точку пересечения стены с лучом
        /// </summary>
        public PointF GetIntersection(Ray r) => r.GetIntersectionPoint(wall);
    }
}
