using System;

namespace ND.MTI.Gonio.Model
{
    public sealed class Complex_ResultItem
    {

        public Complex_ResultItem(double x, double y, double i, double correction)
        {
            Position = new Primitive_Position(x, y);
            MeasuredIllumination = i;
            Correction = correction;
            CorrectedIllumination = i * correction;
            Candela = CorrectedIllumination * Math.Pow(15, 2);
        }

        public Primitive_Position Position { get; private set; }
        public double MeasuredIllumination { get; private set; }
        public double Correction { get; private set; }
        public double CorrectedIllumination { get; private set; }
        public double Candela { get; private set; }
    }
}
