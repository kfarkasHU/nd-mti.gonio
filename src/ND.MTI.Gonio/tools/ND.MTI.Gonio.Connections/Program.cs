using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using PoKeysDevice_DLL;

namespace ND.MTI.Gonio.Connections
{
    class Program
    {
        private static readonly string NO = "-";
        private static readonly string YES = "+";

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            CheckPokeys();
            //CheckCOMs();

            Console.ReadKey();
        }

        private static void CheckPokeys()
        {
            var device = new PoKeysDevice();

            var number = device.EnumerateDevices();

            switch(number)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(NO);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" No connected pokeys device found.");

                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(YES);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Pokeys device connected.");

                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(NO);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Multiple connected pokeys devices found.");

                    break;
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void CheckCOMs()
        {

        }
    }
}
