using APO.Picture.Data;
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
                float[] mask1, mask2;

                if (radioButton1.Checked)
                    mask1 = Masks.SmoothMaskOne;

                if (radioButton2.Checked)
                    mask1 = Masks.SmoothMaskTwo;

                if (radioButton2.Checked)
                    mask1 = Masks.SmoothMaskThree;

                if (radioButton4.Checked)
                    mask2 = Masks.SharpMaskOne;

                if (radioButton2.Checked)
                    mask2 = Masks.SharpMaskTwo;

                if (radioButton2.Checked)
                    mask2 = Masks.SharpMaskThree;



            }
        }

        private void CalculateResult(float[] mask1, float[] mask2)
        {
            //float[] m = new float[] { };

            //for (int i = 0; i < 26; ++i)
            //{
            //    m[i]
            //}

        }
    }
}
