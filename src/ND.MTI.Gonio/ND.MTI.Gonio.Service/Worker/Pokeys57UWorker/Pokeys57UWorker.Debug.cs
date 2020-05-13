#if DEBUG

using ND.MTI.Gonio.Service.Worker.PokeysCore;

namespace ND.MTI.Gonio.Service.Worker.Pokeys
{
    public sealed class Pokeys57UWorker : IExternalDevice, IPokeys57UCore, IPokeys57UWorker
    {
        public Pokeys57UWorker(int readInterval)
        {
        }

        public bool IsConnected => true;

        public bool Connect() => true;

        public void Disconnect() { }

        public bool WriteDataX(string message)
        {
            if (message[0] == '1' &&
                message[1] == '1' &&
                message[2] == '0' &&
                message[3] == '0')
                WorkerHelper.IncrementX_Slow();

            if (message[0] == '1' &&
                message[1] == '1' &&
                message[2] == '1' &&
                message[3] == '0')
                WorkerHelper.DecrementX_Slow();

            if (message[0] == '1' &&
                message[1] == '1' &&
                message[2] == '0' &&
                message[3] == '1')
                WorkerHelper.IncrementX_Fast();

            if (message[0] == '1' &&
                message[1] == '1' &&
                message[2] == '1' &&
                message[3] == '1')
                WorkerHelper.DecrementX_Fast();

            if (message[0] == '0' &&
                message[1] == '0')
                WorkerHelper.StopX();

            return true;
        }

        public bool WriteDataY(string message)
        {
            if (message[0] == '1' &&
                message[1] == '1' &&
                message[2] == '0' &&
                message[3] == '0')
                WorkerHelper.IncrementY_Slow();

            if (message[0] == '1' &&
                message[1] == '1' &&
                message[2] == '1' &&
                message[3] == '0')
                WorkerHelper.DecrementY_Slow();

            if (message[0] == '1' &&
                message[1] == '1' &&
                message[2] == '0' &&
                message[3] == '1')
                WorkerHelper.IncrementY_Fast();

            if (message[0] == '1' &&
                message[1] == '1' &&
                message[2] == '1' &&
                message[3] == '1')
                WorkerHelper.DecrementY_Fast();

            if (message[0] == '0' &&
                message[1] == '0')
                WorkerHelper.StopY();

            return true;
        }
    }
}

#endif
