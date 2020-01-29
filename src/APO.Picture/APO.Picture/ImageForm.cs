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
using APO.Picture.Segmentation;

namespace APO.Picture
{
    public partial class ImageForm : Form
    {
        private Histogram histogram;
        public string ImagePath { get; set; }
        public Bitmap CurrentImage { get; set; }

        public FastBitmap FastImage { get; set; }
        public int[] GreyHistogramArray { get; set; }
        public int[] RedHistogramArray { get; set; }
        public int[] GreenHistogramArray { get; set; }
        public int[] BlueHistogramArray { get; set; }
        public int CopyId { get; set; } = 0;
        public string TitleText { get; set; } = "";

        //TODO: Do zrobienie przekazanie wszystkich tablic na raz
        //public int[] AllHistogramArray { get; set; }

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
            //////////////////////////////
            var reader = new StreamReader(file);
            var bmpTemp = (Bitmap)System.Drawing.Image.FromStream(reader.BaseStream);
            reader.Close();
            FastImage = new FastBitmap(bmpTemp);
            //////////////////////////////
            DrawImageHistogram(CurrentImage);
            pictureBoxImage.Image = CurrentImage;
        }

        private void DrawImageHistogram(Bitmap bitmap)
        {
            GreyHistogramArray = new Histogram(bitmap, "Grey").Levels;
            RedHistogramArray = new Histogram(bitmap, "R").Levels;
            GreenHistogramArray = new Histogram(bitmap, "G").Levels;
            BlueHistogramArray = new Histogram(bitmap, "B").Levels;
            
            Histogram.Draw(GreyHistogramArray, histogramViewGrey);
            Histogram.Draw(RedHistogramArray, histogramViewRed);
            Histogram.Draw(GreenHistogramArray, histogramViewGreen);
            Histogram.Draw(BlueHistogramArray, histogramViewBlue);

        }

        public ImageForm(ImageForm form, Bitmap bitmap)
        {
            InitializeComponent();
            CopyId = form.CopyId;
            ImagePath = form.ImagePath;
            TitleText = "";
            TitleText = "Copy_" + CopyId + "_" + Path.GetFileName(ImagePath);
            CurrentImage = bitmap;
            Text = TitleText;
            DrawImageHistogram(bitmap);
            pictureBoxImage.Image = bitmap;
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {

        }
        public void Save(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            ImageFormat format;
            switch (Path.GetExtension(path).ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    format = ImageFormat.Jpeg;
                    break;
                case ".gif":
                    format = ImageFormat.Gif;
                    break;
                case ".png":
                    format = ImageFormat.Png;
                    break;
                case ".tiff":
                    format = ImageFormat.Tiff;
                    break;
                default:
                    format = ImageFormat.Bmp;
                    break;
            }
            CurrentImage.Save(writer.BaseStream, format);
            writer.Close();
            this.ImagePath = path;
            Text = Path.GetFileName(path);
        }
    }
}
