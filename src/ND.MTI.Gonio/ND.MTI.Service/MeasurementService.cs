using System.Linq;
using System.Threading;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Service;
using ND.MTI.Service.Worker;
using System.Collections.Generic;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Service
{
    public class MeasurementService : IMeasurementService
    {
        private Thread _thread;
        private Complex_MainModel _config;
        private Primitive_PositionCollection _positionMatrix;

        private readonly IGonioWorker _gonioWorker;
        private readonly EventWaitHandle _waitHandle;
        private readonly IPositionWorker _positionWorker;

        public string State { get; private set; }

        public MeasurementService()
        {
            _gonioWorker = GonioWorker.GetInstance();
            _positionWorker = PositionWorker.GetInstance();
            _waitHandle = new ManualResetEvent(initialState: true);
        }

        public void Configure(Complex_MainModel mainModel) => _config = mainModel;

        public void Continue()
        {
            _waitHandle.Set();

            State = "RUNNING";
        }

        public void Pause()
        {
            _waitHandle.Reset();

            State = "PAUSED";
        }

        public void Start()
        {
            CalculatePositionMatrix();

            _thread = new Thread(WorkingThreadImplementation);
            _thread.IsBackground = true;
            _thread.Start();
            _waitHandle.Set();

            State = "RUNNING";
        }

        public void Stop()
        {
            _positionWorker.StopX();
            _positionWorker.StopY();
            _thread.Abort();

            State = "STOPPED";
        }

        public void SetPositionVirtualZero() => SetPositionInternal(RuntimeContext.VirtualZeroPosition + RuntimeContext.ZeroPosition);

        public void SetPositionZero() => SetPositionInternal(RuntimeContext.ZeroPosition);

        public void EncoderZero() => _positionWorker.EncoderZero();

        public Primitive_Position GetPosition() => GetPositionInternal();

        public double Measure() => MeasureInternal();

        private void SetPositionInternal(Primitive_Position position) => _positionWorker.SetPosition(position);

        private void CalculatePositionMatrix()
        {
            _positionMatrix = new Primitive_PositionCollection();
            var xVect = CreateAxisVect(_config.Start.X, _config.End.X, _config.StepX);
            var yVect = CreateAxisVect(_config.Start.Y, _config.End.Y, _config.StepY);

            for (var ix = 0; ix < xVect.Count; ix++)
            {
                var yRelatives = ix % 2 == 0
                    ? yVect
                    : yVect
                        .Reverse()
                        .ToList();

                for (var iy = 0; iy < yRelatives.Count; iy++)
                    _positionMatrix.Add(new Primitive_Position(xVect[ix], yRelatives[iy]));
            }

            IList<double> CreateAxisVect(double start, double end, double? step)
            {
                if (start == end)
                    return new List<double>() { start };

                if(!step.HasValue)
                    return new List<double>() { start };

                var list = start > end
                    ? CreateAxisVectCore(start, end)
                    : CreateAxisVectCore(end, start)
                        .Reverse()
                        .ToList();

                return list;

                IList<double> CreateAxisVectCore(double bigger, double smaller)
                {
                    var coreList = new List<double>();

                    for (var current = bigger; current > smaller - step.Value; current -= step.Value)
                        coreList.Add(current);

                    return coreList;
                }
            }
        }

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

                RuntimeContext
                    .AddResult(
                        new Complex_ResultItem(
                            position.X,
                            position.Y,
                            MeasureInternal()
                    )
                ); ;
            }

            _config.OnFinishedCallback();
            State = "FINISHED";

            _thread.Abort();
        }
    }
}
