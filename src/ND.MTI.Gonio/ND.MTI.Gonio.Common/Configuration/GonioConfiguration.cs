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
        private readonly string _configFileAbsolutePath;
        private readonly IDictionary<string, string> _configCache;

        public GonioConfiguration()
        {
            _configFileAbsolutePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\gonio.config";
            _configCache = new Dictionary<string, string>();

            CreateConfigCacheInternal();
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
                cfg.StopBits = Parser.StringIntToEnum<StopBits>(GetConfigByKeyName("FSM_StopBits"));
                cfg.WriteTimeout = Parser.StringToInteger(GetConfigByKeyName("FSM_WriteTimeout"));

                return cfg;
            }
        }

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
