using System;
using System.Linq;
using System.Threading;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Model.Enum;
using ND.MTI.Gonio.Service.Worker;
using ND.MTI.Gonio.Service.Helper;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Service
{
    public class MeasurementService : IMeasurementService
    {
        private Thread _thread;
        private Complex_MainModel _config;
        private Primitive_PositionCollection _positionMatrix;

        private readonly IGonioWorker _gonioWorker;
        private readonly EventWaitHandle _waitHandle;
        private readonly IPositionWorker _positionWorker;
        private readonly IGonioConfiguration _gonioConfiguration;
        private readonly MeasurementServiceHelper _measurementServiceHelper;

        public MeasurementStatus State { get; private set; } = MeasurementStatus.READY;

        public MeasurementService()
        {
            _gonioWorker = GonioWorker.GetInstance();
            _positionWorker = PositionWorker.GetInstance();
            _waitHandle = new ManualResetEvent(initialState: true);
            _gonioConfiguration = GonioConfiguration.GetInstance();
            _measurementServiceHelper = MeasurementServiceHelper.GetInstance();
        }

        public void Configure(Complex_MainModel mainModel) => _config = mainModel;

        public double MeasureLumenance() => MeasureInternal() * Math.Pow(15, 2);

        public void Continue()
        {
            _waitHandle.Set();

            State = MeasurementStatus.RUNNING;
        }

        public void Pause()
        {
            _waitHandle.Reset();

            State = MeasurementStatus.PAUSED;
        }

        public void Start()
        {
            _positionMatrix = PositionMatrixHelper.CalculatePositionMatrix(_config);
            if (_config.Userconfig.ExternalRouteFilePath != string.Empty)
                _positionMatrix = PositionMatrixHelper.GetRouteFrom(_config.Userconfig.ExternalRouteFilePath);

            _positionMatrix = _positionMatrix.RemoveDuplicates();

            _thread = new Thread(WorkingThreadImplementation);
            _thread.IsBackground = true;
            _thread.Start();
            _waitHandle.Set();

            State = MeasurementStatus.RUNNING;
        }

        public void Stop()
        {
            _positionWorker.StopX();
            _positionWorker.StopY();
            _thread.Abort();

            State = MeasurementStatus.READY;
        }
        
        public void EncoderZero() => _positionWorker.EncoderZero();

        public Primitive_Position GetPosition() => GetPositionInternal();
        
        private void SetPositionInternal(Primitive_Position position) => _positionWorker.SetPosition(position);        

        private Primitive_Position GetPositionInternal() => _positionWorker.GetPosition();

        private double MeasureInternal() => _gonioWorker.Measure();

        private void WorkingThreadImplementation()
        {
            RuntimeContext.Results.Clear();

            var position = GetPositionInternal();
            for(var i = 0; i < _positionMatrix.Count; i++)
            {
                _ = _waitHandle.WaitOne();

                if (!position.CloseEnoughTo(_positionMatrix[i], _gonioConfiguration.Excel_Precision))
                {
                    SetPositionInternal(_positionMatrix[i]);
                    position = GetPositionInternal();
                }

                foreach(var _ in Enumerable.Range(0, _config.Userconfig.MeasuresInSamePosition))
                {
                    Thread.Sleep(_config.HoldTime);

                    var measured = MeasureInternal();
                    var correction = _config.Userconfig.UseCorrection
                        ? _measurementServiceHelper.GetCorrectionValue(measured)
                        : 1;

                    if (_config.Userconfig.Amplification > 0)
                        measured *= _config.Userconfig.Amplification;

                    measured += _config.Userconfig.Offset;

                    RuntimeContext
                        .AddResult(
                            new Complex_ResultItem(
                                position.X,
                                position.Y,
                                measured,
                                correction
                        )
                    );
                }
            }

            if (_config.Userconfig.ResetToZero)
                SetPositionInternal(new Primitive_Position(0, 0) - RuntimeContext.VirtualZeroPosition);

            if (_config.Userconfig.ResetToVZero)
                SetPositionInternal(GetPositionInternal() - RuntimeContext.VirtualZeroPosition);

            State = MeasurementStatus.READY;

            _thread.Abort();
        }
    }
}
