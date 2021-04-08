using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.GameEngine
{
    static class ImageEditor
    {
        //public static Image img = Image.FromFile(Helper.GetPath("Textures\\Sky.png"));
        //public static Image sky = new Bitmap(1024, 1024, PixelFormat.Format32bppPArgb);
        //public static Graphics e;
        //static Point middle = new Point(img.Width / 2, img.Height / 2);
        //static int offsetPerMove = 1;
        //static float offsetAngle = (float)Math.PI /40;

        //public static void GetPartOfImage(Graphics e)
        //{
        //    e.TranslateTransform(middle.X, middle.Y);
        //}

        //public static void RotateImage(float rotate)
        //{
           

        //    offsetAngle += rotate;
        //    e =  Graphics.FromImage(sky);
        //    e.SmoothingMode = SmoothingMode.AntiAlias;


        //    Matrix matrix = new Matrix();
        //    matrix = e.Transform;

        //    matrix.RotateAt(offsetAngle, middle);
        //    matrix.Translate(-middle.X+256, -middle.Y+256);
        //    e.Transform = matrix;

        //    e.DrawImage(img, PointF.Empty);
        //}
    }
}
