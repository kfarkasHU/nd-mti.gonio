using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.ServiceInterface
{
    public interface IMeasurementService
    {
        void Configure(Complex_MainModel mainModel);
        void Start();
        void Stop();
        void Pause();
        void Continue();

        void SetPositionZero();
        void SetPositionVirtualZero();

        Primitive_Position GetPosition();
    }
}
