using System;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Service.Helper;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.RuntimeContext;
using ND.MTI.Gonio.Service.Worker.Pokeys;
using ND.MTI.Gonio.Service.Worker.SSIWorker;
using ND.MTI.Gonio.Service.Worker.Pokeys.Helper;

namespace ND.MTI.Gonio.Service.Worker
{
    public sealed class PositionWorker : IPositionWorker
    {
        private static IPositionWorker _instance { get; set; }

        private readonly ISSIWorker _ssiWorker;
        private readonly IPokeys57UWorker _pokeysWorker;
        private readonly IGonioConfiguration _gonioConfiguration;

        private PositionWorker()
        {
            _gonioConfiguration = GonioConfiguration.GetInstance();

#if DEBUG
            WorkerHelper.Init();
#endif

            _ssiWorker = new SSIWorker.SSIWorker();
            RuntimeContext.IsSSIPanelConnected = _ssiWorker.Connect(_gonioConfiguration.SSI_Config);

            _pokeysWorker = new Pokeys57UWorker(_gonioConfiguration.Pokeys_ReadInterval);
            RuntimeContext.IsPokeys57Connected = _pokeysWorker.Connect();
        }

        public static IPositionWorker GetInstance()
        {
            if (_instance is null)
                _instance = new PositionWorker();

            return _instance;
        }

        public Tuple<int, int> GetIncomeData() =>
            new Tuple<int, int>(
                Parser.StringToInteger(_ssiWorker.ResponseX),
                Parser.StringToInteger(_ssiWorker.ResponseY)
            );

        public Primitive_Position GetPosition() => GetPositionInternal();

        public Primitive_Position GetRawPosition() => GetRawPositionInternal();

        private Primitive_Position GetPositionInternal()
        {
            var pos = GetRawPositionInternal();

            return PositionHelper
                .Normalise(pos)
                .RoundTo3();
        }

        private Primitive_Position GetRawPositionInternal()
        {
            var strX = _ssiWorker.ResponseX;
            var strY = _ssiWorker.ResponseY;

            var pos = new Primitive_Position(
                NormalizeInternal(Parser.StringToInteger(strX)),
                NormalizeInternal(Parser.StringToInteger(strY)) * -1 // mert az Y enkóder ellentétes irányú!
            );

            return pos.RoundTo3();
        }

        public void SetPosition(Primitive_Position position)
        {
            var diffFromAbsZero = PositionHelper.CurrentPositionToAbsoluteZero(position);

            if (IsOutOfRange(diffFromAbsZero.X, _gonioConfiguration.Endpoint_XMin, _gonioConfiguration.Endpoint_XMax))
                throw new Exception($"The target position is out of range in X axis.\nValue: {position.X}\nNormalised value: {diffFromAbsZero.X}");

            if (IsOutOfRange(diffFromAbsZero.Y, _gonioConfiguration.Endpoint_YMin, _gonioConfiguration.Endpoint_YMax))
                throw new Exception($"The target position is out of range in Y axis.\nValue: {position.Y}\nNormalised value: {diffFromAbsZero.Y}");

            SetPositionXInternal(position.X);
            SetPositionYInternal(position.Y);

            bool IsOutOfRange(double current, double min, double max)
            {
                return
                    current < min ||
                    current > max;
            }
        }

        public void DecrementYFast() => DecrementYInternalFast();
        public void DecrementYSlow() => DecrementYInternalSlow();

        public void DecrementXFast() => DecrementXInternalFast();
        public void DecrementXSlow() => DecrementXInternalSlow();

        public void IncrementYFast() => IncrementYInternalFast();
        public void IncrementYSlow() => IncrementYInternalSlow();

        public void IncrementXFast() => IncrementXInternalFast();
        public void IncrementXSlow() => IncrementXInternalSlow();

        public void StopX() => StopXInternal();

        public void StopY() => StopYInternal();

        public void EncoderZero()
        {
            _ssiWorker.ZeroX();
            _ssiWorker.ZeroY();
        }

