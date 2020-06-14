using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Model.Enum;

namespace ND.MTI.Gonio.ServiceInterface
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
        void SetRunning();

        Primitive_Position GetPosition();
        double MeasureLumenance();
    }
}
