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
            Console.WriteLine($"\x1b[38;2;{c.R};{c.G};{c.B}maaa");
            string filePath = "data.txt";
            StreamReader sr = new StreamReader(filePath);
            string line;
            var list = new SortedList<float, (char, float)>(11);
            while ((line = sr.ReadLine()) != null)
            {
                var stringList = line.Split('|');
                Console.WriteLine(stringList[0] + " " + stringList[1] + " " + stringList[2]);
                list.Add(Convert.ToSingle(stringList[0]) * 2, (stringList[1].ToCharArray()[0], Convert.ToSingle(stringList[2]) * 2));
            }
            sr.Close();
            foreach (string str in ImgProcess.ImgToAscii("yuukaquarter.png", list))
            {
                Console.WriteLine(str);
            }
        }
    }
}