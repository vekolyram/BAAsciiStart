using System;
using System.Collections.Generic;
using System.Drawing;

using System.Drawing;

using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

/*
      _____                    _____                    _____                    _____                    _____
     |\    \                  /\    \                  /\    \                  /\    \                  /\    \
     |:\____\                /::\____\                /::\____\                /::\____\                /::\    \
     |::|   |               /:::/    /               /:::/    /               /:::/    /               /::::\    \
     |::|   |              /:::/    /               /:::/    /               /:::/    /               /::::::\    \
     |::|   |             /:::/    /               /:::/    /               /:::/    /               /:::/\:::\    \
     |::|   |            /:::/    /               /:::/    /               /:::/____/               /:::/__\:::\    \
     |::|   |           /:::/    /               /:::/    /               /::::\    \              /::::\   \:::\    \
     |::|___|______    /:::/    /      _____    /:::/    /      _____    /::::::\____\________    /::::::\   \:::\    \
     /::::::::\    \  /:::/____/      /\    \  /:::/____/      /\    \  /:::/\:::::::::::\    \  /:::/\:::\   \:::\    \
    /::::::::::\____\|:::|    /      /::\____\|:::|    /      /::\____\/:::/  |:::::::::::\____\/:::/  \:::\   \:::\____\
   /:::/~~~~/~~      |:::|____\     /:::/    /|:::|____\     /:::/    /\::/   |::|~~~|~~~~~     \::/    \:::\  /:::/    /
  /:::/    /          \:::\    \   /:::/    /  \:::\    \   /:::/    /  \/____|::|   |           \/____/ \:::\/:::/    /
 /:::/    /            \:::\    \ /:::/    /    \:::\    \ /:::/    /         |::|   |                    \::::::/    /
/:::/    /              \:::\    /:::/    /      \:::\    /:::/    /          |::|   |                     \::::/    /
\::/    /                \:::\__/:::/    /        \:::\__/:::/    /           |::|   |                     /:::/    /
 \/____/                  \::::::::/    /          \::::::::/    /            |::|   |                    /:::/    /
                           \::::::/    /            \::::::/    /             |::|   |                   /:::/    /
                            \::::/    /              \::::/    /              \::|   |                  /:::/    /
                             \::/____/                \::/____/                \:|   |                  \::/    /
                              ~~                       ~~                       \|___|                   \/____/

*/

namespace BAAsciiStart

{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //ConsoleColor.GetName
            Color c = Color.FromArgb(0xAACCDD);
            Color h = ColorConverter.RgbNoHsB(c);
            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.WriteLine($"H: {red.h:0.##}°, S: {red.s:0.##}, V: {red.v:0.##}");
            Console.WriteLine($"{c.GetHue()};{c.GetSaturation()}");
            Console.WriteLine($"{h.GetHue()};{h.GetSaturation()}");
            Console.WriteLine($"\x1b[38;2;{c.R};{c.G};{c.B}maaa");
            Console.WriteLine($"\x1b[38;2;{h.R};{h.G};{h.B}maaa");
            var calculator = new CharCoverageCalculator("JetBrains Mono", 12, 1.2f);
            calculator.test();
            var a = new SortedList<float, char>() { { 1f, 'a' } };
        }
    }
}