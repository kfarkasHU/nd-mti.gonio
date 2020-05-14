using ND.MTI.Gonio.Model;
using System.Collections.Generic;

namespace ND.MTI.Gonio.Common.Configuration
{
    public interface IGonioConfiguration
    {
        Complex_FSMGonioConfig FSM_GonioConfig { get; }
        Complex_SSIConfig SSI_Config { get; }
        int Pokeys_ReadInterval { get; }

        double Position_AbsoluteZeroX { get; }
        double Position_AbsoluteZeroY { get; }
        double Position_SpeedThreshold { get; }

        double Encoder_Precision { get; }
        double Excel_Precision { get; }

        double Endpoint_XMin { get; }
        double Endpoint_XMax { get; }
        double Endpoint_YMin { get; }
        double Endpoint_YMax { get; }

        int Notification_Email_SMTPPort { get; }
        bool Notification_Email_SMTPSSLEnabled { get; }
        string Notification_Email_SMTPAddress { get; }
        string Notification_Email_SMTPUsername { get; }
        string Notification_Email_SMTPPassword { get; }
        string Notification_Email_FromDisplayName { get; }
        string Notification_Email_FromEmailAddress { get; }
        IList<string> Notification_Email_TargetAddresses { get; }
        string Notification_Email_ApplicationErrorSubject { get; }
        string Notification_Email_ApplicationErrorHTMLTemplate { get; }
        string Notification_Email_MeasurementFinishedSubject { get; }
        string Notification_Email_MeasurementFinishedHTMLTemplate { get; }
    }
}
