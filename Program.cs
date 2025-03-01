using System;
using System.Drawing;

namespace BAAsciiStart
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //ConsoleColor.GetName
            Color c = Color.FromArgb(0xAACCDD);
            Color h =
            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.WriteLine($"H: {red.h:0.##}°, S: {red.s:0.##}, V: {red.v:0.##}");
            Console.WriteLine($"\x1b[38;2;{c.};{123};{53}maaa");
        }
    }
}