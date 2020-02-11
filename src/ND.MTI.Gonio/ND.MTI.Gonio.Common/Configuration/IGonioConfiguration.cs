using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.Common.Configuration
{
    public interface IGonioConfiguration
    {
        Complex_FSMGonioConfig FsmGonioConfig { get; }
        double PrecisionPercentage { get; }
        Complex_MotorConfig XMotorConfig { get; }
        Complex_MotorConfig YMotorConfig { get; }
        double SensorDistance { get; }
    }
}
