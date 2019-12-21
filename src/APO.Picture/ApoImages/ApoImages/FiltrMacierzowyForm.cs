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
    public partial class FiltrMacierzowyForm : Form
    {
        public FiltrMacierzowyForm()
        {
            InitializeComponent();
            sizeComboBox.SelectedIndex = 0;
        }

        public int Size 
        {
            get

            {
                var str = sizeComboBox.SelectedItem.ToString().Split('x');
                return int.Parse(str[0]);
            }
        }
        
        private void okButton_Click(object sender, EventArgs e)
        {
           
            DialogResult = DialogResult.OK;
        }

       

        private void sizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
