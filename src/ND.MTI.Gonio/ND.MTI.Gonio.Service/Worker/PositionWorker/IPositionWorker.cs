using System;
using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.Service.Worker
{
    public interface IPositionWorker
    {

        void SetPosition(Primitive_Position position);
        Tuple<int, int> GetIncomeData();
        Primitive_Position GetPosition();
        Primitive_Position GetRawPosition();

        void DecrementY();
        void DecrementX();

        void StopX();
        void StopY();

        void IncrementY();
        void IncrementX();

        void EncoderZero();
    }
}
