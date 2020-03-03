namespace ND.MTI.Service.Worker
{
    public interface IPokeys57UWorker
    {
        bool Connect();
        void Disconnect();
        void WriteDataX(string message);
        void WriteDataY(string message);
        string LastXResponse { get; }
        string LastYResponse { get; }
}
}
