using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO.Segmentation
{
    public partial class Main : Form
    {
        public string ImagePath { get; set; }
        public Bitmap CurrentImage { get; set; }
        public int CopyId { get; set; } = 0;
        public string TitleText { get; set; } = "";

        public Main()
        {
            InitializeComponent();
            toolStripStatusLabel1.BorderSides = (((ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top) | ToolStripStatusLabelBorderSides.Right) | ToolStripStatusLabelBorderSides.Bottom);
            toolStripStatusLabel1.BorderStyle = Border3DStyle.Raised;
            toolStripStatusLabel1.BackColor = Color.White;
            toolStripStatusLabel1.Font = new Font("Fira Code Medium", 12f, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }

        public void onOpenFile(string file)
        {
            ImagePath = file;
            Text = Path.GetFileName(file);
            CurrentImage = (Bitmap)Image.FromFile(ImagePath);
            pictureBox1.Image = CurrentImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                Bitmap b = new Bitmap(pictureBox1.Image);
                toolStripStatusLabel1.Text = "X: " + (b.Width * e.X / pictureBox1.Width).ToString() + " | Y: " + (b.Width * e.Y / pictureBox1.Height).ToString();

            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Open Image";
                openFileDialog.Filter = "Image Files (*.bmp)|*.BMP";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    onOpenFile(openFileDialog.FileName);
                    Show();
                }

                Cursor = Cursors.Default;
            }
        }
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap b = new Bitmap(pictureBox1.Image);
                pointsListBox.Items.Add(new Point((b.Width * e.X / pictureBox1.Width), (b.Width * e.Y / pictureBox1.Height)));
            }
        }

        private void onePointDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void allPointsDeleteButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
