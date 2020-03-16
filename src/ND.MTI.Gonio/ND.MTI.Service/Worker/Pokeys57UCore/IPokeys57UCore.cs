namespace ND.MTI.Service.Worker.PokeysCore
{
    public interface IPokeys57UCore
    {
        bool Connect();
        void Disconnect();

        bool IsConnected { get; }
    }
}
