using System;
using System.IO.Ports;

namespace ND.MTI.Gonio.COMScan
{
    class Program
    {
        static void Main()
        {
            var comPortNames = SerialPort.GetPortNames();

            foreach (var comPortName in comPortNames)
                Console.WriteLine(comPortName);

            if (comPortNames.Length == 0)
                Console.WriteLine("No COM ports found!");

            Console.ReadKey();
        }
    }
}
