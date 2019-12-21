using APO.Picture.Data;
using OpenCvSharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using Size = System.Drawing.Size;


namespace APO.Picture
{
    public partial class PrewittForm : Form
    {
        private ImageForm _imageForm;
        private Bitmap _currentImage;

        public PrewittForm(ImageForm imageForm)
        {
            InitializeComponent();
            _imageForm = imageForm;
            _currentImage = imageForm.CurrentImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                myCalculatePrewitt(Masks.xPrewitt);
            }
            if (radioButton2.Checked)
            {
                myCalculatePrewitt(Masks.yPrewitt);
            }
            if (radioButton3.Checked)
            {
                myCalculatePrewitt(Masks.NWprewitt);
            }
            if (radioButton4.Checked)
            {
                myCalculatePrewitt(Masks.Sprewitt);
            }
            if (radioButton5.Checked)
            {
                myCalculatePrewitt(Masks.NEprewitt);
            }
            if (radioButton6.Checked)
            {
                myCalculatePrewitt(Masks.Wprewitt);
            }
            if (radioButton7.Checked)
            {
                myCalculatePrewitt(Masks.SWprewitt);
            }
            if (radioButton8.Checked)
            {
                myCalculatePrewitt(Masks.SEprewitt);
            }
        }

        private void myCalculatePrewitt(float[] mask)
        {
            var ksize = new Size(3, 3);
            var anchor = new OpenCvSharp.Point(-1, -1);
            Mat imageGrey = new Mat();

            Mat karnel = new Mat(3, 3, MatType.CV_32F, mask);

            Mat _image = OpenCvSharp.Extensions.BitmapConverter.ToMat(_currentImage);



            Mat imageInvert = new Mat(_currentImage.Width, _currentImage.Height, MatType.CV_8U);

            Cv2.Filter2D(_image, imageInvert, MatType.CV_8U, karnel, anchor);

            Bitmap result = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageInvert);

            pictureBox1.Image = result;
        }
    }
}
