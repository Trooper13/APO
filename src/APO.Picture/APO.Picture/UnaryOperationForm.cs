using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APO.Picture.Extensions;

namespace APO.Picture
{
    public partial class UnaryOperationForm : Form
    {
        public delegate Bitmap myMethod(Bitmap bitmap, int value);
        public NumericUpDown NumericUpDownValue  { get; set; }

        private ImageForm _imageForm;
        private Bitmap _currentImage;
        private Bitmap _orginalImage;
        private string _path;
        private int[] _greyHistogramArray;
        private int[] _redHistogramArray;
        private int[] _greenHistogramArray;
        private int[] _blueHistogramArray;

        private myMethod _unaryOperationMethod;

        public UnaryOperationForm(ImageForm imageForm, string title, myMethod method)
        {
            InitializeComponent();
            _unaryOperationMethod = new myMethod(method);
            _imageForm = imageForm;
            _currentImage = imageForm.CurrentImage;
            _orginalImage = _currentImage;
            _path = imageForm.ImagePath;
            Text = imageForm.Text + "_" + title;
            DrawImageHistogram(_currentImage);
            pictureBoxImage.Image = _currentImage;
            NumericUpDownValue = numericUpDown1;
        }

        private void DrawImageHistogram(Bitmap bitmap)
        {
            _greyHistogramArray = new Histogram(bitmap, "Grey").Levels;
            _redHistogramArray = new Histogram(bitmap, "R").Levels;
            _greenHistogramArray = new Histogram(bitmap, "G").Levels;
            _blueHistogramArray = new Histogram(bitmap, "B").Levels;

            Histogram.Draw(_greyHistogramArray, histogramViewGrey);
            Histogram.Draw(_redHistogramArray, histogramViewRed);
            Histogram.Draw(_greenHistogramArray, histogramViewGreen);
            Histogram.Draw(_blueHistogramArray, histogramViewBlue);
        }
        private void ReloadImageForm(Bitmap image)
        {
            DrawImageHistogram(image);
            pictureBoxImage.Image = image;
            _currentImage = image;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ReloadImageForm(_unaryOperationMethod(_orginalImage, (int)numericUpDown1.Value));
            //colorSlider1.Cursor. = (int) numericUpDown1.Value;
        }
        public void SaveTwo(string path)
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
            _currentImage.Save(writer.BaseStream, format);
            writer.Close();
            this._path = path;
            Text = Path.GetFileName(path);
        }
    }
}
