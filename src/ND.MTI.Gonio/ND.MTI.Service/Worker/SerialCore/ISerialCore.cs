using System.IO.Ports;

namespace ND.MTI.Service.Worker.Serial
{
    public interface ISerialCore
    {
        bool Connect(
            string comPortName,
            int dataBits,
            int speedInBaud,
            Parity parity,
            StopBits stopBits,
            int writeTimeout = 500,
            int readTimeout = 500
        );
        void Disconnect();
        void Reset();
        double Measure();
    }
}
