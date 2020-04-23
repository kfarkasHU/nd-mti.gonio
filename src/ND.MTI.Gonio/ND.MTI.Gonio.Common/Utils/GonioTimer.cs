using System;
using System.Windows.Forms;

namespace ND.MTI.Gonio.Common.Utils
{
    public sealed class GonioTimer : Timer
    {
        public GonioTimer(EventHandler onTick, int interval) : base()
        {
            this.Tick += onTick;
            this.Interval = interval;
        }
    }
}
