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
    public partial class SkladanieMasekForm : Form
    {

        int[][,] set1 = new int[3][,]
            {
                new int[3, 3] { { 0, 1, 0 }, { 1, 4, 1 }, { 0, 1, 0 } },
                new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } },
                new int[3, 3] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } }
            };
        int[][,] set2 = new int[3][,]
            {
                new int[3, 3] { { 1, -2, 1 }, { -2, 5, -2 }, { 1, -2, 1 } },
               new int[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } },
                new int[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } }
            };

        public int[,] Mask { get; set; }

        public SkladanieMasekForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selected = set1[comboBox1.SelectedIndex];

            PrintMask(textBox1, selected);
            if(comboBox2.SelectedIndex != -1)
            {
                CalculateResult();
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selected = set2[comboBox2.SelectedIndex];

            PrintMask(textBox2, selected);
            if (comboBox1.SelectedIndex != -1)
            {
                CalculateResult();
            }
        }

        private void CalculateResult()
        {
            int[,] g =set1[comboBox1.SelectedIndex];
            int[,] f = set2[comboBox2.SelectedIndex];

            int[,] F = new int[7, 7];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    F[i + 2, j + 2] = f[i, j];
                }
            }

            int[,] m = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            m[i, j] += g[k, l] * F[i + k, j + l];
                        }
                    }

                }
            }

            Mask = m;
            button1.Enabled = true;
            PrintMask(textBox3, m);

        }

        private void PrintMask(TextBox textbox, int[,] mask)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < mask.GetLength(0); i++)
            {
                for (int j = 0; j < mask.GetLength(1); j++)
                {

                    sb.Append(mask[i, j]);
                    if (j < mask.GetLength(1) - 1)
                    {
                        sb.Append("\t");
                    }
                    else
                    {
                        sb.AppendLine();
                    }
                }

            }

            textbox.Text = sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
