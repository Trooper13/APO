using APO.Picture.Extensions;
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
    public partial class TwoValuesUnaryOperationForm : Form
    {
        public delegate Bitmap myMethod(Bitmap bitmap, int firstValue, int secondValue);
        public NumericUpDown FirstNumericUpDownValue { get; set; }
        public NumericUpDown SecondNumericUpDownValue { get; set; }

        private ImageForm _imageForm;
        private Bitmap _currentImage;
        private Bitmap _orginalImage;
        private int[] _greyHistogramArray;
        private int[] _redHistogramArray;
        private int[] _greenHistogramArray;
        private int[] _blueHistogramArray;

        private myMethod _twoValuesUnaryOperationMethod;

        public TwoValuesUnaryOperationForm(ImageForm imageForm, string title, myMethod method)
        {
            InitializeComponent();
            _twoValuesUnaryOperationMethod = new myMethod(method);
            _imageForm = imageForm;
            _currentImage = imageForm.CurrentImage;
            _orginalImage = _currentImage;
            Text = imageForm.Text + "_" + title;
            DrawImageHistogram(_currentImage);
            pictureBoxImage.Image = _currentImage;
            FirstNumericUpDownValue = numericUpDown1;
            SecondNumericUpDownValue = numericUpDown2;
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

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            if (SecondNumericUpDownValue.Value <= FirstNumericUpDownValue.Value)
            {
                SecondNumericUpDownValue.Value = FirstNumericUpDownValue.Value + 1;
            }
            ReloadImageForm(_twoValuesUnaryOperationMethod(_orginalImage, (int)numericUpDown1.Value, (int)numericUpDown2.Value));
            //colorSlider1.Cursor. = (int) numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (SecondNumericUpDownValue.Value > FirstNumericUpDownValue.Value)
            {
                ReloadImageForm(_twoValuesUnaryOperationMethod(_orginalImage, (int)numericUpDown1.Value, (int)numericUpDown2.Value));
            }
            else
            {
                SecondNumericUpDownValue.Value = FirstNumericUpDownValue.Value + 1;
            }
        }
    }
}
