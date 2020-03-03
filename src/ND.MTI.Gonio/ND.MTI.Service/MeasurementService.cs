using System.Threading;
using ND.MTI.Gonio.Model;
using ND.MTI.Service.Worker;
using System.Collections.Generic;
using ND.MTI.Gonio.ServiceInterface;
using ND.MTI.Gonio.Common.RuntimeContext;
using System.Linq;

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

        public MeasurementService()
        {
            _gonioWorker = new GonioWorker();
            _positionWorker = PositionWorker.GetInstance();
            _waitHandle = new ManualResetEvent(initialState: true);
        }


        public bool ConnectFsmGonio(Complex_FSMGonioConfig fsmGonioConfig) => _gonioWorker.Connect(fsmGonioConfig);
        public void DisconnectFsmGonio() => _gonioWorker.Disconnect();

        public bool ConnectPokeys57U() => _positionWorker.Connect();
        public void DisconnectPokeys75U() => _positionWorker.Disconnect();

        public void Configure(Complex_MainModel mainModel) => _config = mainModel;

        public void Continue() => _waitHandle.Set();

        public void Pause() => _waitHandle.Reset();

        public void Start()
        {
            CalculatePositionMatrix();

            _thread = new Thread(WorkingThreadImplementation);
            _thread.IsBackground = true;
            _thread.Start();
            _waitHandle.Set();
        }

        public void Stop() => _thread.Abort();

        public void SetPositionVirtualZero() => SetPositionInternal(RuntimeContext.VirtualZeroPosition);

        public void SetPositionZero() => SetPositionInternal(RuntimeContext.ZeroPosition + RuntimeContext.VirtualZeroPosition);

        public void SetPosition(Primitive_Position position) => SetPositionInternal(position + RuntimeContext.VirtualZeroPosition);

        private void SetPositionInternal(Primitive_Position position) => _positionWorker.SetPosition(position);

        private void CalculatePositionMatrix()
        {
            _positionMatrix = new Primitive_PositionCollection();

            var xVector = CreateAxisVector(
                _config.Start.X,
                _config.End.X,
                _config.IsXAuto ? _config.StepX != 0 ? _config.StepX.Value : 0 : 0
            );

            var yVector = CreateAxisVector(
                _config.Start.Y,
                _config.End.Y,
                _config.IsYAuto ? _config.StepY != 0 ? _config.StepY.Value : 0 : 0
            );

            _positionMatrix = CreatePositions();

            Primitive_PositionCollection CreatePositions()
            {
                var list = new Primitive_PositionCollection();

                var xVect = xVector.OrderBy(m => m).ToList();
                var yVect = yVector.OrderBy(m => m).ToList();

                for (var iy = 0; iy < yVect.Count; iy++)
                    for (var ix = 0; ix < xVect.Count; ix++)
                        list.Add(new Primitive_Position(xVect[ix], yVect[iy]));

                return list;
            }

            IList<double> CreateAxisVector(double start, double end, double step)
            {
                var list = new List<double>();

                if (start == end || step == 0)
                    return new List<double> { start };

                for (var cPos = start; cPos <= end; cPos += step)
                    list.Add(cPos);

                return list;
            }
        }

        private void WorkingThreadImplementation()
        {
            RuntimeContext.Results.Reset();

            for(var i = 0; i < _positionMatrix.Count; i++)
            {
                _ = _waitHandle.WaitOne();

                _positionWorker.SetPosition(_positionMatrix[i]);
                var position = _positionWorker.GetPosition();

                RuntimeContext
                    .AddResult(
                        new Complex_ResultItem(
                            position.X,
                            position.Y,
                            _positionMatrix[i].X,
                            _positionMatrix[i].Y,
                            _gonioWorker.Measure()
                    )
                );
            }
        }
    }
}
