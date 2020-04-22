using System;
using System.Threading;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Service.Worker.Serial;

namespace ND.MTI.Gonio.Service.Worker.SSIWorker
{
    public sealed class SSIWorker : SerialCore, ISSIWorker, IDisposable
    {
        public string ResponseX { get; private set; }
        public string ResponseY { get; private set; }

        private const string ZeroXCommand = "B";
        private const string ZeroYCommand = "A";

        private readonly Thread _thread;
        private bool _isReading;

        public SSIWorker()
        {
            _thread = new Thread(OnRead);
            _thread.IsBackground = true;
            _isReading = true;
        }

        private void OnRead()
        {
            while(_isReading)
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

        public void Dispose()
        {
            _isReading = false;
            _thread.Abort();
        }
    }
}
