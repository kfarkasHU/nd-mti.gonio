using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.Common.Configuration
{
    public interface IGonioConfiguration
    {
        Complex_FSMGonioConfig FSM_GonioConfig { get; }
        double Sensor_Distance { get; }
        int Pokeys_ReadInterval { get; }

        int Encoder_DecXEnd { get; }
        int Encoder_IncXEnd { get; }
        int Encoder_MaxXEnc { get; }

        int Encoder_DecYEnd { get; }
        int Encoder_IncYEnd { get; }
        int Encoder_MaxYEnc { get; }

        bool Application_ConnectGonioAuto { get; }
        bool Application_ConnectPokeysAuto { get; }
    }
}
