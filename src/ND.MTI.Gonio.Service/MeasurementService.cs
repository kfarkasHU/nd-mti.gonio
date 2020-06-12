using System;
using System.Linq;
using System.Threading;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Notifier;
using ND.MTI.Gonio.Model.Enum;
using ND.MTI.Gonio.Service.Worker;
using ND.MTI.Gonio.Service.Helper;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.RuntimeContext;
using System.Collections;
using System.Collections.Generic;
using ND.MTI.Gonio.Common.Exceptions;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

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

        public int NumberOfSteps { get; private set; } = 0;
        public int CurrentStepNumber { get; private set; } = 0;
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
            NumberOfSteps = 0;
            CurrentStepNumber = 0;

            _positionMatrix = PositionMatrixHelper.CalculatePositionMatrix(_config);
            if (RuntimeContext.UserConfig.ExternalRouteFilePath != string.Empty)
                _positionMatrix = PositionMatrixHelper.GetRouteFrom(RuntimeContext.UserConfig.ExternalRouteFilePath);

            _positionMatrix = _positionMatrix.RemoveDuplicates();
            NumberOfSteps = _positionMatrix.Count * RuntimeContext.UserConfig.MeasuresInSamePosition;

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

        public void SetReady() => State = MeasurementStatus.READY;

        public void SetRunning() => State = MeasurementStatus.RUNNING;

        public Primitive_Position GetPosition() => GetPositionInternal();

        private void SetPositionInternal(Primitive_Position position) => _positionWorker.SetPosition(position);

        private Primitive_Position GetPositionInternal() => _positionWorker.GetPosition();

        private double MeasureInternal() => _gonioWorker.Measure();

        private void WorkingThreadImplementation()
        {
            var startDate = DateTime.Now;
            RuntimeContext.Results.Clear();

            var position = GetPositionInternal();
            for (var i = 0; i < _positionMatrix.Count; i++)
            {
                _ = _waitHandle.WaitOne();

                if (!position.CloseEnoughTo(_positionMatrix[i], _gonioConfiguration.Excel_Precision))
                {
                    SetPositionInternal(_positionMatrix[i]);
                    position = GetPositionInternal();
                }

                DoMeasurement();
            }

            if (RuntimeContext.UserConfig.ResetToZero)
                SetPositionInternal(PositionHelper.AbsoluteZeroPosition());

            if (RuntimeContext.UserConfig.ResetToVZero)
                SetPositionInternal(PositionHelper.VirtualZeroPosition());

            State = MeasurementStatus.FINISHED;

            if (RuntimeContext.UserConfig.SendNotificationOnComplete)
            {
                var template = _gonioConfiguration.Notification_Email_MeasurementFinishedHTMLTemplate;
                var text = string.Format(template, startDate.ToString(), DateTime.Now.ToString());

                NotifyHub.AddMessage(_gonioConfiguration.Notification_Email_MeasurementFinishedSubject, text);
                NotifyHub.SendMessages();
            }

            _thread.Abort();


            void DoMeasurement()
            {
                var results = new List<Tuple<double, double>>();
                var operatedResults = new List<Tuple<double, double>>();
                foreach (var _ in Enumerable.Range(0, RuntimeContext.UserConfig.MeasuresInSamePosition))
                {
                    CurrentStepNumber++;

                    Thread.Sleep(_config.HoldTime);

                    var measured = MeasureInternal();
                    var correction = RuntimeContext.UserConfig.UseCorrection
                        ? _measurementServiceHelper.GetCorrectionValue(measured)
                        : 1;

                    if (RuntimeContext.UserConfig.Amplification > 0)
                        measured *= RuntimeContext.UserConfig.Amplification;

                    measured += RuntimeContext.UserConfig.Offset;

                    results.Add(new Tuple<double, double>(measured, correction));
                }

                switch (RuntimeContext.UserConfig.MeasuresInSamePositionOperation)
                {
                    // Raw      0
                    // Average  1
                    // Sum      2
                    // Median   3
                    // Modus    4
                    case 0:
                        {
                            operatedResults = results;

                            break;
                        }
                    case 1:
                        {
                            var avgRes = results.Sum(m => m.Item1) / results.Count;
                            var avgCor = results.Sum(m => m.Item2) / results.Count;

                            operatedResults.Add(new Tuple<double, double>(avgRes, avgCor));

                            break;
                        }
                    case 2:
                        {
                            var sumRes = results.Sum(m => m.Item1);
                            var sumCor = results.Sum(m => m.Item2);

                            operatedResults.Add(new Tuple<double, double>(sumRes, sumCor));

                            break;
                        }
                    case 3:
                        {
                            var orderedResults = results.OrderBy(m => m.Item1).ToList();

                            if(orderedResults.Count % 2 == 0)
                            {
                                var index = orderedResults.Count / 2.0;
                                var lowerNeighbour = orderedResults[(int)Math.Floor(index)];
                                var biggerNeighbour = orderedResults[(int)Math.Ceiling(index)];

                                var medRes = (lowerNeighbour.Item1 + biggerNeighbour.Item1) / 2;
                                var medCor = (lowerNeighbour.Item2 + biggerNeighbour.Item2) / 2;

                                operatedResults.Add(new Tuple<double, double>(medRes, medCor));
                            }
                            else
                            {
                                var median = orderedResults[orderedResults.Count / 2];
                                operatedResults.Add(new Tuple<double, double>(median.Item1, median.Item2));
                            }

                            break;
                        }
                    case 4:
                        {
                            var modus = results
                                .GroupBy(m => m.Item1)
                                .OrderByDescending(m => m.Count())
                                .ThenBy(m => m.Key)
                                .First()
                                .First()
                            ;

                            operatedResults.Add(new Tuple<double, double>(modus.Item1, modus.Item2));

                            break;
                        }
                    default:
                        throw new Gonio_Exception("Measures in same position is invalid!");
                }


                for(var i = 0; i < operatedResults.Count; i++)
                {
                    RuntimeContext.Results
                        .Add(
                            new Complex_ResultItem(
                                position.X,
                                position.Y,
                                operatedResults[i].Item1,
                                operatedResults[i].Item2
                        )
                    );
                }
            }
        }
    }
}
