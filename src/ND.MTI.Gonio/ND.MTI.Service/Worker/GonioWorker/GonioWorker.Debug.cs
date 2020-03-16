#if DEBUG

using ND.MTI.Gonio.Model;
using ND.MTI.Service.Worker.Serial;
using System;
using System.Threading;

namespace ND.MTI.Service.Worker
{
    public class GonioWorker : SerialCore, IGonioWorker
    {
        public bool Connect(Complex_FSMGonioConfig fsmGonioConfig) => true;

        public override double Measure()
        {
            Thread.Sleep(500);

            var seed = Guid
                        .NewGuid()
                        .GetHashCode();

            var random = new Random(seed);

            return random.NextDouble() * 1000;
        }

        public override void Reset() => Thread.Sleep(500);
    }
}


#endif
