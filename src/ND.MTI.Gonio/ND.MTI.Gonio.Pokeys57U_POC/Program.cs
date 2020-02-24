using System;
using System.Threading;

namespace ND.MTI.Gonio.Pokeys57U_POC
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Press a button to start testing!");
            Console.ReadKey();
            Console.WriteLine();

            try
            {
                var device = new PoKeysDevice_DLL.PoKeysDevice();

                device.ConnectToDevice(0);

                #region setup

                device.SetPinData((byte)14, (byte)4); // dir+
                device.SetPinData((byte)15, (byte)4); // ena+

                #region [ set up PWMs ]

                var pwmOutputs = new bool[6];

                pwmOutputs[5] = true;  // 17 (X)
                pwmOutputs[4] = true;  // 18 (Y)
                pwmOutputs[3] = false; // 19
                pwmOutputs[2] = false; // 20
                pwmOutputs[1] = false; // 21
                pwmOutputs[0] = false; // 22

                // 12MHz / 300 = 40kHz
                var period = (uint)device.GetPWMFrequency() / 300; // 40 kHz

                // Create 50% PWM.
                var dutyScale = new uint[6];

                dutyScale[5] = (uint)(0.5 * period);
                dutyScale[4] = (uint)(0.5 * period);

                device.SetPWMOutputs(ref pwmOutputs, ref period, ref dutyScale);

                #endregion [ set up PWMs ]

                #endregion setup

                Console.WriteLine("Moving with ENA: 1 DIR: 1 PUL: PWM");

                device.SetOutput(14, true);
                device.SetOutput(15, true);

                Thread.Sleep(3000);

                Console.WriteLine("Moving with ENA: 1 DIR: 0 PUL: PWM");

                device.SetOutput(14, false);
                device.SetOutput(15, true);

                Thread.Sleep(3000);

                Console.WriteLine("Moving with ENA: 0 DIR: 1 PUL: PWM");

                device.SetOutput(14, true);
                device.SetOutput(15, false);

                Thread.Sleep(3000);

                Console.WriteLine("Moving with ENA: 0 DIR: 0 PUL: PWM");

                device.SetOutput(14, false);
                device.SetOutput(15, false);

                Thread.Sleep(3000);

                device.DisconnectDevice();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.TargetSite);
                Console.WriteLine(e.InnerException);
                Console.WriteLine(e.Data);
            }

            Console.ReadKey();
        }
    }
}
