using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using OpenCvSharp;
using Size = System.Drawing.Size;
using Point = System.Drawing.Point;
using Mat = OpenCvSharp.Mat;
using APO.Picture.Data;

namespace APO.Picture.Extensions
{
    public class MyBitmap
    {
        private BitmapData bitmapData;

        /// <summary>
        /// Negacja (odwrotność)
        /// </summary>
        /// <param name="image">obraz</param>
        /// <returns>obraz po operacji negazji</returns>
        public static Bitmap Negative(Bitmap image)
        {
            Bitmap imageResult = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; ++i)
            {
                for (int j = 0; j < image.Height; ++j)
                {
                    Color color = image.GetPixel(i, j);

                    imageResult.SetPixel(i, j, Color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B));
                }
            }

            return imageResult;
        }

        /// <summary>
        /// Progowanie (Binaryzacja)
        /// </summary>
        /// <param name="image">obraz wejściowy</param>
        /// <returns>obraz po progowaniu</returns>
        public static Bitmap Tresholding(Bitmap image, int tresholdValue)
        {
            Bitmap imageResult = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; ++i)
            {
                for (int j = 0; j < image.Height; ++j)
                {
                    Color color = image.GetPixel(i, j);

                    if (color.R >= tresholdValue)
                    {
                        imageResult.SetPixel(i, j, Color.FromArgb(1, 1, 1, 1));
                    }
                    else
                    {
                        imageResult.SetPixel(i, j, Color.FromArgb(0,0,0));
                    }
                }
            }

            return imageResult;
        }

        public static Bitmap ThresholdingSaveGreyScale(Bitmap image, int tresholdFirstValue, int treshlodSecondValue)
        {
            Bitmap imageResult = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color color = image.GetPixel(i, j);

                    if (color.R >= tresholdFirstValue && color.R <= treshlodSecondValue)
                    {
                        imageResult.SetPixel(i, j, Color.FromArgb(color.R, color.R, color.R, color.R));
                    }
                    else
                    {
                        imageResult.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                }
            }

            return imageResult;
        }

        /// <summary>
        /// Posteryzacja (redukcja poziomów szarości)
        /// </summary>
        /// <param name="image">obraz wejściowy</param>
        /// <param name="level">poziomy szarości</param>
        /// <returns>obraz wynikowy</returns>
        public static Bitmap Reduction(Bitmap image, int level)
        {
            Bitmap resulImaget = new Bitmap(image.Width, image.Height);

            int[] upo = new int[256];
            int param1 = 255 / (level - 1);
            float param2 = 256 / level;

            for (int i = 0; i < 256; ++i)
            {
                upo[i] = (int)(i / param2) * param1;
            }

            int val;
            for (int x = 0; x < image.Width; ++x)
            {
                for (int y = 0; y < image.Height; ++y)
                {
                    val = image.GetPixel(x, y).R;
                    int nowy = upo[val];
                    resulImaget.SetPixel(x, y, Color.FromArgb(nowy, nowy, nowy));
                }
            }
            return resulImaget;
        }
        
        /// <summary>
        /// Rozciąganie
        /// </summary>
        /// <param name="image">obraz wejściowy</param>
        /// <param name="value1">wartość pierwsza</param>
        /// <param name="value2">wartość druga</param>
        /// <returns>obraz po operacji rozciągania</returns>
        public static Bitmap Stretching(Bitmap image, int value1, int value2)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; ++x)
            {
                for (int y = 0; y < image.Height; ++y)
                {
                    Color color = image.GetPixel(x, y);
                    if (color.R > value1 && color.R <= value2)
                    {
                        result.SetPixel(x, y, Color.FromArgb(
                            (color.R - value1) * (255 / (value2 - value1)),
                            (color.R - value1) * (255 / (value2 - value1)),
                            (color.R - value1) * (255 / (value2 - value1))));
                    }
                    else
                    {
                        result.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            return result;
        }

        public static Bitmap SmoothMask(Bitmap image, float[] mask)
        {

            var ksize = new Size(3, 3);
            var anchor = new OpenCvSharp.Point(-1, -1);
            Mat karnelNorm = new Mat();
            Mat imageGrey = new Mat();
            float devider = mask.SumMask();

            Mat karnel = new Mat(3, 3, MatType.CV_32F, mask);
            Mat _image = OpenCvSharp.Extensions.BitmapConverter.ToMat(image);

            if (_image.Channels() != 1)
                Cv2.CvtColor(_image, imageGrey, ColorConversionCodes.RGB2GRAY);

            Cv2.Multiply(karnel, new Scalar(1 / (double)devider), karnelNorm);


            Mat imageInvert = new Mat(image.Width, image.Height, MatType.CV_8U);

            if (_image.Channels() != 1)
                Cv2.Filter2D(imageGrey, imageInvert, -1, karnelNorm, anchor);

            Cv2.Filter2D(_image, imageInvert, -1, karnelNorm, anchor);

            Bitmap result = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageInvert);

            return result;
        }

        public static Bitmap SharpAndEdgeMask(Bitmap image, float[] mask)
        {
            
            var ksize = new Size(3, 3);
            var anchor = new OpenCvSharp.Point(-1, -1);
            //Mat karnelNorm = new Mat();
            Mat imageGrey = new Mat();
            //float devider = mask.SumMask();

            Mat karnel = new Mat(3, 3, MatType.CV_32F, mask);
            Mat _image = OpenCvSharp.Extensions.BitmapConverter.ToMat(image);

            if (_image.Channels() != 1)
                Cv2.CvtColor(_image, imageGrey, ColorConversionCodes.RGB2GRAY);

            //Cv2.Multiply(karnel, new Scalar(1 / (double)devider), karnelNorm);


            Mat imageInvert = new Mat(image.Width, image.Height, MatType.CV_8U);

            if (_image.Channels() != 1)
                Cv2.Filter2D(imageGrey, imageInvert, -1, karnel, anchor);

            Cv2.Filter2D(_image, imageInvert, -1, karnel, anchor);

            Bitmap result = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageInvert);

            return result;
        }

    }
}
//var ksize = new Size(3, 3);
//var anchor = new Point(-1, -1);

//Image<Gray, Byte> _image = new Image<Gray, byte>(image);//load the image from some where
//Image<Gray, Byte> imageInvert = new Image<Gray, Byte>(image.Width, image.Height);
//CvInvoke.Blur(_image, imageInvert, ksize, anchor);

//return imageInvert.Bitmap;

//float[] data = new float[] { 0, 1, 0, 1, 4, 1, 0, 1, 0 };

//var anchor = new Point(-1, -1);
//int[] data = new int[]{ 0, 1, 0, 1, 4, 1, 0, 1, 0 };
//Mat karnel = new Mat(ksize, Emgu.CV.CvEnum.DepthType.Default, 1);
//karnel.SetTo<float>(0, 0, -1);

//Image<Gray, Byte> _image = new Image<Gray, byte>(image);//load the image from some where
//Image<Gray, Byte> imageInvert = new Image<Gray, Byte>(image.Width, image.Height);
//CvInvoke.Filter2D(_image, imageInvert, karnel, anchor);