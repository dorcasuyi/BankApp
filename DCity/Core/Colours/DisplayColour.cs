using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCity.Core.Colours
{
    static class DisplayColour
    {
        public static void colourBlue(string value)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
        }

        public static void colourYellow(string value)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
        }

        public static void colourRed(string value)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(PadBoth(value, Console.WindowWidth - 1));
            Console.ResetColor();
        }
        public static void colourGreen(string value)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
        }
        public static void BankColou(string value)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(PadBoth(value, Console.WindowWidth - 1));
            Console.ResetColor();
        }
        public static void BankYellow(string value)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(PadBoth(value, Console.WindowWidth - 1));
            Console.ResetColor();
        }

        public static string PadBoth(string value, int Width)
        {
            int distance = Width - value.Length;

            int padLeft = distance / 2 + value.Length;

            return value.PadLeft(padLeft).PadRight(Width);
        }

    }
}
