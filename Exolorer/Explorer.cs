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
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            int cl = 0;
            foreach (DriveInfo d in driveInfos)
            {
                Console.Write("  " + d.Name + " ");
                Console.Write(d.TotalFreeSpace / 1073741824 + " GB свободно из " + d.TotalSize / 1073741824 + " GB ");
                Console.SetCursorPosition(35, cl);
                Console.WriteLine(Math.Round((double)(d.TotalFreeSpace / 1073741824) / (d.TotalSize / 1073741824) * 100, 2) + "%");
                cl++;
            }
            var a = new Menu(0, cl-1);
            return driveInfos[a.Show()].Name;
        }

        public void Papka(string path)
        {
            Console.Clear();
            var a = Directory.GetDirectories(path);
            var b = Directory.GetFiles(path);
            var sod = a.Take(a.Length).Concat(b.Take(b.Length)).ToArray();
            int cl = 0;
            foreach ( var d in sod)
            {
/*                Console.WriteLine();*/
                Console.Write("  " + d);
                Console.SetCursorPosition(70, cl);
                Console.WriteLine(Directory.GetCreationTime(d).ToString());
                cl ++;
                
            }
                
            var h = new Menu(0, a.Length + b.Length-1);
            int i = h.Show();

            if (a.Contains(sod[i]))
            {
                Papka(sod[i]);
            }
            else if (b.Contains(sod[i]))
            {
                Process.Start(new ProcessStartInfo { FileName = sod[i], UseShellExecute = true });
                Console.WriteLine("Запустилось");
            }
        }
    }
}
