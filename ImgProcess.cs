using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAAsciiStart
{
    internal class ImgProcess
    {
        public static List<String> ImgToAscii(string str, SortedList<float, (char, float)> asciiList)
        {
            var threadSafeList = new ConcurrentBag<string>();
            Bitmap bitmap = new Bitmap(str);
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new ArgumentException("Only 32-bit ARGB .png");
            }
            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(
                rect,
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);
            try
            {
                unsafe
                {
                    byte* ptr = (byte*)bmpData.Scan0;
                    int bytesPerPixel = 4;
                    int totalBytes = bmpData.Stride * bitmap.Height;
                    threadSafeList.Add("\b");
                    for (int y = bmpData.Height; y >= 0; y--)
                    {
                        //y = bmpData.Height - y;
                        var localSb = new StringBuilder();
                        byte* row = ptr + (y * bmpData.Stride);
                        for (int x = 0; x < bmpData.Width; x++)
                        {
                            byte b = row[x * bytesPerPixel + 0];
                            byte g = row[x * bytesPerPixel + 1];
                            byte r = row[x * bytesPerPixel + 2];
                            byte a = row[x * bytesPerPixel + 3];
                            var ca = Color.FromArgb(r, g, b);
                            float B = ca.GetBrightness();
                            float roundedB = (float)Math.Round(B, 1);
                            (char, float) cf = asciiList[(float)(roundedB)];
                            //Color cc = ColorConverter.HsbSubToRgb(ca, cf.Item2 - (roundedB - B));
                            Color cc = ColorConverter.HsbSubToRgb(ca, ca.GetBrightness());
                            localSb.Append($"\x1b[38;2;{ca.R};{ca.G};{ca.B}m{cf.Item1}");
                        }
                        threadSafeList.Add(localSb.ToString());
                    }
                    ;
                }
            }
            finally
            {
                bitmap.UnlockBits(bmpData);
            }
            bitmap.Dispose();
            return threadSafeList.ToList();
        }
    }
}