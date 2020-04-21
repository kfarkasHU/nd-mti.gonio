using System.Threading;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Model.Enum;
using ND.MTI.Gonio.Service.Worker;
using ND.MTI.Gonio.Service.Helper;
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
        private readonly MeasurementServiceHelper _measurementServiceHelper;

        public MeasurementStatus State { get; private set; } = MeasurementStatus.READY;

        public MeasurementService()
        {
            _gonioWorker = GonioWorker.GetInstance();
            _positionWorker = PositionWorker.GetInstance();
            _waitHandle = new ManualResetEvent(initialState: true);
            _measurementServiceHelper = MeasurementServiceHelper.GetInstance();
        }

        public void Configure(Complex_MainModel mainModel) => _config = mainModel;

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
            if (_config.HasExternalRoute)
                _positionMatrix = PositionMatrixHelper.GetRouteFrom(_config.ExternalRoute);

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

            for(var i = 0; i < _positionMatrix.Count; i++)
            {
                _ = _waitHandle.WaitOne();

                SetPositionInternal(_positionMatrix[i]);
                var position = GetPositionInternal();

                Thread.Sleep(_config.HoldTime);

                var measured = MeasureInternal();
                var correction = _measurementServiceHelper.GetCorrectionValue(measured);

                RuntimeContext
                    .AddResult(
                        new Complex_ResultItem(
                            position.X,
                            position.Y,
                            measured,
                            correction
                    )
                ); ;
            }

            State = MeasurementStatus.READY;

            _thread.Abort();
        }
    }
}
