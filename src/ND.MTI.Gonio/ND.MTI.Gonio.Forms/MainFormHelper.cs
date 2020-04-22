using System.Threading;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Service.Worker;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.Forms
{
    internal class MainFormHelper
    {
        private Thread _thread;
        private Primitive_Position _primitivePosition;
        private readonly IPositionWorker _positionWorker;

        public MainFormHelper()
        {
            _positionWorker = PositionWorker.GetInstance();
        }


        internal void SetPositionVirtualZero() => SetPositionInternal(GetPositionInternal() - RuntimeContext.VirtualZeroPosition);

        internal void SetPositionToZero() => SetPositionInternal(new Primitive_Position(0, 0) - RuntimeContext.VirtualZeroPosition);
        
        private Primitive_Position GetPositionInternal() => _positionWorker.GetPosition();

        private void SetPositionInternal(Primitive_Position position)
        {
            _thread = new Thread(OnThreadWorking);
            _thread.IsBackground = true;
            _primitivePosition = position;

            _thread.Start();
        }

        private void OnThreadWorking()
        {
            _positionWorker.SetPosition(_primitivePosition);
            _thread.Abort();
        }
    }
}
