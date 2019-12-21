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
    public partial class IterationForm : Form
    {
        public IterationForm()
        {
            InitializeComponent();
        }

        public int Iterations
        {
            get
            {
                if (radioButton1.Checked)
                {
                    return 1;
                }
                if (radioButton2.Checked)
                {
                    return 2;
                }
                if (radioButton3.Checked)
                {
                    return 3;
                }
                if (radioButton4.Checked)
                {
                    return 5;
                }

                return 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
