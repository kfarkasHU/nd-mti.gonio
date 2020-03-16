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
        public int Pokeys_ReadInterval => Parser.StringToInteger(GetConfigByKeyName("Pokeys_ReadInterval", "100"));

        public bool Application_ConnectGonioAuto => Parser.StringToBoolean(GetConfigByKeyName("Application_ConnectGonioAuto", "0"));
        public bool Application_ConnectPokeysAuto => Parser.StringToBoolean(GetConfigByKeyName("Application_ConnectPokeysAuto", "0"));

        public int Encoder_DecXEnd => Parser.StringToInteger(GetConfigByKeyName("Encoder_DecXEnd", "1800"));
        public int Encoder_IncXEnd => Parser.StringToInteger(GetConfigByKeyName("Encoder_IncXEnd", "1800"));
        public int Encoder_MaxXEnc => Parser.StringToInteger(GetConfigByKeyName("Encoder_MaxXEnc", "4000"));
        public int Encoder_DecYEnd => Parser.StringToInteger(GetConfigByKeyName("Encoder_DecYEnd", "1800"));
        public int Encoder_IncYEnd => Parser.StringToInteger(GetConfigByKeyName("Encoder_IncYEnd", "1800"));
        public int Encoder_MaxYEnc => Parser.StringToInteger(GetConfigByKeyName("Encoder_MaxYEnc", "4000"));

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
