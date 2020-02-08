namespace ND.MTI.Service.Worker.Motor
{
    public interface IMotorWorker
    {
        void SetPosition(double coordinate);
        double GetPosition();
    }
}
