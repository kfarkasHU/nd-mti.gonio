using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ND.MTI.Gonio.Pokeys57U_POC
{
    class Program
    {
        public enum pinFunctionsEnum
        {
            pinFunctionInactive = 0,
            pinFunctionDigitalInput = 2,
            pinFunctionDigitalOutput = 4,
            pinFunctionAnalogInput = 8,
            pinFunctionAnalogOutput = 16,
            pinInvert = 128
        }

        static void Main(string[] args)
        {
            var device = new PoKeysDevice_DLL.PoKeysDevice();
            device.ConnectToDevice(0);

            device.SetPinData(1, (byte)(pinFunctionsEnum.pinFunctionDigitalOutput));
            Console.WriteLine("Pin 3 was set as digital output");

            device.SetOutput(1, true);

            var freq = device.GetPWMFrequency();

            device.DisconnectDevice();


            Console.ReadKey();
        }
    }
}
