#if !DEBUG

using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Model;
using ND.MTI.Service.Worker.Serial;

namespace ND.MTI.Service.Worker
{
    public class GonioWorker : SerialCore, IGonioWorker
    {
        private const string ResetCommand = "!";
        private const string MeasureCommand = "M";

        private static IGonioWorker _instance;

        private GonioWorker()
        {

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

        public virtual double Measure()
        {
            var result = SendCommandAndReadLine(MeasureCommand);

            return Parser.StringToDouble(result);
        }

        public virtual void Reset() => _ = SendCommandAndReadLine(ResetCommand);

    }
}

#endif
