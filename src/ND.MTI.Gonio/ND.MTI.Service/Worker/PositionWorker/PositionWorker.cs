using ND.MTI.Gonio.Common.RuntimeContext;
using ND.MTI.Gonio.Model;
using ND.MTI.Service.Worker.Motor;

namespace ND.MTI.Service.Worker
{
    public class PositionWorker : IPositionWorker
    {
        private readonly IMotorWorker _xMotorWorker;
        private readonly IMotorWorker _yMotorWorker;

        private static IPositionWorker _instance { get; set; }

        private PositionWorker()
        {
            _xMotorWorker = new MotorWorker();
            _yMotorWorker = new MotorWorker();
        }

        public static IPositionWorker GetInstance()
        {
            if (_instance is null)
                _instance = new PositionWorker();

            return _instance;
        }

        public bool ConnectXMotor(Complex_MotorConfig xMotorConfig) => _xMotorWorker.Connect(xMotorConfig);
        public void DisconnectXMotor() => _xMotorWorker.Disconnect();
        public bool ConnectYMotor(Complex_MotorConfig yMotorConfig) => _yMotorWorker.Connect(yMotorConfig);
        public void DisconnectYMotor() => _yMotorWorker.Disconnect();

        public Primitive_Position GetPosition()
        {
            var position = new Primitive_Position();

            position.X = _xMotorWorker.GetPosition();
            position.Y = _yMotorWorker.GetPosition();

            return position + RuntimeContext.VirtualZeroPosition;
        }


        public void IncrementX(int step = 1) => _xMotorWorker.IncrementPosition(step);
        public void DecrementX(int step = 1) => _xMotorWorker.DecrementPosition(step);
        public void IncrementY(int step = 1) => _yMotorWorker.IncrementPosition(step);
        public void DecrementY(int step = 1) => _yMotorWorker.DecrementPosition(step);

        public void SetPosition(Primitive_Position position)
        {
            _xMotorWorker.SetPosition(position.X);
            _yMotorWorker.SetPosition(position.Y);
        }
    }
}
