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

        void DecrementYFast();
        void DecrementYSlow();

        void DecrementXFast();
        void DecrementXSlow();

        void StopX();
        void StopY();

        void IncrementYFast();
        void IncrementYSlow();

        void IncrementXFast();
        void IncrementXSlow();

        void EncoderZero();
    }
}
