using System;
using System.Drawing;

namespace Doom3D.Constants
{
    public static class Values
    {
        public const int ImpDefaultHealth = 100;
        public const int PLayerDefaultHealth = 100;
        public const double PLayerDefaultDirection = -Math.PI;
        public const double PLayerViewAngle = Math.PI / 3;
        public const double PLayerDefaultMovingOffset= 0.1;//Значение смещения координат игрока за такт
        public const double PLayerDefaultAngleOffset = Math.PI / 40;//Значение поворота камеры за такт
        public const string ImpID = "1";
        public const float SkyOffsetAngle = (float)Math.PI / 40;//угол, на который поворачивается небо
        public static  PointF FisrtMapPlayer {get => new PointF(3, 12); }
        public static Size GameWindowSize { get => new Size(512, 512); }
    }
}
