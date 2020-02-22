using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.ServiceInterface
{
    public interface IMeasurementService
    {
        bool ConnectFsmGonio(Complex_FSMGonioConfig fsmGonioConfig);
        void DisconnectFsmGonio();

        bool ConnectPokeys57U();
        void DisconnectPokeys75U();

        void Configure(Complex_MainModel mainModel);
        void Start();
        void Stop();
        void Pause();
        void Continue();

        void SetPosition(Primitive_Position position);
        void SetPositionZero();
        void SetPositionVirtualZero();
    }
}
