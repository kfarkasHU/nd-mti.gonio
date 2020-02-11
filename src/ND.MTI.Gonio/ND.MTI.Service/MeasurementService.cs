using System;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.ServiceInterface;
using ND.MTI.Gonio.Common.RuntimeContext;
using ND.MTI.Service.Worker;

namespace ND.MTI.Service
{
    public class MeasurementService : IMeasurementService
    {
        private Complex_MainModel _config;
        private readonly IGonioWorker _gonioWorker;
        private readonly IPositionWorker _positionWorker;

        public MeasurementService()
        {
            _gonioWorker = new GonioWorker();
            _positionWorker = PositionWorker.GetInstance();
        }


        public bool ConnectFsmGonio(Complex_FSMGonioConfig fsmGonioConfig) => _gonioWorker.Connect(fsmGonioConfig);
        public void DisconnectFsmGonio() => _gonioWorker.Disconnect();

        public bool ConnectXMotor(Complex_MotorConfig xMotorConfig) => _positionWorker.ConnectXMotor(xMotorConfig);
        public void DisconnectXMotor() => _positionWorker.DisconnectXMotor();
        public bool ConnectYMotor(Complex_MotorConfig yMotorConfig) => _positionWorker.ConnectYMotor(yMotorConfig);
        public void DisconnectYMotor() => _positionWorker.DisconnectYMotor();

        public void Configure(Complex_MainModel mainModel) => _config = mainModel;

        public void Continue()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        /*
         * Algorithm:
         * - set next position (0.1%)
         * - measure
         * - go next position
         * 
         * If pause:
         *  - hold current position
         *  
         * Continue:
         *  - go next position
         *  
         *  Stop:
         *  - throw away stuff
         */

        public void SetPositionVirtualZero() => SetPositionInternal(RuntimeContext.VirtualZeroPosition);

        public void SetPositionZero() => SetPositionInternal(RuntimeContext.ZeroPosition + RuntimeContext.VirtualZeroPosition);

        public void SetPosition(Primitive_Position position) => SetPositionInternal(position + RuntimeContext.VirtualZeroPosition);

        private void SetPositionInternal(Primitive_Position position) => _positionWorker.SetPosition(position);
    }
}