        private void SetPositionXInternal(double pos)
        {
            var currentX = GetPositionInternal().X;

            if (CloseEnough(currentX, pos))
                return;

            if (currentX < pos)
            {
                if (Math.Abs(currentX - pos) > _gonioConfiguration.Position_SpeedThreshold)
                {
                    IncrementXFast();

                    while (!CloseEnough(GetPositionInternal().X, pos - _gonioConfiguration.Position_SpeedThreshold)) { };
                }

                IncrementXInternalSlow();

                while (!CloseEnough(GetPositionInternal().X, pos)) { };

                StopXInternal();
            }
            else if (currentX > pos)
            {
                if (Math.Abs(currentX - pos) > _gonioConfiguration.Position_SpeedThreshold)
                {
                    DecrementXInternalFast();

                    while (!CloseEnough(GetPositionInternal().X, pos + _gonioConfiguration.Position_SpeedThreshold)) { };
                }

                DecrementXInternalSlow();

                while (!CloseEnough(GetPositionInternal().X, pos)) { };

                StopXInternal();
            }

            SetPositionXInternal(pos);
        }

        private void SetPositionYInternal(double pos)
        {
            var currentY = GetPositionInternal().Y;

            if (CloseEnough(currentY, pos))
                return;

            if (currentY < pos)
            {
                if (Math.Abs(currentY - pos) > _gonioConfiguration.Position_SpeedThreshold)
                {
                    IncrementYFast();

                    while (!CloseEnough(GetPositionInternal().Y, pos + _gonioConfiguration.Position_SpeedThreshold)) { };
                }

                IncrementYInternalSlow();

                while (!CloseEnough(GetPositionInternal().Y, pos)) { };

                StopYInternal();
            }
            else if (currentY > pos)
            {
                if (Math.Abs(currentY - pos) > _gonioConfiguration.Position_SpeedThreshold)
                {
                    DecrementYInternalFast();

                    while (!CloseEnough(GetPositionInternal().Y, pos - _gonioConfiguration.Position_SpeedThreshold)) { };
                }

                DecrementYInternalSlow();

                while (!CloseEnough(GetPositionInternal().Y, pos)) { };

                StopYInternal();
            }

            SetPositionYInternal(pos);
        }

        private bool CloseEnough(double current, double target)
        {
            var precision = _gonioConfiguration.Encoder_Precision;
            
            return current - precision < target && current + precision > target;
        }

        private void IncrementXInternalFast() => _ = _pokeysWorker.WriteDataX(GonioPokeys_Commands.ENA1_SR1_DIR0_SPEED1);
        private void IncrementXInternalSlow() => _ = _pokeysWorker.WriteDataX(GonioPokeys_Commands.ENA1_SR1_DIR0_SPEED0);

        private void IncrementYInternalFast() => _ = _pokeysWorker.WriteDataY(GonioPokeys_Commands.ENA1_SR1_DIR0_SPEED1);
        private void IncrementYInternalSlow() => _ = _pokeysWorker.WriteDataY(GonioPokeys_Commands.ENA1_SR1_DIR0_SPEED0);

        private void DecrementXInternalFast() => _ = _pokeysWorker.WriteDataX(GonioPokeys_Commands.ENA1_SR1_DIR1_SPEED1);
        private void DecrementXInternalSlow() => _ = _pokeysWorker.WriteDataX(GonioPokeys_Commands.ENA1_SR1_DIR1_SPEED0);

        private void DecrementYInternalFast() => _ = _pokeysWorker.WriteDataY(GonioPokeys_Commands.ENA1_SR1_DIR1_SPEED1);
        private void DecrementYInternalSlow() => _ = _pokeysWorker.WriteDataY(GonioPokeys_Commands.ENA1_SR1_DIR1_SPEED0);

        private void StopXInternal() => _pokeysWorker.WriteDataX(GonioPokeys_Commands.ENA0_SR0_DIR0_SPEED0);

        private void StopYInternal() => _pokeysWorker.WriteDataY(GonioPokeys_Commands.ENA0_SR0_DIR0_SPEED0);

        private double NormalizeInternal(float current) {
            var c = 360f / 8192f;
            var fullAngle = current * c;

           return 180 - fullAngle;
        }
    }
}
