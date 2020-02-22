#if !DEBUG

using ND.MTI.Gonio.Model;
using ND.MTI.Service.Worker.Serial;

namespace ND.MTI.Service.Worker
{
    public class GonioWorker : SerialCore, IGonioWorker
    {
        public bool Connect(Complex_FSMGonioConfig fsmGonioConfig) => base.Connect(
            fsmGonioConfig.ComPortName,
            fsmGonioConfig.DataBits,
            fsmGonioConfig.SpeedInBaud,
            fsmGonioConfig.Parity,
            fsmGonioConfig.StopBits,
            fsmGonioConfig.WriteTimeout,
            fsmGonioConfig.ReadTimeout
        );

        public override double Measure() => base.Measure();

        public override void Reset() => base.Reset();
    }
}

#endif
