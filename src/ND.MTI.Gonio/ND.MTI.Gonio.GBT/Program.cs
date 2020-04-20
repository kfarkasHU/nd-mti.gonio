using System;
using System.IO;
using System.Reflection;
using ND.MTI.Gonio.Common.Utils;
using System.Collections.Generic;

namespace ND.MTI.Gonio.GBT
{
    class Program
    {
        static void Main()
        {
            var path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\data.txt";
            var lines = File.ReadAllLines(path);

            Console.WriteLine($" REPLACED || GRAY || NEW || OLD");

            var lo = lines[0].Split(';');
            var length = lo[0].Length;

            var hash = new List<string>();
            
            for (var i = 0; i < length -1; i++)
            {
                foreach (var line in lines)
                {
                    var l = line.Split(';');
                    l[0] = l[0].Remove(i, 1);

                    Console.WriteLine($"{i+1};{l[0]};{GrayUtils.GrayToInteger(l[0])};{l[1]}");
                    hash.Add($"{i + 1};{l[0]};{GrayUtils.GrayToInteger(l[0])};{l[1]}");
                }
            }

            Export(hash);

            Console.ReadKey();
        }

        private static void Export(IList<string> hash)
        {
            System.IO.File.WriteAllLines($"C:\\Users\\win10\\Desktop\\gonioresult\\gbtexport{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt", hash);
        }
    }
}
