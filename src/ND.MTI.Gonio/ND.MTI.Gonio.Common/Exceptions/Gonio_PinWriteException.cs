namespace ND.MTI.Gonio.Common.Exceptions
{
    public class Gonio_PinWriteException : Gonio_PinException
    {
        public Gonio_PinWriteException(int pinNumber) : base($"Error when writing PIN{pinNumber}")
        {

        }
    }
}
