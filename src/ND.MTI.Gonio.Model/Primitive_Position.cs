using System;

namespace ND.MTI.Gonio.Model
{
    public sealed class Primitive_Position
    {
        public Primitive_Position(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public Primitive_Position RoundTo3() => new Primitive_Position(Math.Round(X, 3), Math.Round(Y, 3));

        public override string ToString() => $"X: {X} Y: {Y}";

        public bool CloseEnoughTo(Primitive_Position target, double precision) =>
            CloseEnoughToInternal(X, target.X, precision) &&
            CloseEnoughToInternal(Y, target.Y, precision);

        private bool CloseEnoughToInternal(double current, double target, double precision) =>
            target - precision < current &&
            target + precision > current;

        public static Primitive_Position operator +(Primitive_Position left, Primitive_Position right)
        {
            var sum = new Primitive_Position(0, 0);

            sum.X = left.X + right.X;
            sum.Y = left.Y + right.Y;

            return sum;
        }

        public static Primitive_Position operator -(Primitive_Position left, Primitive_Position right)
        {
            var sum = new Primitive_Position(0, 0);

            sum.X = left.X - right.X;
            sum.Y = left.Y - right.Y;

            return sum;
        }
    }
}
