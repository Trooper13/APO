using OpenCvSharp;
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
    public partial class SmoothMedianForm : Form
    {
        private ImageForm _imageForm;
        private Bitmap _currentImage;

        public SmoothMedianForm(ImageForm imageForm)
        {
            InitializeComponent();
            _imageForm = imageForm;
            _currentImage = imageForm.CurrentImage;
            pictureBox2.Image = _currentImage;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                calculateMedianBlur(3);
            }

            if (radioButton2.Checked)
            {
                calculateMedianBlur(5);
            }

            if (radioButton3.Checked)
            {
                calculateMedianBlur(7);
            }

            if (radioButton4.Checked)
            {
                calculateMedianBlur(9);
            }

            if (radioButton5.Checked)
            {
                calculateMedianBlur(11);
            }
        }

        private void calculateMedianBlur(int ksize)
        {
            Mat _image = OpenCvSharp.Extensions.BitmapConverter.ToMat(_currentImage);
            Mat imageInvert = new Mat(_currentImage.Width, _currentImage.Height, MatType.CV_8U);

            Cv2.MedianBlur(_image, imageInvert, ksize);

            Bitmap result = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageInvert);

            pictureBox1.Image = result;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}
