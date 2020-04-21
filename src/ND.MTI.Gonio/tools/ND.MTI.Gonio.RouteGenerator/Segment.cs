using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ND.MTI.Gonio.RouteGenerator
{
    internal class Segment
    {
        public Segment(double start, double to, double step)
        {
            Start = start;
            End = to;
            Step = step;
        }

        public double Start { get; private set; }
        public double End { get; private set; }
        public double Step { get; private set; }
    }
}
