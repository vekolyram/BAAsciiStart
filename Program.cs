using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

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
            Color c = Color.FromArgb(0xAACCDD);
            Color h = ColorConverter.RgbNoHsB(c);
            Console.WriteLine($"{c.GetHue()};{c.GetSaturation()}");
            Console.WriteLine($"{h.GetHue()};{h.GetSaturation()}");
            Console.WriteLine($"\x1b[38;2;{c.R};{c.G};{c.B}maaa");
            Console.WriteLine($"\x1b[38;2;{h.R};{h.G};{h.B}maaa");
            string filePath = "./data.txt";
            StreamReader sr = new StreamReader(filePath);
            string line;
            var list = new SortedList<float, (char, float)>(11);
            while ((line = sr.ReadLine()) != null)
            {
                var stringList = line.Split('|');
                list.Add(Convert.ToSingle(stringList[0]), (Convert.ToChar(stringList[1]), Convert.ToChar(stringList[2])));
            }
        }
    }
}