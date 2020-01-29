using APO.Picture.Segmentation;
using APO.Segmentation.Extensions;
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
        public Bitmap ResultImage { get; set; }
        public int CopyId { get; set; } = 0;

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
            Text += " - " + Path.GetFileName(file);
            CurrentImage = (Bitmap)Image.FromFile(ImagePath);
            pictureBox1.Image = CurrentImage;
            pictureBox1.SetPicturBoxSize(CurrentImage);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                toolStripStatusLabel1.Text = "X: " + (pictureBox1.Image.Width * e.X / pictureBox1.Width).ToString() + " | Y: " + (pictureBox1.Image.Height * e.Y / pictureBox1.Height).ToString();

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
                warningLabel.Visible = false;
                pointsListBox.Items.Add(new Point((pictureBox1.Image.Width * e.X / pictureBox1.Width), (pictureBox1.Image.Height * e.Y / pictureBox1.Height)));
            }

            pictureBox1.Refresh();
        }

        private void onePointDeleteButton_Click(object sender, EventArgs e)
        {
            if (pointsListBox.Items.Count > 0 && pointsListBox.SelectedItems.Count > 0)
            {
                var selectedItemId = pointsListBox.SelectedIndex;
                pointsListBox.Items.RemoveAt(selectedItemId);
                warningLabel.Visible = false;
            }
            else if(pictureBox1.Image != null)
            {
                warningLabel.Visible = true;
                warningLabel.Text = "* Nie wybrano punktu do usunięcia!";
            }

            pictureBox1.Refresh();
        }

        private void allPointsDeleteButton_Click_1(object sender, EventArgs e)
        {
            if (pointsListBox.Items.Count > 0)
            {
                pointsListBox.Items.Clear();
                warningLabel.Visible = false;
            }
            else if (pictureBox1.Image != null)
            {
                warningLabel.Visible = true;
                warningLabel.Text = "* Brak punktów do usunięcia!";
            }

            pictureBox1.Refresh();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            pictureBox2.Size = new Size(400, 400);
        }

        private void reconstructionButton_Click(object sender, EventArgs e)
        {
            if (pointsListBox.Items.Count > 0)
            {
                warningLabel.Visible = false;
                pictureBox2.Image = ResultImage = CurrentImage.Reconstruction(pointsListBox.Items.Cast<Point>().ToList());
                pictureBox2.SetPicturBoxSize(ResultImage);
            }
            else
            {
                warningLabel.Visible = true;
                warningLabel.Text = "* Nie wybrano żadnego punktu, nie można przeprowadzić rekonstrukcji!";
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen redPen = new Pen(Color.Red, 2);

            foreach (Point p in pointsListBox.Items.Cast<Point>().ToList())
            {
                Point pt1 = new Point(p.X * pictureBox1.Width / pictureBox1.Image.Width, (p.Y * pictureBox1.Height / pictureBox1.Image.Height) - 10);
                Point pt2 = new Point(p.X * pictureBox1.Width / pictureBox1.Image.Width, (p.Y * pictureBox1.Height / pictureBox1.Image.Height) + 10);
                Point pt3 = new Point((p.X * pictureBox1.Width / pictureBox1.Image.Width) - 10, (p.Y * pictureBox1.Height / pictureBox1.Image.Height));
                Point pt4 = new Point((p.X * pictureBox1.Width / pictureBox1.Image.Width) + 10, (p.Y * pictureBox1.Height / pictureBox1.Image.Height));
                g.DrawLine(redPen, pt1, pt2);
                g.DrawLine(redPen, pt3, pt4);
            }
        }
    }
}
