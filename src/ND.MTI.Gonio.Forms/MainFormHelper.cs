using System.Threading;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Service.Helper;
using ND.MTI.Gonio.ServiceInterface;

namespace ND.MTI.Gonio.Forms
{
    internal class MainFormHelper
    {
        private Thread _thread;
        private Primitive_Position _primitivePosition;
        private readonly IPositionWorker _positionWorker;

        public MainFormHelper(IPositionWorker positionWorker)
        {
            _positionWorker = positionWorker;
        }


        internal void SetPositionVirtualZero() => SetPositionInternal(PositionHelper.VirtualZeroPosition());

        internal void SetPositionToZero() => SetPositionInternal(PositionHelper.AbsoluteZeroPosition());
        
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
