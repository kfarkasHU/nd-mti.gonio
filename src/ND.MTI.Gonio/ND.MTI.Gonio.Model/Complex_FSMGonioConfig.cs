using System.IO.Ports;

namespace ND.MTI.Gonio.Model
{
    public class Complex_FSMGonioConfig
    {
        public string ComPortName;
        public int DataBits;
        public int SpeedInBaud;
        public Parity Parity;
        public StopBits StopBits;
        public int WriteTimeout;
        public int ReadTimeout;
    }
}
