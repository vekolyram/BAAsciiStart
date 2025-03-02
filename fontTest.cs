using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace BAAsciiStart
{
    public class CharCoverageCalculator
    {
        private readonly Font _font;
        private readonly int _cellWidth;
        private readonly int _cellHeight;

        public CharCoverageCalculator(string fontName, float fontSize, float lineHeightMultiplier)
        {
            _font = new Font(fontName, fontSize, FontStyle.Regular, GraphicsUnit.Pixel);
            using (var tempBmp = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(tempBmp))
            {
                g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                _cellWidth = (int)Math.Ceiling(g.MeasureString(" ", _font).Width); // 空格字符宽度
            }
            _cellHeight = (int)Math.Round(fontSize * lineHeightMultiplier);
        }

        public float CalculateCoverage(char c)
        {
            var bmp = new Bitmap(_cellWidth, _cellHeight);
            var g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(
                c.ToString(),
                _font,
                Brushes.White,
                new RectangleF(0, 0, _cellWidth, _cellHeight),
                format
            );
            int foregroundPixels = 0;
            var data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb
            );
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                for (int y = 0; y < data.Height; y++)
                {
                    for (int x = 0; x < data.Width; x++)
                    {
                        if (ptr[y * data.Stride + x * 4] > 0)
                            foregroundPixels++;
                    }
                }
            }
            bmp.UnlockBits(data);
            return (float)foregroundPixels / (_cellWidth * _cellHeight);
        }

        public SortedList<float, char> test()
        {
            var calculator = new CharCoverageCalculator("JetBrains Mono", 12, 1.2f);
            var sortedList = new SortedList<float, char>();
            foreach (char ch in " !@#$%^&-_*~,`{[:;'\"\\|?/▁▂▃▄▅▆▇█")
            {
                float hashCoverage = CalculateCoverage(ch);
                hashCoverage = (float)Math.Round(hashCoverage, 2);
                try
                {
                    sortedList.Add(hashCoverage, ch);
                }
                catch (ArgumentException)
                {
                    try
                    {
                        hashCoverage += 0.1f;
                        sortedList.Add(hashCoverage, ch);
                    }
                    catch { }
                }
            }
            for (int i = 0; i < sortedList.Count; i++)
            {
                Console.WriteLine($"{sortedList.Keys[i]} 的覆盖率: {sortedList[sortedList.Keys[i]]}");
            }
            for (int i = 0; i < sortedList.Count; i++)
            {
                Console.WriteLine($"{sortedList.Keys[i]}|{sortedList[sortedList.Keys[i]]}");
            }
            return sortedList;
        }
    }
}