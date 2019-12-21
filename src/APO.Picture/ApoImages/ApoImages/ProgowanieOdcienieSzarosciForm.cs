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
    public partial class ProgowanieOdcienieSzarosciForm : Form
    {
        public ProgowanieOdcienieSzarosciForm()
        {
            InitializeComponent();
        }

        public int P1 { get; set; }

        public int P2 { get; set; }
        public bool IsNegated { get; set; }



        private void okButton_Click(object sender, EventArgs e)
        {
            P1 = Convert.ToInt32(p1NumericUpDown.Value);
            P2 = Convert.ToInt32(p2numericUpDown.Value);
            IsNegated = negationcheckBox.Checked;
            DialogResult = DialogResult.OK;
        }

        private void p1NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            p2numericUpDown.Value = Math.Max(p2numericUpDown.Value, p1NumericUpDown.Value);
        }

        private void p2numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            p1NumericUpDown.Value = Math.Min(p2numericUpDown.Value, p1NumericUpDown.Value);
        }
    }
}
