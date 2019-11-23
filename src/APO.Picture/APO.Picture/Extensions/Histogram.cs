using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
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

        #region Labo 2 (Rozciąganie i Equalizacja)

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

        //Equalizacja
        public static Bitmap Equalization(Bitmap bitmap, int[] histogram)
        {
            int[] leftZ = new int[256];
            int[] rightZ = new int[256];
            int[] newValue = new int[256];
            int histogramAverage = (int)histogram.Average();
            int R = 0;
            int Hint = 0;

            for (int i = 0; i < histogram.Length; i++)
            {
                leftZ[i] = R;
                Hint += histogram[i];

                while (Hint > histogramAverage)
                {
                    Hint = Hint - histogramAverage;
                    ++R;
                }

                rightZ[i] = R;
                newValue[i] = (leftZ[i] + rightZ[i]) / 2;
            }

            BitmapData bitmapData =
                bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format32bppArgb);

            UnmanagedImage image = new UnmanagedImage(bitmapData);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color color = image.GetPixel(i, j);

                    if (leftZ[color.A] == rightZ[color.A] && leftZ[color.R] == rightZ[color.R] && leftZ[color.G] == rightZ[color.G] && leftZ[color.B] == rightZ[color.B])
                    {
                        image.SetPixel(i, j, Color.FromArgb(leftZ[color.A], leftZ[color.R], leftZ[color.G], leftZ[color.B]));
                    }
                    else
                    {
                        image.SetPixel(i, j,
                            Color.FromArgb(color.A, newValue[color.R], newValue[color.R], newValue[color.R]));
                    }
                }
            }

            Bitmap resultBitmap = image.ToManagedImage();
            bitmap.UnlockBits(bitmapData);
            return resultBitmap;
        }

        #endregion

    }
}