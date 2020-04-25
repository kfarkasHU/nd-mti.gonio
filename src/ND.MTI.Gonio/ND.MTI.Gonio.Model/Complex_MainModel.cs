using System;

namespace ND.MTI.Gonio.Model
{
    public sealed class Complex_MainModel
    {
        public Complex_MainModel() => Reset();

        public Primitive_Position Start { get; set; }
        public Primitive_Position End { get; set; }
        public double? StepX { get; set; }
        public double? StepY { get; set; }
        public bool IsXAuto { get; set; }
        public bool IsYAuto { get; set; }
        public int HoldTime { get; set; }

        public void Reset()
        {
            Start = new Primitive_Position(0, 0);
            End = new Primitive_Position(0, 0);
            StepX = null;
            StepY = null;
            IsXAuto = false;
            IsYAuto = false;
            HoldTime = 0;
        }
    }
}
