namespace ND.MTI.Gonio.Common.Exceptions
{
    public class Gonio_PinInitException : Gonio_PinException
    {
        public Gonio_PinInitException(byte pinNumber, byte pinFunction) : base($"PIN init error. PIN{pinNumber}, as {pinFunction}")
        {

        }
    }
}
