#if DEBUG
// TODO !Debug
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Model;
using ND.MTI.Service.Worker.Pokeys;

namespace ND.MTI.Service.Worker
{
    public class PositionWorker : Pokeys57UWorker, IPositionWorker
    {
        private static IPositionWorker _instance { get; set; }

        private PositionWorker() => Init();

        public static IPositionWorker GetInstance()
        {
            if (_instance is null)
                _instance = new PositionWorker();

            return _instance;
        }

        public Primitive_Position GetPosition() => GetPositionInternal();

        public void SetPosition(Primitive_Position position)
        {
            var currentPosition = GetPositionInternal();

            #region [ SET X ]

            if (currentPosition.X > position.X)
            {
                while (GetPositionInternal().X > position.X)
                    DecrementXInternal();

                StopX();
            }
            else if (currentPosition.X < position.X)
            {
                while (GetPositionInternal().X < position.X)
                    IncrementXInternal();

                StopX();
            }

            #endregion [ SET X ]

            #region [ SET Y ]

            if (currentPosition.Y > position.Y)
            {
                while (GetPositionInternal().Y > position.Y)
                    DecrementXInternal();

                StopX();
            }
            else if (currentPosition.Y < position.Y)
            {
                while (GetPositionInternal().Y < position.Y)
                    IncrementXInternal();

                StopY();
            }

            #endregion [ SET Y ]
        }

        private Primitive_Position GetPositionInternal()
        {
            var xResp = LastXResponse;
            var yResp = LastYResponse;

            var rotX = GrayUtils.GrayToInteger(xResp);
            var rotY = GrayUtils.GrayToInteger(yResp);

            var coordX = NormalizeInternal(
                rotX,
                _configuration.EncoderXMin,
                _configuration.EncoderXMax,
                _configuration.EncoderXFullSpectrum
            );

            var coordY = NormalizeInternal(
                rotY,
                _configuration.EncoderYMin,
                _configuration.EncoderYMax,
                _configuration.EncoderYFullSpectrum
            );

            return new Primitive_Position(coordX, coordY);
        }

        public void DecrementY() => DecrementYInternal();

        public void DecrementX() => DecrementXInternal();

        public void IncrementY() => IncrementYInternal();

        public void IncrementX() => IncrementXInternal();

        public void StopX() => StopXInternal();

        public void StopY() => StopYInternal();
        
        private void IncrementXInternal() => WriteDataX(Pokeys57U_Commands.DIR1_ENA1_RES0);

        private void IncrementYInternal() => WriteDataY(Pokeys57U_Commands.DIR1_ENA1_RES0);

        private void DecrementXInternal() => WriteDataX(Pokeys57U_Commands.DIR0_ENA1_RES0);

        private void DecrementYInternal() => WriteDataY(Pokeys57U_Commands.DIR0_ENA1_RES0);

        private void StopXInternal() => WriteDataX(Pokeys57U_Commands.DIR0_ENA0_RES0);

        private void StopYInternal() => WriteDataY(Pokeys57U_Commands.DIR0_ENA0_RES0);

        private double NormalizeInternal(
            int encoderPos,
            int min,
            int max,
            int fullSpectrum)
        {
            var numberOfOptogates = max - min;
            var rate = encoderPos / numberOfOptogates;

            return rate * fullSpectrum;
        }
    }
}
#endif
