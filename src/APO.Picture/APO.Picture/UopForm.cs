using APO.Picture.Segmentation;
using Emgu.CV;
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

namespace APO.Picture
{
    public partial class UopForm : Form
    {
        Bitmap originalBitmap;
        Bitmap newBitmap;
        Graphics graphic;
        Curve curve;
        int[] LUT;

        public UopForm(Bitmap image)
        {
            InitializeComponent();
            originalBitmap = image;
            newBitmap = (Bitmap)originalBitmap.Clone();

            pictureBox1.Image = new Bitmap(256, 256);
            graphic = Graphics.FromImage(pictureBox1.Image);

            curve = new Curve();
            LUT = new int[256];

            panelOrg.Size = originalBitmap.Size;
            panelOrg.Location = new Point(0, 0);

            DrawLine();
        }

        private void DrawLine()
        {
            pictureBox1.Refresh();
            curve.TworzTablice();               //Konwertuje liste na tablice skladajaca sie z punktow - dopisac sortowanie po X
            graphic.DrawCurve(curve.Pen, curve.TSkladoweKrzywej, curve.Tension);
            for (int i = 0; i < curve.LSkladoweKrzywej.Count; i++)
                graphic.DrawRectangle(curve.Pen, curve.LSkladoweKrzywej[i].X - 3, curve.LSkladoweKrzywej[i].Y - 3, 7, 7);
            pictureBox1.Refresh();
            TworzTabliceLUT(curve.TSkladoweKrzywej);
            //for (int i = 0; i < 256; i++)
            //    histogram.Edit(LUT[i], i);
            //histogram_Modified(histogram);

        }

        public void TworzTabliceLUT(Point[] tablicaZrodlowa)
        {
            int liczbaPunktow = tablicaZrodlowa.Length;
            int poczatek = 0;
            float b, c, e, f;
            float A, B;
            b = tablicaZrodlowa[0].X;
            c = tablicaZrodlowa[0].Y;

            for (int i = 1; i < liczbaPunktow; i++)
            {
                e = tablicaZrodlowa[i].X;
                f = tablicaZrodlowa[i].Y;

                //MessageBox.Show(tablicaZrodlowa[i].X.ToString() + " " + tablicaZrodlowa[i].Y.ToString());
                if ((e - b) != 0)
                {
                    B = (c * e - b * f) / (e - b);
                    A = (f - c) / (e - b);

                    for (; poczatek <= tablicaZrodlowa[i].X; poczatek++)
                    {
                        LUT[poczatek] = (int)(A * poczatek + B);
                    }
                }
                b = e;
                c = f;
            }
        }

        public Bitmap Bitmap
        {
            get { return originalBitmap; }
        }

        //public Bitmap Opencv(Bitmap image)
        //{
        //    Image<Gray, Byte> _image = new Image<Gray, byte>(image);//load the image from some where
        //    Image < Gray, Byte> imageInvert = new Image<Gray, Byte>(image.Width, image.Height);
        //    CvInvoke.Sobel()
        //}
    }
}
