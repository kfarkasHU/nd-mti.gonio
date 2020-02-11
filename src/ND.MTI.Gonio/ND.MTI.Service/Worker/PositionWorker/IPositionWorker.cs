using ND.MTI.Gonio.Model;

namespace ND.MTI.Service.Worker
{
    public interface IPositionWorker
    {
        bool ConnectXMotor(Complex_MotorConfig xMotorConfig);
        void DisconnectXMotor();
        bool ConnectYMotor(Complex_MotorConfig yMotorConfig);
        void DisconnectYMotor();

        void SetPosition(Primitive_Position position);

        void IncrementX(int step = 1);
        void DecrementX(int step = 1);
        void IncrementY(int step = 1);
        void DecrementY(int step = 1);

        Primitive_Position GetPosition();
    }
}
