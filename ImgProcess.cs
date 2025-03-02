using System;
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
        public static List<String> ImgToAscii(Bitmap bitmap, SortedList<float, (char, float)> asciiList)
        {
            var list = new List<string>();
            var sb = new StringBuilder();
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
                    Parallel.For(0, bitmap.Height, y =>
                    {
                        byte* row = ptr + (y * bmpData.Stride);
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            byte b = row[x * bytesPerPixel];
                            byte g = row[x * bytesPerPixel + 1];
                            byte r = row[x * bytesPerPixel + 2];
                            byte a = row[x * bytesPerPixel + 3];
                            if (a == 0)
                            {
                                sb.Append(" ");
                            }
                            Color ca = Color.FromArgb(r, g, b);
                            Color cb = ColorConverter.RgbNoHsB(ca);
                            Color cc = ColorConverter.HsbSubToRgb(asciiList.Values
                            sb.Append($"{}");
                        }
                    });
                }
            }
            finally
            {
                bitmap.UnlockBits(bmpData);
            }
            return list;
        }
    }
}