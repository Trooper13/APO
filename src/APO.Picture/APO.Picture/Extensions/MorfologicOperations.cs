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

            if (k == 0)
            {
                elementType = MorphShapes.Cross;
            }
            else
            {
                elementType = MorphShapes.Rect;
            }

            Size size = new Size(2 * karnelSize + 1, 2 * karnelSize + 1);
            Point point = new Point(karnelSize, karnelSize);

            Mat element = Cv2.GetStructuringElement(elementType, size, point);

            Mat srcImage = OpenCvSharp.Extensions.BitmapConverter.ToMat(image);
            Mat destImage = new Mat(srcImage.Width, srcImage.Height, MatType.CV_8U);

            destImage = srcImage.Clone();

            Cv2.Erode(srcImage, destImage, element, null, i);

            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(destImage);
        }

        public static Bitmap Dilate(Bitmap image, int k, int i)
        {
            MorphShapes elementType;
            int karnelSize = 3;

            if (k == 0)
            {
                elementType = MorphShapes.Cross;
            }
            else
            {
                elementType = MorphShapes.Rect;
            }

            Size size = new Size(2 * karnelSize + 1, 2 * karnelSize + 1);
            Point point = new Point(karnelSize, karnelSize);

            Mat element = Cv2.GetStructuringElement(elementType, size, point);

            Mat srcImage = OpenCvSharp.Extensions.BitmapConverter.ToMat(image);
            Mat destImage = new Mat(srcImage.Width, srcImage.Height, MatType.CV_8U);

            destImage = srcImage.Clone();

            Cv2.Dilate(srcImage, destImage, element, null, i);

            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(destImage);
        }

        public static Bitmap Open(Bitmap image, int k)
        {
            MorphShapes elementType;
            int karnelSize = 3;

            if (k == 0)
            {
                elementType = MorphShapes.Cross;
            }
            else
            {
                elementType = MorphShapes.Rect;
            }

            Size size = new Size(2 * karnelSize + 1, 2 * karnelSize + 1);
            Point point = new Point(karnelSize, karnelSize);
            Point anchor = new Point(-1, -1);

            Mat element = Cv2.GetStructuringElement(elementType, size, point);

            Mat srcImage = OpenCvSharp.Extensions.BitmapConverter.ToMat(image);
            Mat destImage = new Mat(srcImage.Width, srcImage.Height, MatType.CV_8U);

            destImage = srcImage.Clone();

            Cv2.MorphologyEx(srcImage, destImage, MorphTypes.Open, element, anchor, 1);

            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(destImage);
        }

        public static Bitmap Close(Bitmap image, int k)
        {
            MorphShapes elementType;
            int karnelSize = 3;

            if (k == 0)
            {
                elementType = MorphShapes.Cross;
            }
            else
            {
                elementType = MorphShapes.Rect;
            }

            Size size = new Size(2 * karnelSize + 1, 2 * karnelSize + 1);
            Point point = new Point(karnelSize, karnelSize);
            Point anchor = new Point(-1, -1);

            Mat element = Cv2.GetStructuringElement(elementType, size, point);

            Mat srcImage = OpenCvSharp.Extensions.BitmapConverter.ToMat(image);
            Mat destImage = new Mat(srcImage.Width, srcImage.Height, MatType.CV_8U);

            destImage = srcImage.Clone();

            Cv2.MorphologyEx(srcImage, destImage, MorphTypes.Close, element, anchor, 1);

            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(destImage);
        }


        public static Bitmap Skeleton(Bitmap image, int k)
        {
            MorphShapes elementType;
            int karnelSize = 3;

            if (k == 0)
            {
                elementType = MorphShapes.Cross;
            }
            else
            {
                elementType = MorphShapes.Rect;
            }

            Size sizeKarnel = new Size(2 * karnelSize + 1, 2 * karnelSize + 1);
            Point point = new Point(karnelSize, karnelSize);
            Point anchor = new Point(-1, -1);

            Mat element = Cv2.GetStructuringElement(elementType, sizeKarnel, point);

            Mat srcImage = OpenCvSharp.Extensions.BitmapConverter.ToMat(image);
            Mat destImage = new Mat();
            Cv2.CvtColor(srcImage, destImage, ColorConversionCodes.RGB2GRAY);

            int done = 0;
            int zeros;
            int size = srcImage.Height * srcImage.Width;
            Size sizeMat = new Size(srcImage.Cols, srcImage.Rows);

            Mat matImgT = new Mat(srcImage.Rows, srcImage.Cols, MatType.CV_8U);
            Mat matImgE = new Mat(srcImage.Rows, srcImage.Cols, MatType.CV_8U);
            Mat matImgS = new Mat();
            matImgS = Mat.Zeros(sizeMat, MatType.CV_8U);

            while(done == 0)
            {
                Cv2.Erode(destImage, matImgE, element);
                Cv2.Dilate(matImgE, matImgT, element);
                Cv2.Subtract(destImage, matImgT, matImgT);
                Cv2.BitwiseOr(matImgS, matImgT, matImgS);
                destImage = matImgE.Clone();
                zeros = size - Cv2.CountNonZero(destImage);
                if (zeros == size)
                {
                    done = 1;
                }
            }

            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(matImgS);
        }
    }
}
