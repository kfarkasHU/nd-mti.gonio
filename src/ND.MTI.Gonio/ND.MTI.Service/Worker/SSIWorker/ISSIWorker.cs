using ND.MTI.Gonio.Model;
using ND.MTI.Service.Worker.Serial;

namespace ND.MTI.Service.Worker.SSIWorker
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
