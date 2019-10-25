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
    public partial class Histogram : Form
    {
        private int[,] values = new int[1, 256];
        private Color bg;
        const int offset = 4;
        int max = 0;
        int selected = -1;
        int scale = 256;
        int barWidth = 1;
        bool editable = false;
        private readonly Image _image;
        public Histogram()
        {
            InitializeComponent();
        }

        public Histogram(Image image)
        {
            _image = image;
            InitializeComponent();
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            var offset = 100;
            var max = 2;
            int x = offset;
            int y = 256;

            Graphics graphics = e.Graphics;
            graphics.Clear(BackColor);

            graphics.DrawLine(Pens.Black, new Point(offset - 1, offset + y), new Point(offset + 10 * 2, offset + y));
            graphics.DrawLine(Pens.Black, new Point(offset - 1, offset), new Point(offset - 1, offset + y));

            //if (max > 0)
            //{
            //    for (int i = 0; i < values.Length; i++)
            //    {
            //        Brush brush = Brushes.DarkKhaki;
            //        if (i % 2 != 0) brush = Brushes.DarkKhaki;
            //        if (i == selected)
            //            brush = Brushes.Yellow;
            //        int height = (int)(values[0, i] * scale / max);
            //        if (height > 0)
            //            graphics.FillRectangle(brush, new Rectangle(x + i * barWidth, y - height + offset, barWidth, height));
            //    }
            //}
        }

        public void Build()
        {
            if (_image != null)
            {
                var bmp = _image;
                values = new int[1, 255];

                for (int x = 0; x < bmp.Width; x++)
                    for (int y = 0; y < bmp.Height; y++)
                        values[0, 12]++;
            }

            max = 0;
            for (int i = 0; i < values.Length; i++)
                max = Math.Max(values[0, i], max);

            if (values.Length > 128) barWidth = 2;
            else if (values.Length > 64) barWidth = 3;
            else if (values.Length > 32) barWidth = 4;
            else if (values.Length > 16) barWidth = 8;
            else if (values.Length > 8) barWidth = 16;
            else if (values.Length > 4) barWidth = 32;
            else if (values.Length > 2) barWidth = 64;
            else barWidth = 128;

            ClientSize = new Size(offset + barWidth * values.Length + 80, 300);
            bufferedPanel.ClientSize = new Size(offset + barWidth * values.Length + 5, 270);

            bufferedPanel.Refresh();
        }
    }
}
