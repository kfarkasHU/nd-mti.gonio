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

        public double Sensor_Distance => Parser.StringToDouble(GetConfigByKeyName("Sensor_Distance", "15"));

        public int Encoder_XMin => GrayUtils.GrayToInteger(GetConfigByKeyName("Encoder_XMin", "100"));
        public int Encoder_XMax => GrayUtils.GrayToInteger(GetConfigByKeyName("Encoder_XMax", "1000"));
        public int Encoder_XFullSpectrum => Parser.StringToInteger(GetConfigByKeyName("Encoder_XFullSpectrum", "340"));
        public int Encoder_YMin => GrayUtils.GrayToInteger(GetConfigByKeyName("Encoder_YMin", "0"));
        public int Encoder_YMax => GrayUtils.GrayToInteger(GetConfigByKeyName("Encoder_YMax", "1000"));
        public int Encoder_YFullSpectrum => Parser.StringToInteger(GetConfigByKeyName("Encoder_YFullSpectrum", "340"));

        public uint PWM_StartFrequency => Parser.StringToUInteger(GetConfigByKeyName("PWM_StartFrequency", "2500"));
        public uint PWM_EndFrequency => Parser.StringToUInteger(GetConfigByKeyName("PWM_EndFrequency", "40000"));
        public uint PWM_FrequencyStep => Parser.StringToUInteger(GetConfigByKeyName("PWM_FrequencyStep", "125"));
        public int PWM_TimeStep => Parser.StringToInteger(GetConfigByKeyName("PWM_TimeStep", "3"));
        public double PWM_DutyScale => Parser.StringToDouble(GetConfigByKeyName("PWM_DutyScale", "0,5"));

        public int Pokeys_ReservedTimeoutMs => Parser.StringToInteger(GetConfigByKeyName("Pokeys_ReservedTimeoutMs", "5"));
        public int Pokeys_DirectionTimeoutMs => Parser.StringToInteger(GetConfigByKeyName("Pokeys_DirectionTimeoutMs", "5"));
        public int Pokeys_EnableTimeoutMs => Parser.StringToInteger(GetConfigByKeyName("Pokeys_EnableTimeoutMs", "5"));
        public int Pokeys_ReadInterval => Parser.StringToInteger(GetConfigByKeyName("Pokeys_ReadInterval", "100"));

        public bool Application_ConnectGonioAuto => Parser.StringToBoolean(GetConfigByKeyName("Application_ConnectGonioAuto", "0"));

        public bool Application_ConnectPokeysAuto => Parser.StringToBoolean(GetConfigByKeyName("Application_ConnectPokeysAuto", "0"));

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
