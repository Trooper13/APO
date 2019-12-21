using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApoImages
{
    public partial class HistogramForm : Form
    {
        public HistogramForm(int[] blackAndWhite)
        {
            InitializeComponent();
            pictureBoxR.Image = CreateHistogram(blackAndWhite, pictureBoxR.Height, Pens.Black);
            pictureBoxG.Visible = false;
            pictureBoxB.Visible = false;
            Width = Width / 3;
        }

        public HistogramForm(int[] r, int[] g, int[] b)
        {
            InitializeComponent();

            pictureBoxR.Image = CreateHistogram(r, pictureBoxR.Height, Pens.Red);
            pictureBoxG.Image = CreateHistogram(g, pictureBoxG.Height, Pens.Green);
            pictureBoxB.Image = CreateHistogram(b, pictureBoxB.Height, Pens.Blue);
        }

        Image CreateHistogram(int[] values, int size, Pen pen)
        {
            int maxValue = values.Max();
            Bitmap bitmap = new Bitmap(256, size);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
                if(maxValue == 0)
                {
                    return bitmap;
                }
                for (int i = 0; i < 256; i++)
                {
                    int point = (values[i] * size) / maxValue;
                    graphics.DrawLine(pen, i, size - 1, i, size - 1 - point);
                }
            }

            return bitmap;
        }

    }
}
