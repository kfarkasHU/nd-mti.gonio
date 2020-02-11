using ND.MTI.Gonio.Model;

namespace ND.MTI.Service.Worker.Motor
{
    public interface IMotorWorker
    {
        bool Connect(Complex_MotorConfig motorConfig);
        void Disconnect();

        void IncrementPosition(int step = 1);
        void DecrementPosition(int step = 1);
        void SetPosition(double coordinate);
        double GetPosition();
    }
}
