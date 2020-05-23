using System.IO;
using System.IO.Ports;
using System.Reflection;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.Utils;
using System.Collections.Generic;

namespace ND.MTI.Gonio.Common.Configuration
{
    public class GonioConfiguration : IGonioConfiguration
    {
        private static IGonioConfiguration _instance { get; set; }

        private readonly string _configFileAbsolutePath;
        private readonly IDictionary<string, string> _configCache;

        private GonioConfiguration()
        {
            _configFileAbsolutePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\gonio.cfg";
            _configCache = new Dictionary<string, string>();

            CreateConfigCacheInternal();
        }

        public static IGonioConfiguration GetInstance()
        {
            if (_instance is null)
                _instance = new GonioConfiguration();

            return _instance;
        }

        public Complex_FSMGonioConfig FSM_GonioConfig
        {
            get
            {
                var cfg = new Complex_FSMGonioConfig();

                cfg.ComPortName = GetConfigByKeyName("FSM_ComPortName", "COM3");
                cfg.DataBits = Parser.StringToInteger(GetConfigByKeyName("FSM_DataBits", "8"));
                cfg.Parity = Parser.StringIntToEnum<Parity>(GetConfigByKeyName("FSM_Parity", "0"));
                cfg.ReadTimeout = Parser.StringToInteger(GetConfigByKeyName("FSM_ReadTimeout", "500"));
                cfg.SpeedInBaud = Parser.StringToInteger(GetConfigByKeyName("FSM_SpeedInBaud", "38400"));
                cfg.WriteTimeout = Parser.StringToInteger(GetConfigByKeyName("FSM_WriteTimeout", "500"));
                cfg.StopBits = Parser.StringIntToEnum<StopBits>(GetConfigByKeyName("FSM_StopBits", "1"));

                return cfg;
            }
        }

        public Complex_SSIConfig SSI_Config
        {
            get
            {
                var cfg = new Complex_SSIConfig();

                cfg.ComPortName = GetConfigByKeyName("SSI_ComPortName", "COM6");
                cfg.DataBits = Parser.StringToInteger(GetConfigByKeyName("SSI_DataBits", "8"));
                cfg.Parity = Parser.StringIntToEnum<Parity>(GetConfigByKeyName("SSI_Parity", "0"));
                cfg.ReadTimeout = Parser.StringToInteger(GetConfigByKeyName("SSI_ReadTimeout", "500"));
                cfg.SpeedInBaud = Parser.StringToInteger(GetConfigByKeyName("SSI_SpeedInBaud", "115200"));
                cfg.WriteTimeout = Parser.StringToInteger(GetConfigByKeyName("SSI_WriteTimeout", "500"));
                cfg.StopBits = Parser.StringIntToEnum<StopBits>(GetConfigByKeyName("SSI_StopBits", "1"));

                return cfg;
            }
        }

        public int Pokeys_ReadInterval => Parser.StringToInteger(GetConfigByKeyName(nameof(Pokeys_ReadInterval), "100"));

        public double Position_AbsoluteZeroX => Parser.StringToDouble(GetConfigByKeyName(nameof(Position_AbsoluteZeroX), "0"));
        public double Position_AbsoluteZeroY => Parser.StringToDouble(GetConfigByKeyName(nameof(Position_AbsoluteZeroY), "0"));
        public double Position_SpeedThreshold => Parser.StringToDouble(GetConfigByKeyName(nameof(Position_SpeedThreshold), "10"));

        public double Encoder_Precision => Parser.StringToDouble(GetConfigByKeyName(nameof(Encoder_Precision), "0.1"));
        public double Excel_Precision => Parser.StringToDouble(GetConfigByKeyName(nameof(Excel_Precision), "0.1"));

