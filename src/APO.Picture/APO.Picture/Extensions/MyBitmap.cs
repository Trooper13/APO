using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
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

        public static void WektorCech(FastBitmap bitmap)
        {
            var bmp = (FastBitmap)bitmap.Clone();

            var perimeter = 0;
            var area = 0;
            var size = bmp.Width * bmp.Height;
            var areaNorm = 0.0;
            int[] r0 = { 0, 0 };
            long m00 = 0;
            long m10 = 0;
            long m01 = 0;
            long m11 = 0;

            for (var x = 0; x < bmp.Width; x++)
                for (var y = 0; y < bmp.Height; y++)
                {
                    int rpixel = bmp[x, y];
                    if (rpixel > 0)
                    {
                        area++;
                        m00 += bmp[x, y];
                        m10 += x * bmp[x, y];
                        m01 += y * bmp[x, y];
                        m11 += x * y * bmp[x, y];

                        for (var i = -1; i < 2; i++)
                            for (var j = -1; j < 2; j++)
                                if (isPixelValid(x + i, y + j, bmp.Width, bmp.Height))
                                {
                                    int sasiad = bmp[x + i, y + j];

                                    if (sasiad == 0)
                                    {
                                        perimeter++;
                                        r0[0] += x;
                                        r0[1] += y;
                                        goto next;
                                    }
                                }
                    }

                    next:;
                }

            if (perimeter > 0)
            {
                r0[0] = r0[0] / perimeter;
                r0[1] = r0[1] / perimeter;
            }

            areaNorm = area / (double)size;
            var W1 = 2.0 * Math.Sqrt(area / Math.PI);
            var W2 = perimeter / Math.PI;
            var W3 = perimeter / (2.0 * Math.Sqrt(area * Math.PI));
            var W9 = 2.0 * Math.Sqrt(area * Math.PI) / perimeter;
            var minX = -1;
            var maxX = -1;
            var minY = -1;
            var maxY = -1;
            var isSet = false;
            long sumaOdl = 0;
            long M10 = 0;
            long M01 = 0;
            long M11 = 0;

            for (var x = 0; x < bmp.Width; x++)
                for (var y = 0; y < bmp.Height; y++)
                {
                    int rpixel = bmp[x, y];
                    if (rpixel > 0)
                    {
                        if (!isSet)
                        {
                            isSet = true;
                            if (minX == -1) minX = x;
                            if (maxX == -1) maxX = x;
                            if (minY == -1) minY = y;
                            if (maxY == -1) maxY = y;
                        }

                        if (x < minX) minX = x;
                        if (x > maxX) maxX = x;
                        if (y < minY) minY = y;
                        if (y > maxY) maxY = y;

                        M10 += (x - r0[0]) * bmp[x, y];
                        M01 += (y - r0[1]) * bmp[x, y];
                        M11 += (x - r0[0]) * (y - r0[1]) * bmp[x, y];
                        sumaOdl += (long)Math.Pow(Math.Sqrt(Math.Pow(x - r0[0], 2) + Math.Pow(y - r0[1], 2)), 2);
                    }
                }

            var gabarytX = maxX - minX;
            var gabarytY = maxY - minY;
            int gabaryt;
            if (gabarytX > gabarytY) gabaryt = gabarytX;
            else gabaryt = gabarytY;
            var W8 = gabaryt / (double)perimeter;
            var W4 = area / Math.Sqrt(2 * Math.PI * sumaOdl);

            MessageBox.Show("Liczba pikseli: " + size +
                            "\nPiksele tła: " + (size - area) +
                            "\nPowierzchnia obiektu: " + area +
                            //"\nArea (normalized): " + areaNorm +
                            "\nOtoczenie: " + perimeter +
                            "\nŚrodek ciężkości: " + r0[0] + ", " + r0[1] +
                            "\n\nW1: " + W1 +
                            "\nW2: " + W2 +
                            "\nW3: " + W3 +
                            "\nW4: " + W4 +
                            "\nW8: " + W8 +
                            "\nW9: " + W9 +
                            "\n\nMoment m(0, 0): " + m00 +
                            "\nMoment m(0, 1): " + m01 +
                            "\nMoment m(1, 0): " + m10 +
                            "\nMoment m(1, 1): " + m11 +
                            "\n\nCentral moment M(1, 0): " + M10 +
                            "\nCentral moment M(0, 1): " + M01 +
                            "\nCentral moment M(1, 1): " + M11,
                "Wyniki analizy");
        }
        private static bool isPixelValid(int x, int y, int width, int height)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
                return true;
            return false;
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