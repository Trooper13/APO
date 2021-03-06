﻿using APO.Picture.Data;
using OpenCvSharp;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Size = System.Drawing.Size;

namespace APO.Picture
{
    public partial class SobelForm : Form
    {
        private ImageForm _imageForm;
        private string _path;
        private Bitmap _currentImage;

        public SobelForm(ImageForm imageForm)
        {
            InitializeComponent();
            _imageForm = imageForm;
            _path = imageForm.ImagePath;
            _currentImage = imageForm.CurrentImage;
            //pictureBox1.Image = _currentImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                calculateSobel(0, 1);
            }
            if (radioButton2.Checked)
            {
                calculateSobel(1, 0);
            }
            if (radioButton3.Checked)
            {
                myCalculateSobel(Masks.NWmask);
            }
            if (radioButton4.Checked)
            {
                myCalculateSobel(Masks.Nmask);
            }
            if (radioButton5.Checked)
            {
                myCalculateSobel(Masks.NEmask);
            }
            if (radioButton6.Checked)
            {
                myCalculateSobel(Masks.Wmask);
            }
            if (radioButton7.Checked)
            {
                myCalculateSobel(Masks.SWmask);
            }
            if (radioButton8.Checked)
            {
                myCalculateSobel(Masks.SEmask);
            }

        }

        private void calculateSobel(int v1, int v2)
        {
            Mat _image = OpenCvSharp.Extensions.BitmapConverter.ToMat(_currentImage);
            Mat imageInvert = new Mat(_currentImage.Width, _currentImage.Height, MatType.CV_8U);

            Cv2.Sobel(_image, imageInvert, MatType.CV_8U, v1, v2);

            Bitmap result = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageInvert);

            panAndZoomPictureBox1.Image = result;
        }

        private void myCalculateSobel(float[] mask)
        {
            var ksize = new Size(3, 3);
            var anchor = new OpenCvSharp.Point(-1, -1);
            Mat imageGrey = new Mat();

            Mat karnel = new Mat(3, 3, MatType.CV_32F, mask);

            Mat _image = OpenCvSharp.Extensions.BitmapConverter.ToMat(_currentImage);



            Mat imageInvert = new Mat(_currentImage.Width, _currentImage.Height, MatType.CV_8U);

            Cv2.Filter2D(_image, imageInvert, MatType.CV_8U, karnel, anchor);

            Bitmap result = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageInvert);

            panAndZoomPictureBox1.Image = result;
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
            panAndZoomPictureBox1.Image.Save(writer.BaseStream, format);
            writer.Close();
            this._path = path;
            Text = Path.GetFileName(path);
        }
    }
}
