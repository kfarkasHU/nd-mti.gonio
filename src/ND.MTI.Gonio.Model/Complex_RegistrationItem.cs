﻿using System;

namespace ND.MTI.Gonio.Model
{
    public sealed class Complex_RegistrationItem
    {
        public Complex_RegistrationItem(TimeSpan timeSpan, double data, double delta)
        {
            Time = timeSpan;
            Data = data;
            Delta = delta;
        }

        public TimeSpan Time { get; private set; }
        public double Data { get; private set; }
        public double Delta { get; private set; }
    }
}
