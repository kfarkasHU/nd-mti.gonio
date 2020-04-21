using ND.MTI.Gonio.Service.Worker.PokeysCore;

namespace ND.MTI.Gonio.Service.Worker
{
    internal interface IPokeys57UWorker : IPokeys57UCore
    {
        bool WriteDataX(string message);
        bool WriteDataY(string message);
    }
}
