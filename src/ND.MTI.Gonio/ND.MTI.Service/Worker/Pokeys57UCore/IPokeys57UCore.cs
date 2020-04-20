namespace ND.MTI.Service.Worker.PokeysCore
{
    internal interface IPokeys57UCore
    {
        bool Connect();
        void Disconnect();

        bool IsConnected { get; }
    }
}
