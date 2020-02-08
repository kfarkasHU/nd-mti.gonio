using ND.MTI.Gonio.Model;
using ND.MTI.Service.Worker.Motor;

namespace ND.MTI.Service.Worker
{
    public class PositionWorker : IPositionWorker
    {
        private readonly IMotorWorker _xMotorWorker;
        private readonly IMotorWorker _yMotorWorker;

        public PositionWorker()
        {
            _xMotorWorker = new MotorWorker();
            _yMotorWorker = new MotorWorker();
        }

        public Primitive_Position GetPosition()
        {
            var position = new Primitive_Position();
            position.X = _xMotorWorker.GetPosition();
            position.Y = _yMotorWorker.GetPosition();

            return position;
        }

        public void SetPosition(Primitive_Position position)
        {
            _xMotorWorker.SetPosition(position.X);
            _yMotorWorker.SetPosition(position.Y);
        }
    }
}
