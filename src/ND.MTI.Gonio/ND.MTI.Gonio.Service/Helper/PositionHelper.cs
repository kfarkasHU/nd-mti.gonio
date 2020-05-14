using System;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Service.Helper
{
    public static class PositionHelper
    {
        /// <summary>
        ///  Returns the difference between the given position and the absolute zero position.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns></returns>
        public static Primitive_Position CurrentPositionToAbsoluteZero(Primitive_Position currentPosition) => currentPosition + RuntimeContext.VirtualZeroPosition;
        public static Primitive_Position VirtualZeroPosition() => new Primitive_Position(0, 0);//RuntimeContext.VirtualZeroPosition;
        public static Primitive_Position AbsoluteZeroPosition() => new Primitive_Position(0, 0) - RuntimeContext.VirtualZeroPosition;

        public static Primitive_Position Normalise(Primitive_Position currentPosition)
        {
            currentPosition -= RuntimeContext.VirtualZeroPosition;
            currentPosition += RuntimeContext.ZeroPosition;

            return currentPosition;
        }
    }
}
