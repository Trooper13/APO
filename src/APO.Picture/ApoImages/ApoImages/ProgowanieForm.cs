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
    public partial class ProgowanieForm : Form
    {
        public ProgowanieForm()
        {
            InitializeComponent();
        }

        public int P1 { get; set; }

        private void okButton_Click(object sender, EventArgs e)
        {
            P1 = Convert.ToInt32(p1NumericUpDown.Value);
            DialogResult = DialogResult.OK;
        }
    }
}
