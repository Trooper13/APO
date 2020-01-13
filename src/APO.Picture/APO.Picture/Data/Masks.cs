using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APO.Picture.Data
{
    public static class Masks
    {
        public static int Kvalue { get; set; }

        //Maski wygładzające
        public static float[] SmoothMaskOne = new float[] { 0, 1, 0, 1, 4, 1, 0, 1, 0 };
        public static float[] SmoothMaskTwo = new float[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        public static float[] SmoothMaskThree = new float[] { 1, 2, 1, 2, 4, 2, 1, 2, 1 };

        //Detekcja krawędzi
        public static float[] EdgeMaskOne = new float[] { 0, -1, 0, -1, 4, -1, 0, -1, 0 };
        public static float[] EdgeMaskTwo = new float[] { -1, -1, -1, -1, 8, - 1, -1, -1, -1 };
        public static float[] EdgeMaskThree = new float[] { 1, -2, 1, -2, 4, -2, 1, -2, 1 };
        
        //Maski wyostrzające
        public static float[] SharpMaskOne = new float[] { 1, -2, 1, -2, 5, -2, 1, -2, 1 };
        public static float[] SharpMaskTwo = new float[] { -1, -1, -1, -1, 9, -1, -1, -1, -1 };
        public static float[] SharpMaskThree = new float[] { 0, -1, 0, -1, 5, -1, 0, -1, 0 };

        //Maski Sobela
        public static float[] NWmask = new float[] { 2, 1, 0, 1, 0, -1, 0, -1, -2 };
        public static float[] Nmask = new float[] { 1, 2, 1, 0, 0, 0, -1, -2, -1 };
        public static float[] NEmask = new float[] { 0, 1, 2, -1, 0, 1, -2, -1, 0 };
        public static float[] Wmask = new float[] { 1, 0, -1, 2, 0, -2, 1, 0, -1 };
        public static float[] SWmask = new float[] { 0, -1, -2, 1, 0, -1, 2, 1, 0 };
        public static float[] SEmask = new float[] { -2, -1, 0, -1, 0, 1, 0, 1, 2 };

        //Maski Prewitta
        public static float[] xPrewitt = new float[] { 1, 1, 1, 0, 0, 0, -1, -1, -1 };
        public static float[] yPrewitt = new float[] { -1, 0, 1, -1, 0, 1, -1, 0, 1 };
        public static float[] NWprewitt = new float[] { 1, 1, 0, 1, 0, -1, 0, -1, -1 };
        public static float[] Sprewitt = new float[] { -1, -1, -1, 0, 0, 0, 1, 1, 1 };
        public static float[] NEprewitt = new float[] { 0, 1, 1, -1, 0, 1, -1, -1, 0 };
        public static float[] Wprewitt = new float[] { 1, 0, -1, 1, 0, -1, 1, 0, -1 };
        public static float[] SWprewitt = new float[] { 0, -1, -1, 1, 0, -1, 1, 1, 0 };
        public static float[] SEprewitt = new float[] { -1, -1, 0, -1, 0, 1, 0, 1, 1 };

        //Maski Robertsa
        internal static float[] NWroberts = new float[] { 1, 0, 0, -1 };
        internal static float[] SEroberts = new float[] { -1, 0, 0, 1 };

        public static float SumMask(this float[] mask)
        {
            return mask.Sum();
        }

        public static float[] GetMyMask(int k)
        {
            return new float[] { 1, 1, 1, 1, k, 1, 1, 1, 1 };
        }
    }
}
