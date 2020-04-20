﻿using System;

namespace ND.MTI.Gonio.Model
{
    public sealed class Primitive_Position
    {
        public Primitive_Position(double x, double y)
        {
            X = Math.Round(x, 2);
            Y = Math.Round(y, 2);
        }

        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString() => $"X: {X} Y: {Y}";

        public static Primitive_Position operator +(Primitive_Position left, Primitive_Position right)
        {
            var sum = new Primitive_Position(0, 0);

            sum.X = left.X + right.X;
            sum.Y = left.Y + right.Y;

            return sum;
        }
    }
}
