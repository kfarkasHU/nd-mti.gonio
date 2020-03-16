using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.Common.Configuration
{
    public interface IGonioConfiguration
    {
        Complex_FSMGonioConfig FSM_GonioConfig { get; }
        double Sensor_Distance { get; }
        int Encoder_XMin { get; }
        int Encoder_XMax { get; }
        int Encoder_XFullSpectrum { get; }
        int Encoder_YMin { get; }
        int Encoder_YMax { get; }
        int Encoder_YFullSpectrum { get; }
        uint PWM_StartFrequency { get; }
        uint PWM_EndFrequency { get; }
        uint PWM_FrequencyStep { get; }
        int PWM_TimeStep { get; }
        double PWM_DutyScale { get; }
        int Pokeys_ReservedTimeoutMs { get; }
        int Pokeys_DirectionTimeoutMs { get; }
        int Pokeys_EnableTimeoutMs { get; }
        int Pokeys_ReadInterval { get; }

        bool Application_ConnectGonioAuto { get; }
        bool Application_ConnectPokeysAuto { get; }
    }
}
