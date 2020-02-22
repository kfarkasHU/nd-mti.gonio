using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.Common.Configuration
{
    public interface IGonioConfiguration
    {
        Complex_FSMGonioConfig FsmGonioConfig { get; }
        double PrecisionPercentage { get; }
        double SensorDistance { get; }
        int EncoderXMin { get; }
        int EncoderXMax { get; }
        int EncoderXFullSpectrum { get; }
        int EncoderYMin { get; }
        int EncoderYMax { get; }
        int EncoderYFullSpectrum { get; }
    }
}
