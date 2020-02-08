using ND.MTI.Gonio.Model;

namespace ND.MTI.Service.Worker
{
    public interface IPositionWorker
    {
        void SetPosition(Primitive_Position position);
        Primitive_Position GetPosition();
    }
}
