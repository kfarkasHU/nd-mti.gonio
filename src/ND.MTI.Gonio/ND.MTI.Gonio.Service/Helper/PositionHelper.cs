using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Service.Helper
{
    public static class PositionHelper
    {
        public static Primitive_Position CurrentPositionToAbsoluteZero(Primitive_Position currentPosition) => currentPosition + RuntimeContext.VirtualZeroPosition;
        public static Primitive_Position VirtualZeroPositionToCurrent(Primitive_Position currentPosition) => currentPosition - RuntimeContext.VirtualZeroPosition;
        public static Primitive_Position AbsoluteZeroPosition() => new Primitive_Position(0, 0) - RuntimeContext.VirtualZeroPosition;

        public static Primitive_Position Normalise(Primitive_Position currentPosition)
        {
            currentPosition -= RuntimeContext.VirtualZeroPosition;
            currentPosition += RuntimeContext.ZeroPosition;

            return currentPosition;
        }
    }
}
