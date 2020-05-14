using System;

namespace ND.MTI.Gonio.Common.Exceptions
{
    public class Gonio_Exception : Exception
    {
        public Gonio_Exception(string message) : base(message)
        {

        }

        public Gonio_Exception(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
