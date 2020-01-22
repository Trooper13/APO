using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace APO.Picture.Extensions
{
    public class FastBitmap : IDisposable, ICloneable
    {
        public delegate void PixelChangedDelegate(Point position);

        private BitmapData bitmapData;

        public FastBitmap(int width, int height)
        {
            Init(width, height, 256, null, null);
        }

        public FastBitmap(int width, int height, int levels)
        {
            Bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            Bitmap.SetResolution(Bitmap.HorizontalResolution, Bitmap.VerticalResolution);
            Levels = levels;

            var pal = Bitmap.Palette;
            var param1 = (float)255 / (levels - 1);
            for (var i = 0; i < levels; i++)
            {
                var color = (byte)(param1 * i);
                pal.Entries[i] = Color.FromArgb(color, color, color);
            }

            Bitmap.Palette = pal;

            Lock();
        }

        public FastBitmap(Bitmap bmp)
        {
            if (bmp == null)
                throw new ArgumentNullException("bitmap");
            Init(bmp.Width, bmp.Height, 256, bmp, null);
        }

        public FastBitmap(FastBitmap bmp)
        {
            if (bmp == null)
                throw new ArgumentNullException("bitmap");
            Bitmap = (Bitmap)bmp.Bitmap.Clone();
            Bitmap.SetResolution(Bitmap.HorizontalResolution, Bitmap.VerticalResolution);
            Bitmap.Palette = bmp.Palette;
            Levels = bmp.Levels;
            Lock();
        }

        public FastBitmap(FastBitmap bmp, Rectangle src)
        {
            if (bmp == null)
                throw new ArgumentNullException("bitmap");

            Bitmap = new Bitmap(src.Width, src.Height, PixelFormat.Format8bppIndexed);
            Bitmap.SetResolution(Bitmap.HorizontalResolution, Bitmap.VerticalResolution);
            Levels = bmp.Levels;
            Bitmap.Palette = bmp.Palette;

            Lock();

            unsafe
            {
                if (bmp != null)
                {
                    var pPixel = (byte*)bitmapData.Scan0;
                    for (var y = 0; y < Bitmap.Height; y++)
                    {
                        for (var x = 0; x < Bitmap.Width; x++) pPixel[x] = bmp[x + src.X, y + src.Y];
                        pPixel += bitmapData.Stride;
                    }
                }
            }
        }

        public Bitmap Bitmap { get; set; }

        public int Width => Bitmap.Width;

        public int Height => Bitmap.Height;

        public Size Size => new Size(Width, Height);

        public int Levels { get; private set; } = 256;

        public byte this[int x, int y]
        {
            get
            {
                while (x < 0)
                    x += Width;
                while (x >= Width)
                    x -= Width;
                while (y < 0)
                    y += Height;
                while (y >= Height)
                    y -= Height;

                unsafe
                {
                    var ptr = (byte*)bitmapData.Scan0 + y * bitmapData.Stride + x;
                    return *ptr;
                }
            }
            set
            {
                while (x < 0)
                    x += Width;
                while (x >= Width)
                    x -= Width;
                while (y < 0)
                    y += Height;
                while (y >= Height)
                    y -= Height;

                unsafe
                {
                    var ptr = (byte*)bitmapData.Scan0 + y * bitmapData.Stride + x;
                    *ptr = value;
                }

                if (PixelChanged != null)
                    PixelChanged(new Point(x, y));
            }
        }

        public ColorPalette Palette
        {
            get => Bitmap.Palette;
            set => Bitmap.Palette = value;
        }

        public object Clone()
        {
            Unlock();
            var bmp = new FastBitmap(this);
            Lock();
            return bmp;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public event PixelChangedDelegate PixelChanged;

        public void Posterize(int levels, ColorPalette palette)
        {
            Levels = levels;
            Bitmap.Palette = palette;
        }

        public unsafe void Init(int width, int height, int levels, Bitmap bmp, ColorPalette palette)
        {
            Bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            Bitmap.SetResolution(Bitmap.HorizontalResolution, Bitmap.VerticalResolution);
            Levels = levels;

            if (palette == null)
            {
                var pal = Bitmap.Palette;
                for (var i = 0; i < pal.Entries.Length; i++)
                    pal.Entries[i] = Color.FromArgb(i, i, i);
                Bitmap.Palette = pal;
            }
            else
            {
                Bitmap.Palette = palette;
            }

            Lock();

            if (bmp != null)
            {
                var pPixel = (byte*)bitmapData.Scan0;
                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        var clr = bmp.GetPixel(x, y);
                        var byPixel = (byte)((30 * clr.R + 59 * clr.G + 11 * clr.B) / 100);
                        pPixel[x] = byPixel;
                    }

                    pPixel += bitmapData.Stride;
                }
            }
        }

        public void Draw(Graphics graphics, int x, int y)
        {
            Unlock();
            graphics.DrawImage(Bitmap, x, y);
            Lock();
        }

        public void Draw(Graphics graphics, int x, int y, int width, int height)
        {
            Unlock();
            graphics.DrawImage(Bitmap, x, y, width, height);
            Lock();
        }

        public void Draw(Graphics graphics, int x, int y, Rectangle src)
        {
            Unlock();
            graphics.DrawImage(Bitmap, x, y, src, GraphicsUnit.Pixel);
            Lock();
        }

        public void Save(Stream stream, ImageFormat format)
        {
            Bitmap.Save(stream, format);
        }

        public void Lock()
        {
            if (bitmapData != null)
                return;

            bitmapData = Bitmap.LockBits(new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), ImageLockMode.ReadWrite,
                PixelFormat.Format8bppIndexed);
        }

        public Bitmap Unlock()
        {
            if (bitmapData == null)
                return Bitmap;

            Bitmap.UnlockBits(bitmapData);
            bitmapData = null;

            return Bitmap;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Unlock();

                if (Bitmap != null)
                    Bitmap.Dispose();
            }

            bitmapData = null;
            Bitmap = null;
        }

        public Graphics CreateGraphics()
        {
            return Graphics.FromImage(Bitmap);
        }
    }
}