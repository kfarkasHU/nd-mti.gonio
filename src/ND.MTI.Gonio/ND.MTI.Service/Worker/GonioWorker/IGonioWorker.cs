using ND.MTI.Gonio.Model;

namespace ND.MTI.Service.Worker
{
    public interface IGonioWorker
    {
        bool Connect(Complex_FSMGonioConfig fsmGonioConfig);
        void Disconnect();

        void Reset();
        double Measure();
    }
}
