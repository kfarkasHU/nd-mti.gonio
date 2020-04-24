using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.Common.Configuration
{
    public interface IGonioConfiguration
    {
        Complex_FSMGonioConfig FSM_GonioConfig { get; }
        Complex_SSIConfig SSI_Config { get; }
        int Pokeys_ReadInterval { get; }

        double Position_AbsoluteZeroX { get; }
        double Position_AbsoluteZeroY { get; }

        double Encoder_Precision { get; }
        double Excel_Precision { get; }
    }
}
