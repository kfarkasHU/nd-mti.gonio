using System;

namespace ND.MTI.Gonio.Common.Exceptions
{
    public class Gonio_EndpointException : Exception
    {
        public Gonio_EndpointException(int pinId) : base($"Endpoint reached at Pin: {pinId}")
        {

        }
    }
}
