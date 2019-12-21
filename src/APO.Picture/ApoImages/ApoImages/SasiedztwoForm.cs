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
    public partial class SasiedztwoForm : Form
    {
        int[] dxDiamond = { -1, 0, 1, 0, 0 };

        int[] dyDiamond = { 0, 1, 0, -1, 0 };

        int[] dxSquare = { -1, 0, 1, 0, 0, 1, 1, -1, -1 };
        int[] dySquare = { 0, 1, 0, -1, 0, 1, -1, 1, -1 };

        public SasiedztwoForm()
        {
            InitializeComponent();
        }

        public int[] Dx { get { return diamondRadioButton.Checked ? dxDiamond : dxSquare; } }

        public int[] Dy { get { return diamondRadioButton.Checked ? dyDiamond : dySquare; } }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
