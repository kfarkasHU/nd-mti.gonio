using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.Userconfig;

namespace ND.MTI.Gonio.Common.RuntimeContext
{
    public static class RuntimeContext
    {
        private static IUserconfig _userconfig;
        private static IGonioConfiguration _config;

        public static void Init()
        {
            _userconfig = Userconfig.Userconfig.GetInstance();
            _config = GonioConfiguration.GetInstance();

            ZeroPosition = new Primitive_Position(_config.Position_AbsoluteZeroX, _config.Position_AbsoluteZeroY);
            VirtualZeroPosition = new Primitive_Position(0, 0);

            Results = new Complex_ResultCollection();
        }

        public static Primitive_Position ZeroPosition { get; set; }
        public static Primitive_Position VirtualZeroPosition { get; set; }

        public static Complex_ResultCollection Results { get; private set; }

        public static bool IsFSMGonioConnected { get; set; } = false;
        public static bool IsSSIPanelConnected { get; set; } = false;
        public static bool IsPokeys57Connected { get; set; } = false;

        public static bool IsAdminContext { get; set; } = false;

        public static Primitive_Userconfig UserConfig
        {
            get
            {
                return _userconfig.UserConfig;
            }

            set
            {
                _userconfig.SaveUserConfig(value);
            }
        }
    }
}
