using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Exolorer
{
    internal class Explorer
    {
        public string Disks()
        {
            Console.Clear();
            Console.WriteLine("Enter - переход к содержимому");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            int cl = 2;
            foreach (DriveInfo d in driveInfos)
            {
                Console.Write("  " + d.Name + " ");
                Console.Write(d.TotalFreeSpace / 1073741824 + " GB свободно из " + d.TotalSize / 1073741824 + " GB ");
                Console.SetCursorPosition(35, cl);
                Console.WriteLine(Math.Round((double)(d.TotalFreeSpace / 1073741824) / (d.TotalSize / 1073741824) * 100, 2) + "%");
                cl++;
            }
            var a = new Menu(2, cl-1);
            int i = a.Show();
            Console.Clear();
            return driveInfos[i].Name;
        }

        void Del(string dop)
        {
            if (dop.Split(".").Length > 1)
            {
                File.Delete(dop);
            }
            else
            {
                Directory.Delete(dop, true);
            }
            
        }

        public void Papka(string path)
        {
            Console.Clear();
            Console.WriteLine("Enter - переход к содержимому, F1 - добавить паку/файл в этой директории, Del - удалить выбранную директорию");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            var a = Directory.GetDirectories(path);
            var b = Directory.GetFiles(path);
            var sod = a.Take(a.Length).Concat(b.Take(b.Length)).ToArray();
            int cl = 2;
            foreach ( var d in sod)
            {
                Console.Write("  " + d);
                Console.SetCursorPosition(70, cl);
                Console.WriteLine(Directory.GetCreationTime(d).ToString());
                cl ++;
            }
                
            var h = new Menu(2, a.Length + b.Length-1);
            int i = h.Show();
            Console.Clear();
            if (i == -1)
            {
                return;
            }
            if (i == -2)
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
                Papka(path);
            }
            if (i > 1000)
            {
                Del(sod[i - 1000]);
                Papka(path);
            }

            if (a.Contains(sod[i]))
            {
                Papka(sod[i]);
            }
            else if (b.Contains(sod[i]))
            {
                Process.Start(new ProcessStartInfo { FileName = sod[i], UseShellExecute = true });
                return;
            }
        }
    }
}
