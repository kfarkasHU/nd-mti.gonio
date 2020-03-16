using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Service.Worker.Pokeys;
using ND.MTI.Service.Worker.Pokeys.Helper;
using ND.MTI.Gonio.Common.Exceptions;

namespace ND.MTI.Service.Worker
{
    public sealed class PositionWorker : Pokeys57UWorker, IPositionWorker
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

        private Primitive_Position GetPositionInternal()
        {
            var xResp = LastXResponse;
            var yResp = LastYResponse;

            var rotX = GrayUtils.GrayToInteger(xResp.Item1);
            var rotY = GrayUtils.GrayToInteger(yResp.Item1);

            var coordX = NormalizeInternal(
                rotX,
                _configuration.Encoder_DecXEnd,
                _configuration.Encoder_IncXEnd,
                _configuration.Encoder_MaxXEnc,
                xResp.Item2
            );

            var coordY = NormalizeInternal(
                rotY,
                _configuration.Encoder_DecYEnd,
                _configuration.Encoder_IncYEnd,
                _configuration.Encoder_MaxYEnc,
                yResp.Item2
            );

            return new Primitive_Position(coordX, coordY);
        }

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
                IncrementXInternal();

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
                IncrementYInternal();

                while (GetPositionInternal().Y < position.Y) ;

                StopY();
            }

            #endregion [ SET Y ]
        }

        public void DecrementY() => DecrementYInternal();

        public void DecrementX() => DecrementXInternal();

        public void IncrementY() => IncrementYInternal();

        public void IncrementX() => IncrementXInternal();

        public void StopX() => StopXInternal();

        public void StopY() => StopYInternal();

        private void IncrementXInternal() => WriteDataX(GonioPokeys_Commands.ENA1_SR1_DIR0_RES0);

        private void IncrementYInternal() => WriteDataY(GonioPokeys_Commands.ENA1_SR1_DIR0_RES0);

        private void DecrementXInternal() => WriteDataX(GonioPokeys_Commands.ENA1_SR1_DIR1_RES0);

        private void DecrementYInternal() => WriteDataY(GonioPokeys_Commands.ENA1_SR1_DIR1_RES0);

        private void StopXInternal() => WriteDataX(GonioPokeys_Commands.ENA0_SR0_DIR0_RES0);

        private void StopYInternal() => WriteDataY(GonioPokeys_Commands.ENA0_SR0_DIR0_RES0);

        private double NormalizeInternal(
            int currentPosition,
            int decEndpointPosition,
            int incEndpointPostion,
            int maxEncPosition,
            int axisOperator
        )
        {
            // [] ------------------- || ------------------- []
            switch (axisOperator)
            {
                case 0: return 0;
                case -1: return axisOperator * NormalizeCore(decEndpointPosition);
                case +1: return axisOperator * NormalizeCore(incEndpointPostion);
            }

            throw new Gonio_Exception($"Unable to normalize with this operator: {axisOperator}");

            double NormalizeCore(int localEndposition)
            {
                var localScale = maxEncPosition - localEndposition;
                var localSpectrum = 360 / 2;
                var normalizedEncPosition = currentPosition - localEndposition;

                var rate = ((double)normalizedEncPosition / localScale);
                var standardScale = localSpectrum * rate;

                return localSpectrum - standardScale;
            }
        }
    }
}
