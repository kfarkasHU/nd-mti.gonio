using ND.MTI.Gonio.Model;
using System.ComponentModel;
using System.Windows.Forms;

namespace ND.MTI.Gonio.Common.RuntimeContext
{
    public static class RuntimeContext
    {
        public static void Init()
        {
            ZeroPosition = new Primitive_Position(0, 0);
            VirtualZeroPosition = new Primitive_Position(0, 0);

            Status = Status.Stopped;
            Results = new Complex_ResultCollection();
            ResultsBindingList = new BindingList<Complex_ResultItem>(Results);
        }

        public static Form LoadFormInstance { get; set; }
        public static Primitive_Position ZeroPosition { get; set; }
        public static Primitive_Position VirtualZeroPosition { get; set; }
        public static Status Status { get; set; }
        public static void AddResult(Complex_ResultItem resultItem) => Results.Add(resultItem);

        public static Complex_ResultCollection Results { get; private set; }
        public static BindingList<Complex_ResultItem> ResultsBindingList { get; private set; }
        public static bool FsmGonioConnected { get; set; }
        public static bool Pokeys57UConnected { get; set; }
    }
}
