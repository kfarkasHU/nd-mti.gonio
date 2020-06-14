#if DEBUG

using System;
using System.Threading;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.RuntimeContext;
using ND.MTI.Gonio.Service.Worker.Serial;
using System.Linq;
using System.Collections.Generic;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.ServiceInterface;

namespace ND.MTI.Gonio.Service.Worker
{
    public class GonioWorker : SerialCore, IGonioWorker
    {
        public GonioWorker()
        {
            RuntimeContext.IsFSMGonioConnected = Connect(null);
        }

        public bool Connect(Complex_FSMGonioConfig fsmGonioConfig) => true;

        public double Measure() => MeasureInternal();
        public double MeasureOperated() => MeasureOperatedInternal();
        public double MeasureLumenanceOperated() => MeasureOperatedInternal() * Math.Pow(15, 2);

        public void Reset() => Thread.Sleep(500);

        private double MeasureOperatedInternal()
        {
            var userconfig = RuntimeContext.UserConfig;
            var results = new List<double>();

            foreach(var _ in Enumerable.Range(0, userconfig.MeasuresInSamePosition))
                results.Add(MeasureInternal());

            return MathUtils
                .Operate(results, userconfig.MeasuresInSamePositionOperation)
                .First(); // When RAW was selected.
        }

        private double MeasureInternal()
        {
            Thread.Sleep(500);

            var seed = Guid
                        .NewGuid()
                        .GetHashCode();

            var random = new Random(seed);

            return random.NextDouble() * 10;
        }
    }
}


#endif
