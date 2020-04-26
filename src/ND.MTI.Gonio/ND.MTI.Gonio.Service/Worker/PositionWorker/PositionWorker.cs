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

            return PositionHelper.Normalise(pos);
        }

        private Primitive_Position GetRawPositionInternal()
        {
            var strX = _ssiWorker.ResponseX;
            var strY = _ssiWorker.ResponseY;

            var pos = new Primitive_Position(
                NormalizeInternal(Parser.StringToInteger(strX)),
                NormalizeInternal(Parser.StringToInteger(strY)) * -1 // mert az Y enkóder ellentétes irányú!
            );

            return pos;
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

        public void DecrementY() => DecrementYInternal();

        public void DecrementX() => DecrementXInternal();

        public void IncrementY() => IncrementYInternal();

        public void IncrementX() => IncrementXInternal();

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

            if(currentX < pos)
            {
                IncrementXInternal();

                while (GetPositionInternal().X < pos) { };
                
                StopXInternal();
            }
            else if(currentX > pos)
            {
                DecrementXInternal();

                while (GetPositionInternal().X > pos) { };

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
                IncrementYInternal();

                while (GetPositionInternal().Y < pos) { };
                
                StopYInternal();
            }
            else if (currentY > pos)
            {
                DecrementYInternal();

                while (GetPositionInternal().Y > pos) { };
               
                StopYInternal();
            }

            SetPositionYInternal(pos);
        }

        private bool CloseEnough(double current, double target)
        {
            var precision = _gonioConfiguration.Encoder_Precision;
            
            return current - precision < target && current + precision > target;
        }

        private void IncrementXInternal() => _ = _pokeysWorker.WriteDataX(GonioPokeys_Commands.ENA1_SR1_DIR0_RES0);

        private void IncrementYInternal() => _ = _pokeysWorker.WriteDataY(GonioPokeys_Commands.ENA1_SR1_DIR0_RES0);

        private void DecrementXInternal() => _ = _pokeysWorker.WriteDataX(GonioPokeys_Commands.ENA1_SR1_DIR1_RES0);

        private void DecrementYInternal() => _ = _pokeysWorker.WriteDataY(GonioPokeys_Commands.ENA1_SR1_DIR1_RES0);

        private void StopXInternal() => _pokeysWorker.WriteDataX(GonioPokeys_Commands.ENA0_SR0_DIR0_RES0);

        private void StopYInternal() => _pokeysWorker.WriteDataY(GonioPokeys_Commands.ENA0_SR0_DIR0_RES0);

        private double NormalizeInternal(float current) {
            var c = 360f / 8192f;
            var fullAngle = current * c;

           return 180 - fullAngle;
        }
    }
}
