using ND.MTI.Service.Worker.PokeysCore;

namespace ND.MTI.Service.Worker
{
    internal interface IPokeys57UWorker : IPokeys57UCore
    {
        bool WriteDataX(string message);
        bool WriteDataY(string message);
    }
}