        public double Endpoint_XMax => Parser.StringToDouble(GetConfigByKeyName(nameof(Endpoint_XMax), "176"));        
        public double Endpoint_XMin => Parser.StringToDouble(GetConfigByKeyName(nameof(Endpoint_XMin), "-176"));
        public double Endpoint_YMin => Parser.StringToDouble(GetConfigByKeyName(nameof(Endpoint_YMin), "-176"));
        public double Endpoint_YMax => Parser.StringToDouble(GetConfigByKeyName(nameof(Endpoint_YMax), "176"));

        public int MainForm_LuminousIntensityRefreshTimeInMs => Parser.StringToInteger(GetConfigByKeyName(nameof(MainForm_LuminousIntensityRefreshTimeInMs), "1000"));

        public int Notification_Email_SMTPPort => Parser.StringToInteger(GetConfigByKeyName(nameof(Notification_Email_SMTPPort), "587"));
        public bool Notification_Email_SMTPSSLEnabled => Parser.StringToBoolean(GetConfigByKeyName(nameof(Notification_Email_SMTPSSLEnabled), "1"));
        public string Notification_Email_SMTPAddress => GetConfigByKeyName(nameof(Notification_Email_SMTPAddress), "smtp.gmail.com");
        public string Notification_Email_SMTPUsername => GetConfigByKeyName(nameof(Notification_Email_SMTPUsername), "oekvk.gonio@gmail.com");
        public string Notification_Email_SMTPPassword => GetConfigByKeyName(nameof(Notification_Email_SMTPPassword), "xUpmWjT5wrEhtHmGYsEyFWLQLhjevMEtyxePxQk2FkkTLNVARcV7Gg76svXxk2zm");
        public string Notification_Email_FromDisplayName => GetConfigByKeyName(nameof(Notification_Email_FromDisplayName), "GonioApp");
        public string Notification_Email_FromEmailAddress => GetConfigByKeyName(nameof(Notification_Email_FromEmailAddress), "oekvk.gonio@gmail.com");
        public IList<string> Notification_Email_TargetAddresses => Parser.StringToStringList(GetConfigByKeyName(nameof(Notification_Email_TargetAddresses), "fenymeres@fenymeres.hu"));
        public string Notification_Email_ApplicationErrorHTMLTemplate => GetConfigByKeyName(nameof(Notification_Email_ApplicationErrorHTMLTemplate), "<p>Tisztelt C&iacute;mzett,</p><p>Az alkalmaz&aacute;s fut&aacute;sa sor&aacute;n {0} időpontban nem v&aacute;rt hiba l&eacute;pett fel.<br />A hiba r&eacute;szletei:</p><p style='font - family: courier;'>{1}</p><p><br />Tisztelettel,<br />GonioApp</p>");
        public string Notification_Email_MeasurementFinishedHTMLTemplate => GetConfigByKeyName(nameof(Notification_Email_MeasurementFinishedHTMLTemplate), "<p>Tisztelt C&iacute;mzett,</p><p>Az &Ouml;n &aacute;ltal {0} időpontban ind&iacute;tott m&eacute;r&eacute;s {1} időpontban sikeresen befejeződ&ouml;tt.</p><p><br />Tisztelettel,<br />GonioApp</p>");
        public string Notification_Email_ApplicationErrorSubject => GetConfigByKeyName(nameof(Notification_Email_ApplicationErrorSubject), "Error");
        public string Notification_Email_MeasurementFinishedSubject => GetConfigByKeyName(nameof(Notification_Email_MeasurementFinishedSubject), "Work complete");

        private void CreateConfigCacheInternal()
        {
            try
            {
                var lines = File.ReadAllLines(_configFileAbsolutePath);

                foreach (var line in lines)
                    CreateConfigItem(line);
            }
            catch (FileNotFoundException)
            {
            }

            void CreateConfigItem(string line)
            {
                var keyValuePair = line.Split('=');
                _configCache.Add(keyValuePair[0], keyValuePair[1]);
            }
        }
        
        private string GetConfigByKeyName(string keyName, string defaultValue)
        {
            var success = _configCache.TryGetValue(keyName, out var val);

            return success ? val : defaultValue;
        }
    }
}
