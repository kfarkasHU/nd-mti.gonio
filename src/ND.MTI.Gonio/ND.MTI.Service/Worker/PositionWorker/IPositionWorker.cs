using ND.MTI.Gonio.Model;

namespace ND.MTI.Service.Worker
{
    public interface IPositionWorker : IPokeys57UWorker
    {
        void SetPosition(Primitive_Position position);
        Primitive_Position GetPosition();

        void DecrementY();
        void DecrementX();

        void StopX();
        void StopY();

        void IncrementY();
        void IncrementX();
    }
}
