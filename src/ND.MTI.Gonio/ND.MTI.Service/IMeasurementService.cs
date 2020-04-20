using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.Service
{
    public interface IMeasurementService
    {
        string State { get; }

        void Configure(Complex_MainModel mainModel);
        void Start();
        void Stop();
        void Pause();
        void Continue();

        void EncoderZero();
        void SetPositionZero();
        void SetPositionVirtualZero();

        Primitive_Position GetPosition();
        double Measure();
    }
}
