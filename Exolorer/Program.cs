namespace Exolorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new Explorer();
            while (true)
            {
                try
                {
                    a.Papka(a.Disks());
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.Clear();
                    Console.WriteLine("К этому файлу нет доступа");
                    Console.ReadKey();
                    continue;
                }
                catch
                {
                    Console.Clear();
                    continue;
                }
            }

        }
    }
}