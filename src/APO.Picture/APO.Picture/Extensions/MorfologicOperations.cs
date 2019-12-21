using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = OpenCvSharp.Point;
using Size = OpenCvSharp.Size;

namespace APO.Picture.Extensions
{
    public class MorfologicOperations
    {
        public static Bitmap Erosion(Bitmap image, int k, int i)
        {
            MorphShapes elementType;
            int karnelSize=3;
            //int ii;

            if (k == 0)
            {
                elementType = MorphShapes.Rect;
            }
            else
            {
                elementType = MorphShapes.Cross;
            }

            //switch (i)
            //{
            //    case 1:
            //        ii = 1;
            //        break;
            //    case 2:
            //        ii = 2;
            //        break;
            //    case 3:
            //        ii = 5;
            //        break;
            //    default:
            //        ii = 1;
            //        break;
            //}

            Size size = new Size(2 * karnelSize + 1, 2 * karnelSize + 1);
            Point point = new Point(karnelSize, karnelSize);

            Mat element = Cv2.GetStructuringElement(elementType, size, point);

            Mat srcImage = OpenCvSharp.Extensions.BitmapConverter.ToMat(image);
            Mat destImage = new Mat(srcImage.Width, srcImage.Height, MatType.CV_8U);

            destImage = srcImage.Clone();

            Cv2.Erode(srcImage, destImage, element, null, i);

            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(destImage);
        }
    }
}
