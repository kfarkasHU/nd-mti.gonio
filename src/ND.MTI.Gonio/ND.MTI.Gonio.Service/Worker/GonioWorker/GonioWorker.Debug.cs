#if DEBUG

using System;
using System.Threading;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.RuntimeContext;
using ND.MTI.Gonio.Service.Worker.Serial;

namespace ND.MTI.Gonio.Service.Worker
{
    public class GonioWorker : SerialCore, IGonioWorker
    {
        private static IGonioWorker _instance;

        private GonioWorker()
        {
            RuntimeContext.IsFSMGonioConnected = Connect(null);
        }
        
        public static IGonioWorker GetInstance()
        {
            if (_instance is null)
                _instance = new GonioWorker();

            return _instance;
        }

        public bool Connect(Complex_FSMGonioConfig fsmGonioConfig) => true;

        public double Measure()
        {
            Thread.Sleep(500);

            var seed = Guid
                        .NewGuid()
                        .GetHashCode();

            var random = new Random(seed);

            return random.NextDouble() * 1000;
        }

        public void Reset() => Thread.Sleep(500);
    }
}


#endif
