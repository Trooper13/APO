using APO.Picture.Segmentation;
using APO.Segmentation.Extensions;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace APO.Segmentation
{
    /// <summary>
    /// Główne okno programu
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// Scieżka obrazu
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Obraz źródłowy
        /// </summary>
        public Bitmap CurrentImage { get; set; }

        /// <summary>
        /// Obraz wynikowy
        /// </summary>
        public Bitmap ResultImage { get; set; }

        public Main()
        {
            InitializeComponent();
            toolStripStatusLabel1.BorderSides = (((ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top) | ToolStripStatusLabelBorderSides.Right) | ToolStripStatusLabelBorderSides.Bottom);
            toolStripStatusLabel1.BorderStyle = Border3DStyle.Raised;
            toolStripStatusLabel1.BackColor = Color.White;
            toolStripStatusLabel1.Font = new Font("Fira Code Medium", 12f, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }

        /// <summary>
        /// Otwarcie obrazu
        /// </summary>
        /// <param name="file">Obraz</param>
        public void OnOpenFile(string file)
        {
            ImagePath = file;
            Text = "Reconstruct";
            Text += " - " + Path.GetFileName(file);
            CurrentImage = ConvertTo24bppRgb((Bitmap)Image.FromFile(ImagePath));
            pictureBox1.Image = CurrentImage;
            pictureBox1.SetPicturBoxSize(CurrentImage);
            pointsListBox.Items.Clear();
        }

        /// <summary>
        /// Konwersja do obrazu 24-bitowego
        /// </summary>
        /// <param name="orig"></param>
        /// <returns></returns>
        public Bitmap ConvertTo24bppRgb(Bitmap orig)
        {
            Bitmap clone = new Bitmap(orig.Width, orig.Height, PixelFormat.Format24bppRgb);

            if (orig.PixelFormat != PixelFormat.Format24bppRgb)
            {
                using (Graphics gr = Graphics.FromImage(clone))
                {
                    gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
                }
            }
            return clone;
        }

        /// <summary>
        /// Wyświetlenie informacji o pozycji myszy
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">mouse event</param>
        private void ViewMousePosition(object sender, MouseEventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                toolStripStatusLabel1.Text = "X: " + (pictureBox1.Image.Width * e.X / pictureBox1.Width).ToString() + " | Y: " + (pictureBox1.Image.Height * e.Y / pictureBox1.Height).ToString();
            }
        }

        /// <summary>
        /// Wczytanie obrazu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenImage(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Open Image";
                openFileDialog.Filter = "Image Files (*.bmp)|*.BMP";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OnOpenFile(openFileDialog.FileName);
                    Show();
                }
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Dodanie markera do listy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMarkerToList(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                warningLabel.Visible = false;
                pointsListBox.Items.Add(new Point((pictureBox1.Image.Width * e.X / pictureBox1.Width), (pictureBox1.Image.Height * e.Y / pictureBox1.Height)));
            }

            pictureBox1.Refresh();
        }

        /// <summary>
        /// Usuń zaznaczony punkt z listy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnePointDeleteButton_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Usuń wszystkie punkty z listy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllPointsDeleteButton_Click_1(object sender, EventArgs e)
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

        /// <summary>
        /// Resetuj obraz (wynikowy)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image = null;
                pictureBox2.Size = new Size(400, 400);
            }
        }

        /// <summary>
        /// Rekonstrukcja
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void ReconstructionButton_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Rysuj markery na obrazie
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event myszki</param>
        private void DrawMarkers(object sender, PaintEventArgs e)
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

        /// <summary>
        /// Zapisz obraz wynikowy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "bmp file(*.bmp)|*.bmp";
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox2.Image.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                    }
                }
            }
            else
            {
                MessageBox.Show("Brak obrazu do zapisania!", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Informacja o programie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "APLKACJA PROJEKTOWA" +

            "\nTemat: Zaimplementowanie operacji " +  
            @"rekonstrukcji morfologicznej 
            
            Autor: Mateusz Mitura 16426
            Prowadzący: dr hab. Korzyńska Anna
            Algorytmy Przetwarzania Obrazów 2019
            Inżynieria oprogramowania IZ07IO2", "Informacja o programie");
        }
    }
}
