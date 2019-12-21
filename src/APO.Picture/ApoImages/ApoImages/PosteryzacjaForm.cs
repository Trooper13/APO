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
    public partial class PosteryzacjaForm : Form
    {
        public PosteryzacjaForm()
        {
            InitializeComponent();
        }

        public int N { get; set; }
        
        private void okButton_Click(object sender, EventArgs e)
        {
            N = Convert.ToInt32(nNumericUpDown.Value);
            DialogResult = DialogResult.OK;
        }
    }
}
