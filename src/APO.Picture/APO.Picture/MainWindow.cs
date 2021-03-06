﻿using APO.Picture.Data;
using APO.Picture.Segmentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.IO;

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

        private void lAB2ProgowaniezachowaniePoziomówSzarościToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                TwoValuesUnaryOperationForm unaryForm = new TwoValuesUnaryOperationForm(imageForm, "ProgowanieZzachowaniemOdcieniSzarosci", MyBitmap.ThresholdingSaveGreyScale)
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

        private void lAB2PosteryzacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                UnaryOperationForm unaryForm = new UnaryOperationForm(imageForm, "Posteryzacja", MyBitmap.Reduction)
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

        private void lAB2RozciaganieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                TwoValuesUnaryOperationForm unaryForm = new TwoValuesUnaryOperationForm(imageForm, "ProgowanieZzachowaniemOdcieniSzarosci", MyBitmap.Stretching)
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

        //Filtry wygładzające
        private void lAB2UniwersalnyOperatorJednopunktowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageForm form = (ImageForm)ActiveMdiChild;
            UopForm dialog = new UopForm(form.CurrentImage);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                form.CurrentImage = dialog.Bitmap;
                Cursor = Cursors.Default;
            }
        }

        private void maska1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ActiveMdiChild is ImageForm imageForm)
            {
                SmoothForm smoothForm = new SmoothForm(imageForm, "WygładzanieLinioweMaska1", MyBitmap.SmoothMask, Masks.SmoothMaskOne)
                {
                    MdiParent = this
                };
                smoothForm.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void maska2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                SmoothForm smoothForm = new SmoothForm(imageForm, "WygładzanieLinioweMaska2", MyBitmap.SmoothMask, Masks.SmoothMaskTwo)
                {
                    MdiParent = this
                };
                smoothForm.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void maska3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                SmoothForm smoothForm = new SmoothForm(imageForm, "WygładzanieLinioweMaska3", MyBitmap.SmoothMask, Masks.SmoothMaskThree)
                {
                    MdiParent = this
                };
                smoothForm.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void maska4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int k;
            using (var form = new SmoothParamForm())
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                k = form.Param;
            }

            if (ActiveMdiChild is ImageForm imageForm)
            {
                SmoothForm smoothForm = new SmoothForm(imageForm, "WygładzanieLinioweMaska4", MyBitmap.SmoothMask, Masks.GetMyMask(k))
                {
                    MdiParent = this
                };
                smoothForm.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Detekcja Krawędzi
        private void mask1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                SmoothForm smoothForm = new SmoothForm(imageForm, "DetekcjaKrawedziMaska1", MyBitmap.SharpAndEdgeMask, Masks.EdgeMaskOne)
                {
                    MdiParent = this
                };
                smoothForm.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mask2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                SmoothForm smoothForm = new SmoothForm(imageForm, "DetekcjaKrawedziMaska2", MyBitmap.SharpAndEdgeMask, Masks.EdgeMaskTwo)
                {
                    MdiParent = this
                };
                smoothForm.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mask3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                SmoothForm smoothForm = new SmoothForm(imageForm, "DetekcjaKrawedziMaska3", MyBitmap.SharpAndEdgeMask, Masks.EdgeMaskThree)
                {
                    MdiParent = this
                };
                smoothForm.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Filtry wyostrzające
        private void maska1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                SmoothForm smoothForm = new SmoothForm(imageForm, "WyostrzanieMaska1", MyBitmap.SharpAndEdgeMask, Masks.SharpMaskOne)
                {
                    MdiParent = this
                };
                smoothForm.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void maska2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                SmoothForm smoothForm = new SmoothForm(imageForm, "WyostrzanieMaska2", MyBitmap.SharpAndEdgeMask, Masks.SharpMaskTwo)
                {
                    MdiParent = this
                };
                smoothForm.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void maska3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                SmoothForm smoothForm = new SmoothForm(imageForm, "WyostrzanieMaska3", MyBitmap.SharpAndEdgeMask, Masks.SharpMaskThree)
                {
                    MdiParent = this
                };
                smoothForm.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void filtrowanieMedianoweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                SmoothMedianForm form = new SmoothMedianForm(imageForm)
                {
                    MdiParent = this
                };
                form.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                SobelForm form = new SobelForm(imageForm)
                {
                    MdiParent = this
                };
                form.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void prewittToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                PrewittForm form = new PrewittForm(imageForm)
                {
                    MdiParent = this
                };
                form.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void robertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                Roberts form = new Roberts(imageForm)
                {
                    MdiParent = this
                };
                form.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void erozjaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void czterosasiedztwoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i;
            using (var form = new IterationForm())
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                i = form.Iterations;
            }

            if (ActiveMdiChild is ImageForm imageForm)
            {
                CopyImageForm(imageForm, MorfologicOperations.Erosion(imageForm.CurrentImage, 0, i));
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ośmiosasiedztwoKwadratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i;
            using (var form = new IterationForm())
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                i = form.Iterations;
            }

            if (ActiveMdiChild is ImageForm imageForm)
            {
                CopyImageForm(imageForm, MorfologicOperations.Erosion(imageForm.CurrentImage, 1, i));
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void czterosasiedztwoRombToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i;
            using (var form = new IterationForm())
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                i = form.Iterations;
            }

            if (ActiveMdiChild is ImageForm imageForm)
            {
                CopyImageForm(imageForm, MorfologicOperations.Dilate(imageForm.CurrentImage, 0, i));
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ośmiosasiedztwoKwadratToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i;
            using (var form = new IterationForm())
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                i = form.Iterations;
            }

            if (ActiveMdiChild is ImageForm imageForm)
            {
                CopyImageForm(imageForm, MorfologicOperations.Dilate(imageForm.CurrentImage, 1, i));
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Otwarcie
        private void czterosasiedztwoRombToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                CopyImageForm(imageForm, MorfologicOperations.Open(imageForm.CurrentImage, 0));
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void osmiosasiedztwoKwadratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                CopyImageForm(imageForm, MorfologicOperations.Open(imageForm.CurrentImage, 1));
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Zamknięcie
        private void czterosasiedztwoRombToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                CopyImageForm(imageForm, MorfologicOperations.Close(imageForm.CurrentImage, 0));
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void osmiosasiedztwoKwadratToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                CopyImageForm(imageForm, MorfologicOperations.Close(imageForm.CurrentImage, 1));
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void szkieletyzacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                CopyImageForm(imageForm, MorfologicOperations.Skeleton(imageForm.CurrentImage, 0));
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void operacjeSasiedztwaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
               NeighborhoodOperation form = new NeighborhoodOperation(imageForm)
                {
                    MdiParent = this
                };
                form.Show();
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "jpg file(*.jpg)|*.jpg|jpeg file(*.jpeg)|*.jpeg|" +
                                        "png file(*.png)|*.png|bmp file(*.bmp)|*.bmp|tiff file(*.tiff)|*.tiff";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageForm form = (ImageForm)ActiveMdiChild;
                    form.Save(saveFileDialog.FileName);
                }
            }
        }

        private void wektorCechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                MyBitmap.WektorCech(imageForm.FastImage);
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void save2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "jpg file(*.jpg)|*.jpg|jpeg file(*.jpeg)|*.jpeg|" +
                                        "png file(*.png)|*.png|bmp file(*.bmp)|*.bmp|tiff file(*.tiff)|*.tiff";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    UnaryOperationForm form = (UnaryOperationForm)ActiveMdiChild;
                    form.SaveTwo(saveFileDialog.FileName);
                }
            }
        }

        private void savemaskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "jpg file(*.jpg)|*.jpg|jpeg file(*.jpeg)|*.jpeg|" +
                                        "png file(*.png)|*.png|bmp file(*.bmp)|*.bmp|tiff file(*.tiff)|*.tiff";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SmoothForm form = (SmoothForm)ActiveMdiChild;
                    form.Save(saveFileDialog.FileName);
                }
            }
        }

        private void savemedianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "jpg file(*.jpg)|*.jpg|jpeg file(*.jpeg)|*.jpeg|" +
                                        "png file(*.png)|*.png|bmp file(*.bmp)|*.bmp|tiff file(*.tiff)|*.tiff";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SmoothMedianForm form = (SmoothMedianForm)ActiveMdiChild;
                    form.Save(saveFileDialog.FileName);
                }
            }
        }

        private void saveSobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "jpg file(*.jpg)|*.jpg|jpeg file(*.jpeg)|*.jpeg|" +
                                        "png file(*.png)|*.png|bmp file(*.bmp)|*.bmp|tiff file(*.tiff)|*.tiff";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SobelForm form = (SobelForm)ActiveMdiChild;
                    form.Save(saveFileDialog.FileName);
                }
            }
        }

        private void projektToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ImageForm imageForm)
            {
                CopyImageForm(imageForm, MyBitmap.Projekt(imageForm.CurrentImage, new Point(150,150)));
            }
            else
            {
                MessageBox.Show("Wybierz poprawny obraz!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
