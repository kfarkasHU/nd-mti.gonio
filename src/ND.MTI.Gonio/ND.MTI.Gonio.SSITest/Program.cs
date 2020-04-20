using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoKeysDevice_DLL;

namespace ND.MTI.Gonio.SSITest
{
    class Program
    {
        private static PoKeysDevice _device;

        static void Main(string[] args)
        {
            _device = new PoKeysDevice();

            _ = _device.EnumerateDevices();
            _ = _device.ConnectToDevice(0);


        }
    }
}
