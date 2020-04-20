using System;
using System.Threading;
using ND.MTI.Gonio.Model;
using ND.MTI.Service.Worker.Serial;

namespace ND.MTI.Service.Worker.SSIWorker
{
    public sealed class SSIWorker : SerialCore, ISSIWorker
    {
        public string ResponseX { get; private set; }
        public string ResponseY { get; private set; }

        private const string ZeroXCommand = "B";
        private const string ZeroYCommand = "A";

        private readonly Thread _thread;

        public SSIWorker()
        {
            _thread = new Thread(OnRead);
        }

        private void OnRead()
        {
            while(true)
            {
                try
                {
                    var line = _serialPort.ReadLine();

                    var p = line.Split(',');

                    if (p.Length != 2)
                        return;

                    var pa = p[0].Replace("A", "");
                    var pb = p[1].Replace("B", "");

                    if (pa.Length == 4)
                        ResponseY = pa;

                    if (pb.Length == 4)
                        ResponseX = pb;
                }
                catch (Exception) { };
            }
        }

        public bool Connect(Complex_SSIConfig config)
        {
            var res = Connect(
                config.ComPortName,
                config.DataBits,
                config.SpeedInBaud,
                config.Parity,
                config.StopBits,
                config.WriteTimeout,
                config.ReadTimeout
            );

            if (res)
                _thread.Start();

            return res;
        }

        public void ZeroX() => SendCommand(ZeroXCommand);

        public void ZeroY() => SendCommand(ZeroYCommand);
    }
}
