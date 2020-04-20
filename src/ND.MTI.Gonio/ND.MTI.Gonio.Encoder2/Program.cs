using System;
using System.IO.Ports;
using System.Threading;
using ND.MTI.Service.Worker;
using ND.MTI.Service.Worker.Pokeys;

namespace ND.MTI.Gonio.Encoder
{
    class Program
    {
        private static Thread _thread;
        private static SerialPort _serialPort;
        private static Pokeys57UWorker _pokeys57UWorker;

        static void Main()
        {
            _thread = new Thread(OnRead);
            _serialPort = new SerialPort();
            _pokeys57UWorker = new Pokeys57UWorker(1);

            _serialPort.DtrEnable = true;
            _serialPort.RtsEnable = true;
            _serialPort.PortName = "COM6";
            _serialPort.DataBits = 8;
            _serialPort.BaudRate = 115200;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.WriteTimeout = 500;
            _serialPort.ReadTimeout = 500;

            _serialPort.Open();

            //_serialPort.DataReceived += OnDataReceived;
            _thread.Start();

            Console.ReadKey();

            _pokeys57UWorker.Connect();
            _pokeys57UWorker.WriteDataX("0000");
            _pokeys57UWorker.WriteDataY("0000");

            Console.ReadKey();

            _serialPort.Write("A");
            _serialPort.Write("B");

            Console.ReadKey();

            _pokeys57UWorker.WriteDataY("1110");

            Console.ReadKey();

            _pokeys57UWorker.WriteDataY("0000");

            Console.ReadKey();
        }

        private static void OnRead()
        {
            while(true)
            {
                try
                {
                    var indata = _serialPort.ReadLine();
                    Console.WriteLine(indata);
                }
                catch (Exception) { }
            }
        }

        private static void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = (SerialPort)sender;
            var indata = serialPort.ReadLine();

            Console.WriteLine(indata);
        }
    }
}
