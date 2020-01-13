using System;
using System.Windows.Forms;

namespace APO.Picture
{
    public partial class SmoothParamForm : Form
    {
        public int Param
        {
            get
            {
                return Convert.ToInt32(textBox2.Text);
            }
        }

        public SmoothParamForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
