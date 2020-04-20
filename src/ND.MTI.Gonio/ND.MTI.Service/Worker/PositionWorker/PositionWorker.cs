using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Service.Worker.Pokeys;
using ND.MTI.Service.Worker.SSIWorker;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.RuntimeContext;
using ND.MTI.Service.Worker.Pokeys.Helper;

namespace ND.MTI.Service.Worker
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

            _ssiWorker = new SSIWorker.SSIWorker();
            _ssiWorker.Connect(_gonioConfiguration.SSI_Config);

            _pokeysWorker = new Pokeys57UWorker(_gonioConfiguration.Pokeys_ReadInterval);
            _pokeysWorker.Connect();
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
            var strX = _ssiWorker.ResponseX;
            var strY = _ssiWorker.ResponseY;

            var pos = new Primitive_Position(
                NormalizeInternal(Parser.StringToInteger(strX)),
                NormalizeInternal(Parser.StringToInteger(strY))
            );

            pos += RuntimeContext.VirtualZeroPosition;
            pos += RuntimeContext.ZeroPosition;

            return pos;
        }

        public void SetPosition(Primitive_Position position)
        {
            position += RuntimeContext.VirtualZeroPosition;
            position += RuntimeContext.ZeroPosition;

            SetPositionXInternal(position.X);
            SetPositionYInternal(position.Y);
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

        private bool CloseEnough(double current, double target) => current - 0.1 < target && current + 0.1 > target;

        private void IncrementXInternal() => _ = _pokeysWorker.WriteDataX(GonioPokeys_Commands.ENA1_SR1_DIR0_RES0);

        private void IncrementYInternal() => _ = _pokeysWorker.WriteDataY(GonioPokeys_Commands.ENA1_SR1_DIR1_RES0);

        private void DecrementXInternal() => _ = _pokeysWorker.WriteDataX(GonioPokeys_Commands.ENA1_SR1_DIR1_RES0);

        private void DecrementYInternal() => _ = _pokeysWorker.WriteDataY(GonioPokeys_Commands.ENA1_SR1_DIR0_RES0);

        private void StopXInternal() => _pokeysWorker.WriteDataX(GonioPokeys_Commands.ENA0_SR0_DIR0_RES0);

        private void StopYInternal() => _pokeysWorker.WriteDataY(GonioPokeys_Commands.ENA0_SR0_DIR0_RES0);

        private double NormalizeInternal(float current) {
            var c = 360f / 8192f;
            var fullAngle = current * c;

           return 180 - fullAngle;
        }
    }
}
