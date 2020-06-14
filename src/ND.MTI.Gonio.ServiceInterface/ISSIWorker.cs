using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.ServiceInterface
{
    public interface ISSIWorker : ISerialCore
    {
        string ResponseX { get; }
        string ResponseY { get; }

        bool Connect(Complex_SSIConfig config);
        void ZeroX();
        void ZeroY();
    }
}
