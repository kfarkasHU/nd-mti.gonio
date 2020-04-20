using System;
using ND.MTI.Gonio.Common.Utils;

namespace ND.MTI.Gonio.EPT
{
    public class EPTResultItem
    {
        public EPTResultItem(string encoderPos)
        {
            Time = DateTime.Now;
            EncoderPos = encoderPos;
            GrayPos = GrayUtils.GrayToInteger(encoderPos);
        }

        public DateTime Time { get; private set; }
        public string EncoderPos { get; private set; }
        public int GrayPos { get; private set; }

        public override string ToString()
        {
            return $"{Time.TimeOfDay};{EncoderPos};{GrayPos}";
        }
    }
}
