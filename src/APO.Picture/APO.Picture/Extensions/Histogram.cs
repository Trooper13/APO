using System;
using System.Drawing;
using System.Drawing.Imaging;
using Accord.Controls;
using HistogramAccord = Accord.Statistics.Visualizations.Histogram;
using Accord.Imaging;

namespace APO.Picture.Extensions
{
    public class Histogram
    {
        public int MaxPixels { get; } = 0;
        public int MaxLevel { get; } = 0;
        public int MinLevel { get; } = 255;
        public int[] Levels { get; } = new int[256];
        private Color Color;
        private int _level;

        public Histogram(Bitmap image, string canal)
        {
            for (int y = 0; y < image.Height; ++y)
            {
                for (int x = 0; x < image.Width; ++x)
                {
                    switch (canal)
                    {
                        case "Grey":
                            Color = image.GetPixel(x, y);
                            _level = (int)(Color.R + Color.G + Color.B)/3;
                            Levels[_level]++;
                            MaxPixels = Math.Max(MaxPixels, Levels[_level]);
                            MaxLevel = Math.Max(MaxLevel, _level);
                            MinLevel = Math.Min(MinLevel, _level);
                            break;

                        case "R":
                            Color = image.GetPixel(x, y);
                            _level = Color.R;
                            Levels[_level]++;
                            MaxPixels = Math.Max(MaxPixels, Levels[_level]);
                            MaxLevel = Math.Max(MaxLevel, _level);
                            MinLevel = Math.Min(MinLevel, _level);
                            break;

                        case "G":
                            Color = image.GetPixel(x, y);
                            _level = Color.G;
                            Levels[_level]++;
                            MaxPixels = Math.Max(MaxPixels, Levels[_level]);
                            MaxLevel = Math.Max(MaxLevel, _level);
                            MinLevel = Math.Min(MinLevel, _level);
                            break;

                        case "B":
                            Color = image.GetPixel(x, y);
                            _level = Color.B;
                            Levels[_level]++;
                            MaxPixels = Math.Max(MaxPixels, Levels[_level]);
                            MaxLevel = Math.Max(MaxLevel, _level);
                            MinLevel = Math.Min(MinLevel, _level);
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        public static void Draw(int[] histArray, HistogramView histogramView)
        {
            HistogramAccord histogram = new HistogramAccord(histArray);
            histogramView.TrackBar.Visible = false;
            histogramView.Graph.IsEnableWheelZoom = false;
            histogramView.Graph.IsEnableZoom = false;
            histogramView.Histogram = histogram;
            

            string[] labels = new string[histogram.Values.Length];
            for (int i = 0; i < histogram.Values.Length; ++i)
            {
                labels[i] = i.ToString();
            }
            histogramView.Graph.GraphPane.Title.IsVisible = false;
            histogramView.Graph.GraphPane.YAxis.Title.IsVisible = false;
            histogramView.Graph.GraphPane.YAxis.Scale.Mag = 0;
            histogramView.Graph.GraphPane.XAxis.Scale.TextLabels = labels;
            histogramView.Graph.GraphPane.XAxis.Scale.Min = histogram.Min;
            histogramView.Graph.GraphPane.XAxis.Scale.Max = histogram.Max;
            histogramView.Graph.GraphPane.XAxis.Scale.MajorStep = 5;
        }

        /* ========== Lab2 =========== */
        //Rozciąganie
        public static Bitmap Stretch(Bitmap bitmap, int[] greyHistogram, int[] redHistogram, int[] greenHistogram, int[] blueHistogram)
        {
            int min = 0;
            int max = 255;

            BitmapData bitmapData =
                bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            UnmanagedImage image = new UnmanagedImage(bitmapData);

            while (greyHistogram[min] <= 0)
            {
                min += 1;
            }

            while (greyHistogram[max] <= 0)
            {
                max -= 1;
            }

            for (int i = 0; i < image.Width; ++i)
            {
                for (int j = 0; j < image.Height; ++j)
                {
                    int color = (image.GetPixel(i, j).R - min) * (255 / (max - min));
                    image.SetPixel(i, j, Color.FromArgb(color, color, color));
                }
            }



            Bitmap result = image.ToManagedImage();
            bitmap.UnlockBits(bitmapData);
            return result;
        }
    }
}