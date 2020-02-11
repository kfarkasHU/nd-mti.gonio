using System;
using ND.MTI.Gonio.Model;
using ND.MTI.Service.Worker.LPT;
using ND.MTI.Gonio.Common.Configuration;

namespace ND.MTI.Service.Worker.Motor
{
    public class MotorWorker : LPTCore, IMotorWorker
    {
        private readonly IGonioConfiguration _gonioConfiguration;

        public MotorWorker()
        {
            _gonioConfiguration = GonioConfiguration.GetInstance();
        }

        public bool Connect(Complex_MotorConfig motorConfig) => base.Connect();

        public new void Disconnect() => base.Disconnect();

        public void IncrementPosition(int step = 1) => IncrementPositionInternal(step);

        public void DecrementPosition(int step = 1) => DecrementPositionInternal(step);

        public double GetPosition() => GetPositionInternal();

        public void SetPosition(double coordinate) => SetPositionInternal(coordinate);

        private void IncrementPositionInternal(int step = 1) => SetPositionInternal(GetPositionInternal() + step);
        
        private void DecrementPositionInternal(int step = 1) => SetPositionInternal(GetPositionInternal() - step);

        private void SetPositionInternal(double coordinate)
        {
            throw new NotImplementedException();
        }

        private double GetPositionInternal()
        {
            throw new NotImplementedException();
        }
    }
}
