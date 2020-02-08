using ND.MTI.Gonio.Model;
using System.Windows.Forms;

namespace ND.MTI.Gonio.Common.RuntimeContext
{
    public static class RuntimeContext
    {
        public static void Init()
        {
            ZeroPosition = new Primitive_Position();
            ZeroPosition.X = 0;
            ZeroPosition.Y = 0;

            VirtualZeroPosition = new Primitive_Position();
            ZeroPosition.X = 0;
            ZeroPosition.Y = 0;

            Status = Status.Stopped;
            Results = new Complex_ResultCollection();
        }

        public static Form LoadFormInstance { get; set; }
        public static Primitive_Position ZeroPosition { get; set; }
        public static Primitive_Position VirtualZeroPosition { get; set; }
        public static Status Status { get; set; }
        public static Complex_ResultCollection Results { get; set; }
        public static bool FsmGonioConnected { get; set; }
        public static bool XConnected { get; set; }
        public static bool YConnected { get; set; }
    }
}
