namespace ND.MTI.Gonio.Common.Exceptions
{
    public class Gonio_EndpointException : Gonio_Exception
    {
        public Gonio_EndpointException(string axis) : base($"Endpoint reached at AXIS: {axis.ToUpper()}")
        {
        }
    }
}
