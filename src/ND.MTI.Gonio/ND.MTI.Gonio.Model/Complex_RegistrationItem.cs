using System;

namespace ND.MTI.Gonio.Model
{
    public sealed class Complex_RegistrationItem
    {
        public Complex_RegistrationItem(TimeSpan timeSpan, double data)
        {
            Time = timeSpan;
            Data = data;
        }

        public TimeSpan Time { get; private set; }
        public double Data { get; private set; }
    }
}
