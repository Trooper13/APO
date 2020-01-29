using System;
using System.Drawing;
using Point = System.Drawing.Point;
using System.Collections.Generic;
using System.Windows.Forms;
using APO.Segmentation.Extensions;

namespace APO.Picture.Segmentation
{
    public static class Algorytms
    {
        /// <summary>
        /// Algorytm rekonstrukcji (operacja morfologiczna)
        /// </summary>
        /// <param name="bmp">obraz wejściowy</param>
        /// <param name="tresh">markery</param>
        /// <returns>obraz wynikowy</returns>
        public static Bitmap Reconstruction(this Bitmap bmp, List<Point> tresh)
        {
            //Lista punktów sąsiedztwa
            List<Point> neighborhood = new List<Point>();

            //Lista punktów tymczasowych sąsiedztwa (w danej iteracji)
            List<Point> tmp = new List<Point>();

            //Tymczasowy obraz roboczy (utworzony na podstawie obrazu wejściowego)
            Bitmap tmpBmp = bmp.Clone() as Bitmap;

            //Obraz wynikowy 
            Bitmap resultImage = new Bitmap(tmpBmp.Width, tmpBmp.Height);

            //Tablica poszczególnych pikseli, czy był już sprawdzany
            bool[,] isCheck = new bool[tmpBmp.Width, tmpBmp.Height];

            resultImage.SetPictureAsBlack();

            foreach (var pt in tresh)
            {
                neighborhood.Add(pt);
                isCheck.SetIsCheckedTableToFalse(tmpBmp);
                bool search = true;
                int counter = 0;

                while (search)
                {
                    foreach (var el in neighborhood)
                    {
                        try
                        {
                            //255 biały
                            //0 czarny
                            Point top = new Point(el.X, el.Y - 1);
                            Point bottom = new Point(el.X, el.Y + 1);
                            Point left = new Point(el.X - 1, el.Y);
                            Point right = new Point(el.X + 1, el.Y);

                            //TOP pixel
                            if (tmpBmp.GetPixel(top.X, top.Y).R == Color.White.R && !isCheck[top.X, top.Y])
                            {
                                resultImage.SetPixel(top.X, top.Y, Color.FromArgb(255));
                                tmp.Add(new Point(top.X, top.Y)); //do tymczasowego sąsiedztwa
                                isCheck[top.X, top.Y] = true;
                            }

                            //BOTTOM pixel
                            if (tmpBmp.GetPixel(bottom.X, bottom.Y).R == Color.White.R && !isCheck[bottom.X, bottom.Y])
                            {
                                resultImage.SetPixel(bottom.X, bottom.Y, Color.FromArgb(255));
                                tmp.Add(new Point(bottom.X, bottom.Y));
                                isCheck[bottom.X, bottom.Y] = true;
                            }

                            //LEFT pixel
                            if (tmpBmp.GetPixel(left.X, left.Y).R == Color.White.R && !isCheck[left.X, left.Y])
                            {
                                resultImage.SetPixel(left.X, left.Y, Color.FromArgb(255));
                                tmp.Add(new Point(left.X, left.Y));
                                isCheck[left.X, left.Y] = true;
                            }

                            //RIGHT pixel
                            if (tmpBmp.GetPixel(right.X, right.Y).R == Color.White.R && !isCheck[right.X, right.Y])
                            {
                                resultImage.SetPixel(right.X, right.Y, Color.FromArgb(255));
                                tmp.Add(new Point(right.X, right.Y));
                                isCheck[right.X, right.Y] = true;
                            }

                            resultImage.SetPixel(el.X, el.Y, Color.FromArgb(255,255,255)); //set pixel as white on result image
                            tmpBmp.SetPixel(el.X, el.Y, Color.FromArgb(0)); //set pixel as black on temp image

                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            MessageBox.Show("Wystąpił nieoczekiwany błąd podczas rekonstrukcji obrazu!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    neighborhood.Clear();
                    neighborhood.AddRange(tmp);
                    tmp.Clear();

                    search = neighborhood.Count != 0;
                    counter++;
                }
            }

            return resultImage;
        }
    }
}