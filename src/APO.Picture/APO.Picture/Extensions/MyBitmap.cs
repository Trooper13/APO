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
    }
}
