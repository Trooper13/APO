using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using APO.Picture.Extensions;

namespace APO.Picture
{
    public partial class ImageForm : Form
    {
        private Histogram histogram;
        public string ImagePath { get; set; }
        public Bitmap CurrentImage { get; set; }
        public int[] HistogramArray { get; set; }

        public ImageForm()
        {
            InitializeComponent();
        }

        public ImageForm(string file)
        {
            InitializeComponent();
            ImagePath = file;
            Text = Path.GetFileName(file);
            CurrentImage = (Bitmap) Image.FromFile(ImagePath);
            DrawImageHistogram(CurrentImage);
            pictureBoxImage.Image = CurrentImage;
        }

        private void DrawImageHistogram(Bitmap bitmap)
        {
            if (bitmap.PixelFormat == PixelFormat.Format16bppGrayScale)
            {
                HistogramArray = new Histogram(bitmap).Levels;
                Histogram.Draw(HistogramArray, histogramViewGrey);
            }

            if (bitmap.PixelFormat == PixelFormat.Format24bppRgb)
            {
                HistogramArray = new Histogram(bitmap).Levels;
                Histogram.Draw(HistogramArray, histogramViewRed);
            }
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //histogram.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
