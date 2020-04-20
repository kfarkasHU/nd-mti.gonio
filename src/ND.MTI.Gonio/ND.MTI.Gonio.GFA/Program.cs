using System;
using System.Collections.Generic;
using System.Linq;
using ND.MTI.Gonio.Common.Utils;

namespace ND.MTI.Gonio.GFA
{
    public class Program
    {
        public static void generateGrayarr(int n)
        {

            var arr = new List<string>();
            arr.Add("0");
            arr.Add("1");

            int i, j;
            for (i = 2; i < (1 << n); i <<= 1)
            {
                for (j = i - 1; j >= 0; j--)
                    arr.Add(arr[j]);

                for (j = 0; j < i; j++)
                    arr[j] = "0" + arr[j];

                for (j = i; j < 2 * i; j++)
                    arr[j] = "1" + arr[j];
            }

            //for (i = 0; i < arr.Count; i++)
            //    Console.WriteLine($"{arr[i]} - {GrayUtils.GrayToInteger(arr[i])}");

            Console.WriteLine("==============================");
            var sixBased = arr.Where(m => m.Count(k => k == '1') == 6).ToList();

            for(i = 0; i < sixBased.Count; i++)
            {
                var next = arr[arr.IndexOf(sixBased[i]) + 1];
                var afterNext = arr[arr.IndexOf(sixBased[i]) + 2];

                if (next.Count(m => m == '1') == 5 &&
                    afterNext.Count(m => m == '1') == 6
                    )
                {
                    Console.WriteLine("|");
                    Console.WriteLine($"|___{sixBased[i]} - {GrayUtils.GrayToInteger(sixBased[i])}");
                    Console.WriteLine($"| |_{next} - {GrayUtils.GrayToInteger(next)}");
                    Console.WriteLine($"| |_{afterNext} - {GrayUtils.GrayToInteger(afterNext)}");
                }
            }

            Console.ReadKey();
        }

        public static void Main(string[] args)
        {
            generateGrayarr(12);
        }
    }
}
