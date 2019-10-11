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
    public partial class MainWindow : Form
    {
        private ImageForm imageForm = new ImageForm();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imageForm.pictureBox1.Image = 
                }
            }
        }

    }
}
