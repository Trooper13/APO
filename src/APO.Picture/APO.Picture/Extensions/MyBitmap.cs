using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APO.Picture.Extensions
{
    class MyBitmap
    {
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
    }
}
