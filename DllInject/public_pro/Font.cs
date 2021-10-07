using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DllInject.public_pro
{
    class Font
    {
        //红色字体
        public static void Warning(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        //绿色字体
        public static void InfoFonts(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void FontRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public static void FontNormal()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
