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
    public partial class ImageForm : Form
    {
        private Histogram histogram;

        public ImageForm()
        {
            histogram = new Histogram(pictureBox1.Image)
            InitializeComponent();
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            histogram.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
