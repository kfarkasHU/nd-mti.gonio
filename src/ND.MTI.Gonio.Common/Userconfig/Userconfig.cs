using System.IO;
using System.Reflection;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.Utils;
using System.Collections.Generic;

namespace ND.MTI.Gonio.Common.Userconfig
{
    public class Userconfig : IUserconfig
    {
        private static IUserconfig _instance;

        private readonly string _configFileAbsolutePath;
        private readonly IDictionary<string, string> _configCache;

        private Userconfig()
        {
            _configFileAbsolutePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\userconfig.cfg";
            _configCache = new Dictionary<string, string>();

            CreateConfigCacheInternal();
        }

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

        internal static IUserconfig GetInstance()
        {
            if (_instance is null)
                _instance = new Userconfig();

            return _instance;
        }

        public Primitive_Userconfig UserConfig
        {
            get
            {
                _configCache.Clear();
                CreateConfigCacheInternal();

                var userconfig = new Primitive_Userconfig();

                userconfig.Amplification = Parser.StringToDouble(GetConfigByKeyName("User_Amplification", "0"));
                userconfig.Offset = Parser.StringToDouble(GetConfigByKeyName("User_Offset", "0"));
                userconfig.UseCorrection = Parser.StringToBoolean(GetConfigByKeyName("User_UseCorrection", "0"));
                userconfig.ExternalRouteFilePath = GetConfigByKeyName("ExternalRouteFilePath", string.Empty);
                userconfig.ResetToZero = Parser.StringToBoolean(GetConfigByKeyName("User_ResetToZero", "0"));
                userconfig.ResetToVZero = Parser.StringToBoolean(GetConfigByKeyName("User_ResetToVZero", "0"));
                userconfig.MeasuresInSamePosition = Parser.StringToInteger(GetConfigByKeyName("MeasuresIsSamePosition", "1"));
                userconfig.SendNotificationOnError = Parser.StringToBoolean(GetConfigByKeyName("SendNotificationOnError", "1"));
                userconfig.SendNotificationOnComplete = Parser.StringToBoolean(GetConfigByKeyName("SendNotificationOnComplete", "1"));
                userconfig.MeasuresInSamePositionOperation = Parser.StringToInteger(GetConfigByKeyName("MeasuresIsSamePositionOperation", "0"));

                return userconfig;
            }
        }

        public void SaveUserConfig(Primitive_Userconfig config)
        {
            var lines = new string[10];

            lines[0] = $"User_Amplification={config.Amplification}";
            lines[1] = $"User_Offset={config.Offset}";
            lines[2] = $"User_UseCorrection={config.UseCorrection}";
            lines[3] = $"ExternalRouteFilePath={config.ExternalRouteFilePath}";
            lines[4] = $"User_ResetToZero={config.ResetToZero}";
            lines[5] = $"User_ResetToVZero={config.ResetToVZero}";
            lines[6] = $"MeasuresIsSamePosition={config.MeasuresInSamePosition}";
            lines[7] = $"SendNotificationOnError={config.SendNotificationOnError}";
            lines[8] = $"SendNotificationOnComplete={config.SendNotificationOnComplete}";
            lines[9] = $"MeasuresIsSamePositionOperation={config.MeasuresInSamePositionOperation}";
            
            File.WriteAllLines(_configFileAbsolutePath, lines);
        }
    }
}
