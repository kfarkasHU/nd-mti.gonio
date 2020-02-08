using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.ServiceInterface
{
    public interface IMeasurementService
    {
        bool ConnectFsmGonio(Complex_FSMGonioConfig fsmGonioConfig);
        void DisconnectFsmGonio();

        void Configure(Complex_MainModel mainModel);
        void Start();
        void Stop();
        void Pause();
        void Continue();

        void SetPositionZero();
        void SetPositionVirtualZero();
    }
}
