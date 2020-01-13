using APO.Picture.Data;
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
using Size = OpenCvSharp.Size;

namespace APO.Picture
{
    public partial class NeighborhoodOperation : Form
    {
        private ImageForm _imageForm;
        private Bitmap _currentImage;

        public NeighborhoodOperation(ImageForm imageForm)
        {
            InitializeComponent();
            _imageForm = imageForm;
            _currentImage = imageForm.CurrentImage;
            pictureBox1.Image = _currentImage;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if((radioButton1.Checked || radioButton2.Checked || radioButton3.Checked) && (radioButton4.Checked || radioButton5.Checked || radioButton6.Checked))
            {
                float[] mask1 = new float[] { };
                float[] mask2 = new float[] { };

                if (radioButton1.Checked)
                    mask1 = Masks.SmoothMaskOne;

                if (radioButton2.Checked)
                    mask1 = Masks.SmoothMaskTwo;

                if (radioButton3.Checked)
                    mask1 = Masks.SmoothMaskThree;

                if (radioButton4.Checked)
                    mask2 = Masks.SharpMaskOne;

                if (radioButton5.Checked)
                    mask2 = Masks.SharpMaskTwo;

                if (radioButton6.Checked)
                    mask2 = Masks.SharpMaskThree;

                Bitmap resultImage = CalculateResult(_currentImage, mask1, mask2);

                pictureBox1.Image = resultImage;
            }
        }

        private Bitmap CalculateResult(Bitmap image, float[] mask1, float[] mask2)
        {
            float[] temp1 = new float[25];

            temp1[0] = 0;
            temp1[1] = 0;
            temp1[2] = 0;
            temp1[3] = 0;
            temp1[4] = 0;

            temp1[5] = 0;
            temp1[6] = mask1[0];
            temp1[7] = mask1[1];
            temp1[8] = mask1[2];
            temp1[9] = 0;

            temp1[10] = 0;
            temp1[11] = mask1[3];
            temp1[12] = mask1[4];
            temp1[13] = mask1[5];
            temp1[14] = 0;

            temp1[15] = 0;
            temp1[16] = mask1[6];
            temp1[17] = mask1[7];
            temp1[18] = mask1[8];
            temp1[19] = 0;

            temp1[20] = 0;
            temp1[21] = 0;
            temp1[22] = 0;
            temp1[23] = 0;
            temp1[24] = 0;

            Mat tempMask1 = new Mat(5, 5, MatType.CV_32F, temp1);
            Mat tempMask2 = new Mat(3, 3, MatType.CV_32F, mask2);

            Mat _image = OpenCvSharp.Extensions.BitmapConverter.ToMat(image);

            var ksize = new Size(5, 5);
            var anchor = new OpenCvSharp.Point(-1, -1);
            Mat kernel = new Mat(tempMask1.Rows, tempMask1.Cols, MatType.CV_8U);

            Cv2.Filter2D(tempMask1, kernel, -1, tempMask2);

            Scalar devider = kernel.Sum();
            Cv2.Multiply(kernel, new Scalar(1 / devider.Val0), kernel);

            Mat resultImage = new Mat();

            Cv2.Filter2D(_image, resultImage, -1, kernel, anchor);
            //Mat karnel = new Mat(5, 5, MatType.CV_32F, mask);

            Bitmap result = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(resultImage);

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = _currentImage;
        }
    }
}
