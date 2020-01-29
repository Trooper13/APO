using System.Drawing;
using System.Windows.Forms;

namespace APO.Segmentation.Extensions
{
    public static class Helper
    {
        /// <summary>
        /// Ustawienie rozmiarów Picture Box (nie większe niż 400x400 pikseli, skalowanie)
        /// </summary>
        /// <param name="pictureBox">Picture Box</param>
        /// <param name="bmp">Obraz</param>
        public static void SetPicturBoxSize(this PictureBox pictureBox, Bitmap bmp)
        {
            float getWidth = bmp.Width;
            float getHeight = bmp.Height;
            float ratio;

            if (getWidth > getHeight)
            {
                ratio = getWidth / 400;
                getWidth = 400;
                getHeight = (int)(getHeight / ratio);
            }
            else
            {
                ratio = getHeight / 400;
                getHeight = 400;
                getWidth = (int)(getWidth / ratio);
            }
            pictureBox.Width = (int)getWidth;
            pictureBox.Height = (int)getHeight;
        }

        /// <summary>
        /// Ustawienie obrazu na czarny
        /// </summary>
        /// <param name="bmp">Obraz</param>
        public static void SetPictureAsBlack(this Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
            }
        }

        public static void Set2DtableToFalse(this bool[,] table, Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    table[i, j] = false;
                }
            }
        }
    }
}
