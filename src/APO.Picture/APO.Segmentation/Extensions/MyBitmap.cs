using System;
using System.Drawing;
using Point = System.Drawing.Point;
using System.Collections.Generic;
using System.Windows.Forms;
using APO.Segmentation.Extensions;

namespace APO.Picture.Segmentation
{
    public static class MyBitmap
    {
        public static Bitmap Reconstruction(this Bitmap bmp, List<Point> tresh)
        {
            List<Point> neighborhood = new List<Point>();
            List<Point> tmp = new List<Point>();
            Bitmap tmpBmp = bmp.Clone() as Bitmap;
            Bitmap resultImage = new Bitmap(tmpBmp.Width, tmpBmp.Height);
            bool[,] isCheck = new bool[tmpBmp.Width, tmpBmp.Height];

            resultImage.SetPictureAsBlack();

            foreach (var pt in tresh)
            {
                neighborhood.Add(pt);
                isCheck.Set2DtableToFalse(tmpBmp);
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

                            //TOP
                            //if (bmp.GetPixel(top.X, top.Y).R == Color.White.R && !isCheckCollection.ContainsValue($"{top.X},{top.Y}"))
                            if (tmpBmp.GetPixel(top.X, top.Y).R == Color.White.R && !isCheck[top.X, top.Y])
                            {
                                resultImage.SetPixel(top.X, top.Y, Color.FromArgb(255));
                                tmp.Add(new Point(top.X, top.Y)); //do tymczasowego sąsiedztwa
                                isCheck[top.X, top.Y] = true;
                            }

                            //BOTTOM
                            //if (bmp.GetPixel(bottom.X, bottom.Y).R == Color.White.R && !isCheckCollection.ContainsValue($"{bottom.X},{bottom.Y}"))
                            if (tmpBmp.GetPixel(bottom.X, bottom.Y).R == Color.White.R && !isCheck[bottom.X, bottom.Y])
                            {
                                resultImage.SetPixel(bottom.X, bottom.Y, Color.FromArgb(255));
                                tmp.Add(new Point(bottom.X, bottom.Y));
                                isCheck[bottom.X, bottom.Y] = true;
                            }

                            //LEFT
                            //if (bmp.GetPixel(left.X, left.Y).R == Color.White.R && !isCheckCollection.ContainsValue($"{left.X},{left.Y}"))
                            if (tmpBmp.GetPixel(left.X, left.Y).R == Color.White.R && !isCheck[left.X, left.Y])
                            {
                                resultImage.SetPixel(left.X, left.Y, Color.FromArgb(255));
                                tmp.Add(new Point(left.X, left.Y));
                                isCheck[left.X, left.Y] = true;
                            }

                            //RIGHT
                            //if (bmp.GetPixel(right.X, right.Y).R == Color.White.R && !isCheckCollection.ContainsValue($"{right.X},{right.Y}"))
                            if (tmpBmp.GetPixel(right.X, right.Y).R == Color.White.R && !isCheck[right.X, right.Y])
                            {
                                resultImage.SetPixel(right.X, right.Y, Color.FromArgb(255));
                                tmp.Add(new Point(right.X, right.Y));
                                isCheck[right.X, right.Y] = true;
                            }

                            //isCheckCollection.Add(el.X, el.Y);
                            resultImage.SetPixel(el.X, el.Y, Color.FromArgb(255));
                            tmpBmp.SetPixel(el.X, el.Y, Color.FromArgb(0)); //set as black

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