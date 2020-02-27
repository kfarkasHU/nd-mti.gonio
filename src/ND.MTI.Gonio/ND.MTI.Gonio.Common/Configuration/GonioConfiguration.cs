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
            _configFileAbsolutePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\gonio.config";
            _configCache = new Dictionary<string, string>();

            CreateConfigCacheInternal();
        }

        public static IGonioConfiguration GetInstance()
        {
            if (_instance is null)
                _instance = new GonioConfiguration();

            return _instance;
        }

        public Complex_FSMGonioConfig FsmGonioConfig
        {
            get
            {
                var cfg = new Complex_FSMGonioConfig();

                cfg.ComPortName = GetConfigByKeyName("FSM_ComPortName");
                cfg.DataBits = Parser.StringToInteger(GetConfigByKeyName("FSM_DataBits"));
                cfg.Parity = Parser.StringIntToEnum<Parity>(GetConfigByKeyName("FSM_Parity"));
                cfg.ReadTimeout = Parser.StringToInteger(GetConfigByKeyName("FSM_ReadTimeout"));
                cfg.SpeedInBaud = Parser.StringToInteger(GetConfigByKeyName("FSM_SpeedInBaud"));
                cfg.WriteTimeout = Parser.StringToInteger(GetConfigByKeyName("FSM_WriteTimeout"));
                cfg.StopBits = Parser.StringIntToEnum<StopBits>(GetConfigByKeyName("FSM_StopBits"));

                return cfg;
            }
        }

        public double PrecisionPercentage => Parser.StringToDouble(GetConfigByKeyName("Motor_PrecisionPercentage"));

        public double SensorDistance => Parser.StringToDouble(GetConfigByKeyName("Sensor_Distance"));

        public int EncoderXMin => Parser.StringToInteger(GetConfigByKeyName("Encoder_XMin"));
        public int EncoderXMax => Parser.StringToInteger(GetConfigByKeyName("Encoder_XMax"));
        public int EncoderXFullSpectrum => Parser.StringToInteger(GetConfigByKeyName("Encoder_XFullSpectrum"));
        public int EncoderYMin => Parser.StringToInteger(GetConfigByKeyName("Encoder_YMin"));
        public int EncoderYMax => Parser.StringToInteger(GetConfigByKeyName("Encoder_XMax"));
        public int EncoderYFullSpectrum => Parser.StringToInteger(GetConfigByKeyName("Encoder_YFullSpectrum"));

        public int PWMFrequencyDivider => Parser.StringToInteger(GetConfigByKeyName("PWM_FrequencyDivider"));

        private void CreateConfigCacheInternal()
        {
            var lines = File.ReadAllLines(_configFileAbsolutePath);

            foreach (var line in lines)
                CreateConfigItem(line);

            void CreateConfigItem(string line)
            {
                var keyValuePair = line.Split('=');
                _configCache.Add(keyValuePair[0], keyValuePair[1]);
            }
        }
        
        private string GetConfigByKeyName(string keyName)
        {
            _configCache.TryGetValue(keyName, out var val);

            return val;
        }
    }
}
