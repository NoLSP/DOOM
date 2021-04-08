using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doom3D.Constants
{
    public class DeepMapItem
    {
        public float Distance { get; private set; }
        public int ColumnNumber { get; private set; }
        public Image Texture { get; private set; }
        public double Angle { get; private set; } //Используется для удаления дисторсии

        public DeepMapItem(float distance, int columnNumber, Image texture, double angle)
        {
            Distance = distance;
            ColumnNumber = columnNumber;
            Texture = texture;
            Angle = angle;
        }
    }
}
