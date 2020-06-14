using System.IO.Ports;

namespace ND.MTI.Gonio.ServiceInterface
{
    public interface ISerialCore : IExternalDevice
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
    }
}
