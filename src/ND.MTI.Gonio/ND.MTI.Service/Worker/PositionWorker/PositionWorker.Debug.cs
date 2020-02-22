#if !DEBUG
using ND.MTI.Gonio.Model;
using System;
using System.Threading;

namespace ND.MTI.Service.Worker
{
    public class PositionWorker : IPositionWorker
    {
        private static IPositionWorker _instance { get; set; }

        private Primitive_Position _currentPosition { get; set; }

        private PositionWorker()
        {
            Thread.Sleep(500);

            var seedX = Guid
                        .NewGuid()
                        .GetHashCode();

            var seedY = Guid
                        .NewGuid()
                        .GetHashCode();

            var randomX = new Random(seedX);
            var randomY = new Random(seedY);

            _currentPosition = new Primitive_Position(randomX.NextDouble(), randomY.NextDouble());
        }

        public bool Connect(Complex_Pokeys57UConfig config) => true;

        public void Disconnect()
        {

        }

        public static IPositionWorker GetInstance()
        {
            if (_instance is null)
                _instance = new PositionWorker();

            return _instance;
        }

        public Primitive_Position GetPosition() => _currentPosition;

        public void SetPosition(Primitive_Position position) => _currentPosition = position;

        public void DecrementY() => _currentPosition.Y -= 1;
        public void DecrementX() => _currentPosition.X -= 1;
        public void IncrementY() => _currentPosition.Y += 1;
        public void IncrementX() => _currentPosition.X += 1;
    }
}
#endif
