using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Service.Worker.Serial;

namespace ND.MTI.Gonio.Service.Worker.SSIWorker
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
