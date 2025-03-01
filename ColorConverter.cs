using System.Drawing;

namespace BAAsciiStart
{
    internal class ColorConverter
    {
        public static Color RgbNoHsB(Color c)
        {
            float h = c.GetHue(), s = c.GetSaturation();
            int hi = (int)(h / 60) % 6;
            float f = h / 60 - hi;
            float p = (1 - s);
            float q = (1 - f * s);
            float t = (1 - (1 - f) * s);
            float r = 1, g = 1, b_out = 1;
            switch (hi)
            {
                case 0: g = t; b_out = p; break;
                case 1: r = q; b_out = p; break;
                case 2: r = p; b_out = t; break;
                case 3: r = p; g = q; break;
                case 4: r = t; g = p; break;
                case 5: g = p; b_out = q; break;
                default: r = g = b_out = 0; break;
            }
            return Color.FromArgb(
                (int)(r * 255),
                (int)(g * 255),
                (int)(b_out * 255)
            );
        }
    }
}