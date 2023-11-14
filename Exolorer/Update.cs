using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exolorer
{
    static class Update
    {
        public static void Del(string[] sod, string[] a, int i, string path)
        {
            if (a.Contains(sod[i - 1000]))
            {
                Directory.Delete(sod[i - 1000], true);
            }
            else
            {
                File.Delete(sod[i - 1000]);
            }
            Explorer.Papka(path);
        }
        public static void Addition(string path)
        {
            Console.Clear();
            Console.WriteLine("Введите имя желаймого для создания объекта");
            string g = Console.ReadLine();
            if (g.Split(".").Length > 1)
            {
                File.Create(path + "\\" + g);
            }
            else
            {
                Directory.CreateDirectory(path + "\\" + g);
            }
            Explorer.Papka(path);
        }
    }
}
