using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Model.Enum;

namespace ND.MTI.Gonio.Service
{
    public interface IMeasurementService
    {
        MeasurementStatus State { get; }
        int NumberOfSteps { get; }
        int CurrentStepNumber { get; }

        void Configure(Complex_MainModel mainModel);
        void Start();
        void Stop();
        void Pause();
        void Continue();

        void EncoderZero();
        void SetReady();

        Primitive_Position GetPosition();
        double MeasureLumenance();
    }
}
