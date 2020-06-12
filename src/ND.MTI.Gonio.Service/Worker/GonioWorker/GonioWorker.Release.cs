#if !DEBUG

using System;
using System.Linq;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.Utils;
using System.Collections.Generic;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.RuntimeContext;
using ND.MTI.Gonio.Service.Worker.Serial;

namespace ND.MTI.Gonio.Service.Worker
{
    public class GonioWorker : SerialCore, IGonioWorker
    {
        private const string ResetCommand = "!";
        private const string MeasureCommand = "M";

        private static IGonioWorker _instance;

        private GonioWorker()
        {
            var config = GonioConfiguration.GetInstance().FSM_GonioConfig;
            RuntimeContext.IsFSMGonioConnected = Connect(config);
        }

        public static IGonioWorker GetInstance()
        {
            if (_instance is null)
                _instance = new GonioWorker();

            return _instance;
        }

        public bool Connect(Complex_FSMGonioConfig fsmGonioConfig) => base.Connect(
            fsmGonioConfig.ComPortName,
            fsmGonioConfig.DataBits,
            fsmGonioConfig.SpeedInBaud,
            fsmGonioConfig.Parity,
            fsmGonioConfig.StopBits,
            fsmGonioConfig.WriteTimeout,
            fsmGonioConfig.ReadTimeout
        );

        public virtual double Measure() => MeasureInternal();
        public virtual double MeasureOperated() => MeasureOperatedInternal();
        public virtual double MeasureLumenanceOperated() => MeasureOperatedInternal() * Math.Pow(15, 2);

        private double MeasureOperatedInternal()
        {
            var userconfig = RuntimeContext.UserConfig;
            var results = new List<double>();

            foreach (var _ in Enumerable.Range(0, userconfig.MeasuresInSamePosition))
                results.Add(MeasureInternal());

            return MathUtils
                .Operate(results, userconfig.MeasuresInSamePositionOperation)
                .First(); // When RAW was selected.
        }

        private double MeasureInternal()
        {
            var result = SendCommandAndReadLine(MeasureCommand);

            return Parser.StringToDouble(result);
        }

        public virtual void Reset() => _ = SendCommandAndReadLine(ResetCommand);

    }
}

#endif
