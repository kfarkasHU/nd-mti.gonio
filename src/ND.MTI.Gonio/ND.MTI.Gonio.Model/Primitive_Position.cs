namespace ND.MTI.Gonio.Model
{
    public class Primitive_Position
    {
        public double X { get; set; }
        public double Y { get; set; }

        public static Primitive_Position operator +(Primitive_Position left, Primitive_Position right)
        {
            var sum = new Primitive_Position();

            sum.X = left.X + right.X;
            sum.Y = left.Y + right.Y;

            return sum;
        }
    }
}
