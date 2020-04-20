using ND.MTI.Gonio.Model;
using System.Windows.Forms;
using System.ComponentModel;
using ND.MTI.Gonio.Common.Configuration;

namespace ND.MTI.Gonio.Common.RuntimeContext
{
    public static class RuntimeContext
    {
        private static IGonioConfiguration _config;

        public static void Init()
        {
            _config = GonioConfiguration.GetInstance();

            ZeroPosition = new Primitive_Position(_config.Position_AbsoluteZeroX, _config.Position_AbsoluteZeroY);
            VirtualZeroPosition = new Primitive_Position(0, 0);

            Results = new Complex_ResultCollection();
            ResultsBindingList = new BindingList<Complex_ResultItem>(Results);
        }

        public static Form LoadFormInstance { get; set; }
        public static Primitive_Position ZeroPosition { get; set; }
        public static Primitive_Position VirtualZeroPosition { get; set; }
        public static void AddResult(Complex_ResultItem resultItem) => Results.Add(resultItem);

        public static Complex_ResultCollection Results { get; private set; }
        public static BindingList<Complex_ResultItem> ResultsBindingList { get; private set; }
    }
}
