using System.Collections.Generic;
using System.IO.Ports;
using System.Management;

namespace ND.MTI.Gonio.Common.Utils
{
    public static class COMUtils
    {
        public static IEnumerable<string> SelectAllComPortNames() => SerialPort.GetPortNames();
    }
}
