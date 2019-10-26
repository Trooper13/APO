using System;
using System.Drawing;
using System.Drawing.Imaging;
using Accord.Controls;
using HistogramAccord = Accord.Statistics.Visualizations.Histogram;

namespace APO.Picture.Extensions
{
    public class Histogram
    {
        public int MaxPixels { get; } = 0;
        public int MaxLevel { get; } = 0;
        public int MinLevel { get; } = 255;
        public int[] Levels { get; } = new int[256];

        public Histogram(Bitmap image)
        {
            //switch (image.PixelFormat)
            //{
            //    case PixelFormat.Format16bppGrayScale:
            //        return;

            //    case PixelFormat.Format24bppRgb:

            //        for (int y = 0; y < image.Height; ++y)
            //        {
            //            for (int x = 0; x < image.Width; ++x)
            //            {
            //                Color color = image.GetPixel(x, y);
            //                int level = (color.R + color.G + color.B) / 3;
            //                Levels[level]++;
            //                MaxPixels = Math.Max(MaxPixels, Levels[level]);
            //                MaxLevel = Math.Max(MaxLevel, level);
            //                MinLevel = Math.Min(MinLevel, level);
            //            }
            //        }

            //        break;
            //}

            for (int y = 0; y < image.Height; ++y)
            {
                for (int x = 0; x < image.Width; ++x)
                {
                    Color color = image.GetPixel(x, y);
                    int level = (color.R + color.G + color.B) / 3;
                    Levels[level]++;
                    MaxPixels = Math.Max(MaxPixels, Levels[level]);
                    MaxLevel = Math.Max(MaxLevel, level);
                    MinLevel = Math.Min(MinLevel, level);
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
    }
}