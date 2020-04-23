#if DEBUG

using System;
using System.IO.Ports;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Service.Worker.Serial;

namespace ND.MTI.Gonio.Service.Worker.SSIWorker
{
    public sealed class SSIWorker : IExternalDevice, ISerialCore, ISSIWorker, IDisposable
    {
        public string ResponseX => WorkerHelper.CurrentX.ToString();

        public string ResponseY => WorkerHelper.CurrentY.ToString();

        public bool IsConnected => true;

        public bool Connect(Complex_SSIConfig config) =>
            Connect(
                    config.ComPortName,
                    config.DataBits,
                    config.SpeedInBaud,
                    config.Parity,
                    config.StopBits,
                    config.WriteTimeout,
                    config.ReadTimeout
                );

        public bool Connect(
            string comPortName,
            int dataBits,
            int speedInBaud,
            Parity parity,
            StopBits stopBits,
            int writeTimeout = 500,
            int readTimeout = 500) => true;

        public void Disconnect() { }

        public void Dispose() { }

        public void ZeroX() => WorkerHelper.ZeroX();

        public void ZeroY() => WorkerHelper.ZeroY();
    }
}

#endif
