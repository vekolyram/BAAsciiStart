using System;
using System.Drawing;

namespace BAAsciiStart
{
    internal class ColorConverter
    {
        public static Color HsbSubToRgb(Color c, float subB)
        {
            float h = c.GetHue(), s = c.GetSaturation(), b = subB;
            if (b <= 0)
            {
                return Color.FromArgb(0, 0, 0);
            }
            // 标准 HSB 转 RGB 算法
            int hi = (int)(h / 60) % 6;
            float f = h / 60 - hi;
            float p = b * (1 - s);
            float q = b * (1 - f * s);
            float t = b * (1 - (1 - f) * s);
            float r, g, b_out;
            switch (hi)
            {
                case 0: r = b; g = t; b_out = p; break;
                case 1: r = q; g = b; b_out = p; break;
                case 2: r = p; g = b; b_out = t; break;
                case 3: r = p; g = q; b_out = b; break;
                case 4: r = t; g = p; b_out = b; break;
                case 5: r = b; g = p; b_out = q; break;
                default: r = g = b_out = 0; break;
            }
            return Color.FromArgb(
                (int)(r * 255),
                (int)(g * 255),
                (int)(b_out * 255)
            );
        }

        public static Color RgbNoHsB(Color c)
        {
            return HsbSubToRgb(c, 0.5f);
        }
    }
}