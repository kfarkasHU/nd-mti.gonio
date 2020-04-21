using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Model.Enum;

namespace ND.MTI.Gonio.Service
{
    public interface IMeasurementService
    {
        MeasurementStatus State { get; }

        void Configure(Complex_MainModel mainModel);
        void Start();
        void Stop();
        void Pause();
        void Continue();

        void EncoderZero();

        Primitive_Position GetPosition();
    }
}
