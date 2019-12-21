using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApoImages
{
    public partial class MainForm : Form
    {
        Bitmap loadedImage;
        bool isBlackAndWhite;
        private object pictureBox1;

        public MainForm()
        {
            InitializeComponent();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                loadedImage = Bitmap.FromFile(openImageFileDialog.FileName) as Bitmap;
                pictureBox.Image = loadedImage;
                CheckBlackAndWhite();
            }
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CheckBlackAndWhite()
        {
            isBlackAndWhite = true;

            for (int i = 0; i < loadedImage.Height; i++)
                for (int j = 0; j < loadedImage.Width; j++)
                {
                    Color c = loadedImage.GetPixel(j, i);

                    if (!(c.R == c.B && c.B == c.G && c.R == c.G))
                    {
                        isBlackAndWhite = false;
                    }
                }
        }

        private void kolorowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] r, g, b;
            r = CalculateHistogram(loadedImage, 'R');
            g = CalculateHistogram(loadedImage, 'G');
            b = CalculateHistogram(loadedImage, 'B');

            using (var hist = new HistogramForm(r, g, b))
            {
                hist.ShowDialog();
            }
        }

        private void czarnobiałyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isBlackAndWhite)
            {
                MessageBox.Show("Obraz kolorowy, nie można wyświetlić histogramu czarno-białego.");
                return;
            }

            var r = CalculateHistogram(loadedImage, 'R');

            using (var hist = new HistogramForm(r))
            {
                hist.ShowDialog();
            }
        }

        private int[] CalculateHistogram(Bitmap image, char color)
        {
            int[] hist = new int[256];

            for (int i = 0; i < loadedImage.Height; i++)
                for (int j = 0; j < loadedImage.Width; j++)
                {
                    Color c = loadedImage.GetPixel(j, i);
                    switch (color)
                    {
                        case 'R':
                            hist[c.R]++;
                            break;
                        case 'G':
                            hist[c.G]++;
                            break;
                        case 'B':
                            hist[c.B]++;
                            break;
                    }
                }

            return hist;
        }

        private void negacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(loadedImage.Width, loadedImage.Height);
            for (int i = 0; i < loadedImage.Height; i++)
                for (int j = 0; j < loadedImage.Width; j++)
                {
                    Color c = loadedImage.GetPixel(j, i);
                    Color newColor = Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
                    bmp.SetPixel(j, i, newColor);
                }
            pictureBox.Image = bmp;
            loadedImage.Dispose();
            loadedImage = bmp;

        }

        private void progowanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int p1;
            using (var f = new ProgowanieForm())
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                p1 = f.P1;
            }

            Bitmap bmp = new Bitmap(loadedImage.Width, loadedImage.Height);
            for (int i = 0; i < loadedImage.Height; i++)
                for (int j = 0; j < loadedImage.Width; j++)
                {
                    Color c = loadedImage.GetPixel(j, i);
                    int r = c.R <= p1 ? 0 : 255;
                    int b = c.G <= p1 ? 0 : 255;
                    int g = c.G <= p1 ? 0 : 255;

                    Color newColor = Color.FromArgb(r, g, b);
                    bmp.SetPixel(j, i, newColor);
                }
            pictureBox.Image = bmp;
            loadedImage.Dispose();
            loadedImage = bmp;

        }


        private void progowanieZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int p1;
            int p2;
            bool isNagated;
            using (var f = new ProgowanieOdcienieSzarosciForm())
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                p1 = f.P1;
                p2 = f.P2;
                isNagated = f.IsNegated;
            }

            Bitmap bmp = new Bitmap(loadedImage.Width, loadedImage.Height);
            for (int i = 0; i < loadedImage.Height; i++)
                for (int j = 0; j < loadedImage.Width; j++)
                {
                    Color c = loadedImage.GetPixel(j, i);
                    int r = c.R < p1 || c.R > p2 ? 0 : c.R;
                    int g = c.G < p1 || c.G > p2 ? 0 : c.G;
                    int b = c.B < p1 || c.B > p2 ? 0 : c.B;

                    if (isNagated)
                    {
                        r = 255 - r;
                        g = 255 - g;
                        b = 255 - b;
                    }

                    Color newColor = Color.FromArgb(r, g, b);
                    bmp.SetPixel(j, i, newColor);
                }
            pictureBox.Image = bmp;
            loadedImage.Dispose();
            loadedImage = bmp;
        }

        private void redukcjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n;
            using (var f = new PosteryzacjaForm())
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                n = f.N;
            }

            int p = 256 / (n);

            Bitmap bmp = new Bitmap(loadedImage.Width, loadedImage.Height);
            for (int i = 0; i < loadedImage.Height; i++)
                for (int j = 0; j < loadedImage.Width; j++)
                {
                    Color c = loadedImage.GetPixel(j, i);

                    int r = 0;
                    while (r + p < c.R)
                    {
                        r += p;
                    }
                    r = Math.Min(r, 255);

                    int g = 0;
                    while (g + p < c.G)
                    {
                        g += p;
                    }
                    g = Math.Min(g, 255);

                    int b = 0;
                    while (b + p < c.B)
                    {
                        b += p;
                    }
                    b = Math.Min(b, 255);
                    Color newColor = Color.FromArgb(r, g, b);
                    bmp.SetPixel(j, i, newColor);
                }
            pictureBox.Image = bmp;
            loadedImage.Dispose();
            loadedImage = bmp;
        }

        private void ProcessFilter(int[,] mask)
        {
            int cX = mask.GetLength(0) / 2, cY = mask.GetLength(1) / 2;
            int sumWeights = 0;
            int k = 0;
            for (int i = 0; i < mask.GetLength(0); i++)
            {
                for (int j = 0; j < mask.GetLength(1); j++)
                {
                    sumWeights += mask[i, j];
                }
            }

            if (sumWeights == 0)
            {
                sumWeights = 1;
            }

            Bitmap bmp = new Bitmap(loadedImage.Width, loadedImage.Height);
            for (int i = 0; i < loadedImage.Width; i++)
                for (int j = 0; j < loadedImage.Height; j++)
                {

                    if (i < cX || j < cY || i + cX > loadedImage.Width - 1 || j + cY > loadedImage.Height - 1)
                    {
                        Color c = loadedImage.GetPixel(i, j);

                        bmp.SetPixel(i, j, c);
                        continue;
                    }
                    int r = 0, g = 0, b = 0;

                    for (int ci = 0; ci < mask.GetLength(0); ci++)
                    {
                        for (int cj = 0; cj < mask.GetLength(1); cj++)
                        {
                            Color cN = loadedImage.GetPixel(i + ci - cX, j + cj - cY);
                            r += cN.R * mask[ci, cj];
                            g += cN.G * mask[ci, cj];
                            b += cN.B * mask[ci, cj];
                        }
                    }
                    r /= sumWeights;
                    g /= sumWeights;
                    b /= sumWeights;
                    r = Math.Max(0, Math.Min(r, 255));
                    g = Math.Max(0, Math.Min(g, 255));
                    b = Math.Max(0, Math.Min(b, 255));
                    Color newColor = Color.FromArgb(r, g, b);
                    bmp.SetPixel(i, j, newColor);
                }
            pictureBox.Image = bmp;
            loadedImage.Dispose();
            loadedImage = bmp;
        }


        private void ProcessMedian(int n, int m)
        {
            int cX = n / 2, cY = m / 2;

            Bitmap bmp = new Bitmap(loadedImage.Width, loadedImage.Height);
            for (int i = 0; i < loadedImage.Width; i++)
                for (int j = 0; j < loadedImage.Height; j++)
                {

                    if (i < cX || j < cY || i + cX > loadedImage.Width - 1 || j + cY > loadedImage.Height - 1)
                    {
                        Color c = loadedImage.GetPixel(i, j);

                        bmp.SetPixel(i, j, c);
                        continue;
                    }
                    List<int> r = new List<int>(), g = new List<int>(), b = new List<int>();

                    for (int ci = 0; ci < n; ci++)
                    {
                        for (int cj = 0; cj < m; cj++)
                        {
                            Color cN = loadedImage.GetPixel(i + ci - cX, j + cj - cY);
                            r.Add(cN.R);
                            g.Add(cN.G);
                            b.Add(cN.B);
                        }
                    }


                    Color newColor = Color.FromArgb(r[r.Count / 2], g[g.Count / 2], b[b.Count / 2]);
                    bmp.SetPixel(i, j, newColor);
                }
            pictureBox.Image = bmp;
            loadedImage.Dispose();
            loadedImage = bmp;
        }


        private void maska1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 0, 1, 0 }, { 1, 4, 1 }, { 0, 1, 0 } };
            ProcessFilter(mask);
        }

        private void maska2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            ProcessFilter(mask);
        }

        private void maska3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };
            ProcessFilter(mask);
        }

        private void maska4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int k = 25;
            Console.WriteLine("Podaj liczbe: ");
            k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("podales {0}  \n", k);
            Console.ReadLine();
            int[,] mask = new int[3, 3] { { 1, 1, 1 }, { 1, k, 1 }, { 1, 1, 1 } };
            ProcessFilter(mask);
        }

        private void maska1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 0, -1, 0 }, { -1, 4, -1 }, { 0, -1, 0 } };
            ProcessFilter(mask);
        }

        private void maska2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };
            ProcessFilter(mask);
        }

        private void maska3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 1, -2, 1 }, { -2, 4, -2 }, { 1, -2, 1 } };
            ProcessFilter(mask);
        }

        private void maska4ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
            ProcessFilter(mask);
        }

        private void maska1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 1, -2, 1 }, { -2, 5, -2 }, { 1, -2, 1 } };
            ProcessFilter(mask);
        }

        private void maska2ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
            ProcessFilter(mask);
        }

        private void maska3ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
            ProcessFilter(mask);
        }

        private void manualnaMacierzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int size;
            using (var f = new FiltrMacierzowyForm())
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                size = f.Size;
            }


            Image<Bgr, Byte> My_Image = new Image<Bgr, byte>(pictureBox.Image as Bitmap);

            pictureBox.Image = My_Image.SmoothMedian(size).ToBitmap();

        }

        private void ąsiedztwaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] mask;
            using (var f = new SkladanieMasekForm())
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                mask = f.Mask;
            }

            ProcessFilter(mask);
        }

        private void wschódToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { -1, 1, 1 }, { -1, 0, 1 }, { 0, -1, 0 } };
            ProcessFilter(mask);
        }

        private void zachódToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 1, 1, -1 }, { 1, 0, -1 }, { 1, 1, -1 } };
            ProcessFilter(mask);
        }

        private void północToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 1, 1, 1 }, { 1, 0, 1 }, { -1, -1, -1 } };
            ProcessFilter(mask);
        }

        private void południeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { -1, -1, -1 }, { 1, 0, 1 }, { 1, 1, 1 } };
            ProcessFilter(mask);
        }

        private void pnWschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 1, 1, 1 }, { -1, 0, 1 }, { -1, -1, 1 } };
            ProcessFilter(mask);
        }

        private void pnZachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 1, 1, 1 }, { 1, 0, -1 }, { 1, -1, -1 } };
            ProcessFilter(mask);
        }

        private void pdWschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { -1, -1, 1 }, { -1, 0, 1 }, { 1, 1, 1 } };
            ProcessFilter(mask);
        }

        private void pdZachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 1, -1, -1 }, { 1, 0, -1 }, { 1, 1, 1 } };
            ProcessFilter(mask);
        }

        private void pdWschódToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[2, 2] { { 1, 0, }, { 0, -1, } };
            ProcessFilter(mask);
        }

        private void pnZachToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[2, 2] { { -1, 0, }, { 0, 1, } };
            ProcessFilter(mask);
        }

        private void wschódToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
            ProcessFilter(mask);
        }

        private void zachódToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 1, 0, -1 }, { 1, 0, -1 }, { 1, 0, -1 } };
            ProcessFilter(mask);
        }

        private void północToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 1, 1, 1 }, { 0, 0, 0 }, { -1, -1, -1 } };
            ProcessFilter(mask);
        }

        private void południeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
            ProcessFilter(mask);
        }

        private void pnWschToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 0, 1, 1 }, { -1, 0, 1 }, { -1, -1, 0 } };
            ProcessFilter(mask);
        }

        private void pnZachToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 1, 1, 0 }, { 1, 0, -1 }, { 0, -1, -1 } };
            ProcessFilter(mask);
        }

        private void pdWschToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { -1, -1, 0 }, { -1, 0, 1 }, { 0, 1, 1 } };
            ProcessFilter(mask);
        }

        private void pdZachToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[,] mask = new int[3, 3] { { 0, -1, -1 }, { 1, 0, -1 }, { 1, 1, 0 } };
            ProcessFilter(mask);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {


            OpenFileDialog Openfile = new OpenFileDialog();
            if (Openfile.ShowDialog() == DialogResult.OK)
            {
                Image<Bgr, Byte> My_Image = new Image<Bgr, byte>(Openfile.FileName);
                //pictureBox;
                pictureBox.Image = My_Image.SmoothMedian(11).ToBitmap();
                //My_Image.Erode().ToBitmap();

            }

        }


        private void ErodeDilate(bool erode, int[] dx, int[] dy)
        {
            Bitmap bmp = new Bitmap(loadedImage.Width, loadedImage.Height);
            for (int i = 0; i < loadedImage.Width; i++)
                for (int j = 0; j < loadedImage.Height; j++)
                {
                    bool edge = false;

                    for (int di = 0; di < dx.Length; di++)
                    {

                        if (!(i + dx[di] >= 0 && i + dx[di] < loadedImage.Width && j + dy[di] >= 0 && j + dy[di] < loadedImage.Height))
                        {
                            edge = true;
                        }

                    }

                    if (edge == true)
                    {
                        Color c = loadedImage.GetPixel(i, j);

                        bmp.SetPixel(i, j, c);

                        continue;
                    }


                    int r = erode ? 255 : 0, g = erode ? 255 : 0, b = erode ? 255 : 0;

                    for (int di = 0; di < dx.Length; di++)
                    {
                        Color cN = loadedImage.GetPixel(i + dx[di], j + dy[di]);
                        if (erode)
                        {
                            r = Math.Min(cN.R, r);
                            g = Math.Min(cN.G, g);
                            b = Math.Min(cN.B, b);
                        }
                        else
                        {
                            r = Math.Max(cN.R, r);
                            g = Math.Max(cN.G, g);
                            b = Math.Max(cN.B, b);

                        }

                    }

                    Color newColor = Color.FromArgb(r, g, b);
                    bmp.SetPixel(i, j, newColor);
                }
            pictureBox.Image = bmp;
            loadedImage.Dispose();
            loadedImage = bmp;
        }

        private void erozjaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            int[] dx, dy;
            using (var f = new SasiedztwoForm())
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                dx = f.Dx;

                dy = f.Dy;
            }


            ErodeDilate(true, dx, dy);
        }

        private void dylacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int[] dx, dy;
            using (var f = new SasiedztwoForm())
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                dx = f.Dx;

                dy = f.Dy;
            }


            ErodeDilate(false, dx, dy);
        }

        private void otwarcieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] dx, dy;
            using (var f = new SasiedztwoForm())
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                dx = f.Dx;

                dy = f.Dy;
            }


            ErodeDilate(true, dx, dy);
            ErodeDilate(false, dx, dy);
        }

        private void zamknięcieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] dx, dy;
            using (var f = new SasiedztwoForm())
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                dx = f.Dx;

                dy = f.Dy;
            }


            ErodeDilate(false, dx, dy);
            ErodeDilate(true, dx, dy);
        }

        private void szkieletyzacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] dx = { 0, 1, 1, 1, 0, -1, -1, -1 };
            int[] dy = { 1, 1, 0, -1, -1, -1, 0, 1 };


            bool[,] temp = new bool[loadedImage.Width, loadedImage.Height];

            for (int i = 0; i < loadedImage.Width; i++)
            {
                for (int j = 0; j < loadedImage.Height; j++)
                {
                    temp[i, j] = loadedImage.GetPixel(i, j).G == 0;
                }
            }

            bool mode = false;
            List<Point> list;

            do
            {
                list = new List<Point>();
                mode = !mode;

                for (int i = 1; i < loadedImage.Width - 1; ++i)
                {
                    for (int j = 1; j < loadedImage.Height - 1; ++j)
                    {
                        if (temp[i, j])
                        {
                            int count = 0;
                            int hm = 0;
                            bool previous = temp[i - 1, j + 1];
                            for (int k = 0; k < 8; ++k)
                            {
                                bool current = temp[i + dx[k], j + dy[k]];
                                hm += current ? 1 : 0;
                                if (previous && !current)
                                {
                                    ++count;
                                }

                                previous = current;
                            }
                            if (hm > 1 && hm < 7 && count == 1)
                            {
                                if (mode)
                                {
                                    if (!temp[i + 1, j] || !temp[i, j + 1] || !temp[i, j - 1] && !temp[i - 1, j])
                                    {
                                        list.Add(new Point(i, j));
                                    }
                                }
                                else if (!temp[i - 1, j] || !temp[i, j - 1] || !temp[i, j + 1] && !temp[i + 1, j])
                                {
                                    list.Add(new Point(i, j));
                                }



                            }
                        }

                    }
                }
                foreach (Point p in list)
                {
                    temp[p.X, p.Y] = false;
                }
            } while (list.Count != 0);

            Bitmap ret = new Bitmap(loadedImage.Width, loadedImage.Height);

            for (int i = 0; i < loadedImage.Width; ++i)
            {
                for (int j = 0; j < loadedImage.Height; ++j)
                {
                    int val = (byte)(temp[i, j] ? 0 : 255 - 1);
                    ret.SetPixel(i, j, Color.FromArgb(val, val, val));
                }
            }

            pictureBox.Image = ret;
            this.loadedImage.Dispose();
            this.loadedImage = ret;
        }
    }
}
