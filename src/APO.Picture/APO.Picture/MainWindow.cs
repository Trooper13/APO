using APO.Picture.Extensions;
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Open Image";
                openFileDialog.Filter = "Image Files (*.bmp)|*.BMP";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenImage(openFileDialog.FileName);
                }

                Cursor = Cursors.Default;
            }
        }

        public void OpenImage(string file)
        {
            ImageForm imageForm = new ImageForm(file)
            {
                MdiParent = this
            };

            imageForm.Show();
        }

        public void CopyImageForm(ImageForm form, Bitmap bitmap)
        {
            int copyId = ++form.CopyId;
            foreach (Form child in MdiChildren)
            {
                if (child is ImageForm imageForm)
                {
                    if (imageForm.ImagePath.Contains(form.ImagePath))
                    {
                        imageForm.CopyId = copyId;
                    }
                }
            }
            ImageForm copyForm = new ImageForm(form, bitmap)
            {
                MdiParent = this
            };
            // TODO: do zrobienia zachowanie aktywności "SAVE AS" po otwarciu zdjęcia
            //OnImageOpen();
            copyForm.Show();
        }

        #region Labo 2: Rozciąganie i Equalizacja (Wyrównywanie)

        private void rozciaganieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                CopyImageForm(imageForm, Histogram.Stretch(imageForm.CurrentImage, imageForm.GreyHistogramArray, imageForm.RedHistogramArray, imageForm.GreenHistogramArray, imageForm.BlueHistogramArray));
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void metodaŚrednichToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                CopyImageForm(imageForm, Histogram.Equalization(imageForm.CurrentImage, imageForm.GreyHistogramArray));
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Labo 2: Negacja, progowanie, posteryzacja, rozciąganie
        private void lAB2NegacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                CopyImageForm(imageForm, MyBitmap.Negative(imageForm.CurrentImage));
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lAB2ProgowanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                UnaryOperationForm unaryForm = new UnaryOperationForm(imageForm, "Progowanie", MyBitmap.Tresholding)
                {
                    MdiParent = this
                };
                unaryForm.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

    }
}
