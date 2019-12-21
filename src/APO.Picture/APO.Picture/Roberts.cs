using APO.Picture.Data;
using OpenCvSharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using Size = System.Drawing.Size;

namespace APO.Picture
{
    public partial class Roberts : Form
    {
        private ImageForm _imageForm;
        private Bitmap _currentImage;

        public Roberts(ImageForm imageForm)
        {
            InitializeComponent();
            _imageForm = imageForm;
            _currentImage = imageForm.CurrentImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                myCalculateRoberts(Masks.NWroberts);
            }
            if (radioButton2.Checked)
            {
                myCalculateRoberts(Masks.SEroberts);
            }
        }

        private void myCalculateRoberts(float[] mask)
        {
            var ksize = new Size(2, 2);
            //var anchor = new OpenCvSharp.Point(-1, -1);
            Mat imageGrey = new Mat();

            Mat karnel = new Mat(2, 2, MatType.CV_32F, mask);

            Mat _image = OpenCvSharp.Extensions.BitmapConverter.ToMat(_currentImage);



            Mat imageInvert = new Mat(_currentImage.Width, _currentImage.Height, MatType.CV_8U);

            Cv2.Filter2D(_image, imageInvert, MatType.CV_8U, karnel);

            Bitmap result = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageInvert);

            pictureBox1.Image = result;
        }
    }
}
