namespace ND.MTI.Gonio.Model
{
    public sealed class Complex_ResultItem
    {
        public Complex_ResultItem(double x, double y, double i)
        {
            Position = new Primitive_Position(x, y);
            MeasuredIllumination = i;
        }

        public Primitive_Position Position { get; private set; }
        public double MeasuredIllumination { get; private set; }
    }
}
