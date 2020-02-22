namespace ND.MTI.Gonio.Model
{
    public class Complex_ResultItem
    {
        public Complex_ResultItem()
        {
            WantedPosition = new Primitive_Position(0, 0);
            RealPosition = new Primitive_Position(0, 0);
        }

        public Complex_ResultItem(
                double wX,
                double wY,
                double rX,
                double rY,
                double mI
            )
        {
            WantedPosition = new Primitive_Position(wX, wY);
            RealPosition = new Primitive_Position(rX, rY);

            MeasuredIllumination = mI;
        }

        public Primitive_Position WantedPosition { get; set; }
        public Primitive_Position RealPosition { get; set; }
        public double MeasuredIllumination { get; set; }
    }
}
