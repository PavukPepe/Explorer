using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace Exolorer
{
    public static class Explorer
    {
        public static string Disks()
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
            int i = Menu.Show(2, driveInfos.Length - 1);
            Console.Clear();
            return driveInfos[i].Name;
        }

        public static void Papka(string path)
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
                
            var i = Menu.Show(2, sod.Length - 1);
/*            int i = h.Show();*/
            Console.Clear();
            if (i == -1)
            {
                try
                {
                    Papka(Directory.GetParent(path).Name);
                }
                catch
                {
                    return;
                }
            }
            else if (i == -2)
            {
                Update.Addition(path);
            }

            else if (a.Length >= i && a.Contains(sod[i]))
            {
                Papka(sod[i]);
            }
            else if (b.Length >= i && b.Contains(sod[i]))
            {
                Process.Start(new ProcessStartInfo { FileName = sod[i], UseShellExecute = true });
                return;
            }
            else if (i > 1000)
            {
                Update.Del(sod, a, i, path);
            }
        }
    }
}
