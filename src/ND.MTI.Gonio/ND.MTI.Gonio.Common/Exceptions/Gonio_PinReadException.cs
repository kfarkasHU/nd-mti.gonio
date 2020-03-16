namespace ND.MTI.Gonio.Common.Exceptions
{
    public class Gonio_PinReadException : Gonio_PinException
    {
        public Gonio_PinReadException(int pinNumber) : base($"Error when reading PIN{pinNumber}")
        {

        }
    }
}
