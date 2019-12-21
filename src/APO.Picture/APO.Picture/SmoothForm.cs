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
    public partial class SmoothForm : Form
    {
        public delegate Bitmap myMethod(Bitmap bitmap, float[] mask);

        private ImageForm _imageForm;
        private Bitmap _currentImage;
        private Bitmap _orginalImage;

        private myMethod _lineOperationMethod;

        public SmoothForm(ImageForm imageForm, string title, myMethod method, float[] mask)
        {
            InitializeComponent();
            _lineOperationMethod = new myMethod(method);
            _imageForm = imageForm;
            _orginalImage = _currentImage;
            _currentImage = _lineOperationMethod(imageForm.CurrentImage, mask);
            Text = imageForm.Text + "_" + title;
            pictureBox2.Image = _currentImage;
        }
    }
}
