using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exolorer
{
    static class Menu
    {
        public static int Show(int minp, int maxp)
        {
            int pos = minp;
            ConsoleKeyInfo key;

            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");

                key = Console.ReadKey();

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.DownArrow && pos != maxp + minp)
                    pos++;
                else if (key.Key == ConsoleKey.UpArrow && pos != minp)
                    pos--;
                else if (key.Key == ConsoleKey.Escape)
                    return -1;
                else if (key.Key == ConsoleKey.F1)
                    return -2;
                else if (key.Key == ConsoleKey.Delete)
                    return 1000 + pos - minp;
            } while (key.Key != ConsoleKey.Enter);
            return pos - minp;
        }
    }
}
