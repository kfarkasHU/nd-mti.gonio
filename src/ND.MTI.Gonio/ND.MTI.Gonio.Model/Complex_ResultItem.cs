namespace ND.MTI.Gonio.Model
{
    public class Complex_ResultItem
    {
        public Complex_ResultItem()
        {
            WantedPosition = new Primitive_Position();
            RealPosition = new Primitive_Position();
        }

        public Primitive_Position WantedPosition { get; set; }
        public Primitive_Position RealPosition { get; set; }
        public double MeasuredIllumination { get; set; }
    }
}
