using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Service.Worker.Pokeys;
using ND.MTI.Service.Worker.Pokeys.Helper;

namespace ND.MTI.Service.Worker
{
    public class PositionWorker : Pokeys57UWorker, IPositionWorker
    {
        private static IPositionWorker _instance { get; set; }

        private PositionWorker()
        {
        }

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
                DecrementXInternal();

                while (GetPositionInternal().X > position.X) ;


                StopX();
            }
            else if (currentPosition.X < position.X)
            {
                IncrementYInternal();

                while (GetPositionInternal().X < position.X) ;

                StopX();
            }

            #endregion [ SET X ]

            #region [ SET Y ]

            if (currentPosition.Y > position.Y)
            {
                DecrementYInternal();

                while (GetPositionInternal().Y > position.Y) ;

                StopY();
            }
            else if (currentPosition.Y < position.Y)
            {
                IncrementXInternal();

                while (GetPositionInternal().Y < position.Y) ;

                StopY();
            }

            #endregion [ SET Y ]
        }

        private Primitive_Position GetPositionInternal()
        {
            var xResp = LastXResponse;
            var yResp = LastYResponse;

            var rotX = GrayUtils.GrayToInteger(xResp.Item1);
            var rotY = GrayUtils.GrayToInteger(yResp.Item1);

            var coordX = NormalizeInternal(
                rotX,
                _configuration.Encoder_XMin,
                _configuration.Encoder_XMax,
                _configuration.Encoder_XFullSpectrum
            );

            var coordY = NormalizeInternal(
                rotY,
                _configuration.Encoder_YMin,
                _configuration.Encoder_YMax,
                _configuration.Encoder_YFullSpectrum
            );

            return new Primitive_Position(coordX, coordY);
        }

        public void DecrementY() => DecrementYInternal();

        public void DecrementX() => DecrementXInternal();

        public void IncrementY() => IncrementYInternal();

        public void IncrementX() => IncrementXInternal();

        public void StopX() => StopXInternal();

        public void StopY() => StopYInternal();

        public void ReverseX() => ReverseXInteral(GetInvertedDirection(LastXDirection));

        public void ReverseY() => ReverseYInteral(GetInvertedDirection(LastYDirection));

        private void ReverseXInteral(string command) => WriteDataX(command);
        private void ReverseYInteral(string command) => WriteDataY(command);

        private string GetInvertedDirection(string lastDirection) =>
            string.Equals(lastDirection, "1")
            ? GonioPokeys_Commands.ENA1_SR1_DIR0_RES0
            : GonioPokeys_Commands.ENA1_SR1_DIR1_RES0;

        private void IncrementXInternal() => WriteDataX(GonioPokeys_Commands.ENA1_SR1_DIR0_RES0);

        private void IncrementYInternal() => WriteDataY(GonioPokeys_Commands.ENA1_SR1_DIR0_RES0);

        private void DecrementXInternal() => WriteDataX(GonioPokeys_Commands.ENA1_SR1_DIR1_RES0);

        private void DecrementYInternal() => WriteDataY(GonioPokeys_Commands.ENA1_SR1_DIR1_RES0);

        private void StopXInternal() => WriteDataX(GonioPokeys_Commands.ENA0_SR0_DIR0_RES0);

        private void StopYInternal() => WriteDataY(GonioPokeys_Commands.ENA0_SR0_DIR0_RES0);

        private double NormalizeInternal(
            int encoderPos,
            int min,
            int max,
            int fullSpectrum)
        {
            var fullScale = max - min;
            var currentScale = max - encoderPos;


            var rate = encoderPos * (currentScale / fullScale);

            return rate;
        }
    }
}
