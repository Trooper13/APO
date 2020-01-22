using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        private string _path;

        public SmoothForm(ImageForm imageForm, string title, myMethod method, float[] mask)
        {
            InitializeComponent();
            _lineOperationMethod = new myMethod(method);
            _path = imageForm.ImagePath;
            _imageForm = imageForm;
            _orginalImage = _currentImage;
            _currentImage = _lineOperationMethod(imageForm.CurrentImage, mask);
            Text = imageForm.Text + "_" + title;
            pictureBox2.Image = _currentImage;
        }

        public void Save(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            ImageFormat format;
            switch (Path.GetExtension(path).ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    format = ImageFormat.Jpeg;
                    break;
                case ".gif":
                    format = ImageFormat.Gif;
                    break;
                case ".png":
                    format = ImageFormat.Png;
                    break;
                case ".tiff":
                    format = ImageFormat.Tiff;
                    break;
                default:
                    format = ImageFormat.Bmp;
                    break;
            }
            _currentImage.Save(writer.BaseStream, format);
            writer.Close();
            this._path = path;
            Text = Path.GetFileName(path);
        }
    }
}
