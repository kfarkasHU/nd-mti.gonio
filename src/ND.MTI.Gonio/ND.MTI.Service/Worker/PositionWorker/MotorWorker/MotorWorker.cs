using System;
using ND.MTI.Service.Worker.LPT;

namespace ND.MTI.Service.Worker.Motor
{
    public class MotorWorker : LPTCore, IMotorWorker
    {
        public double GetPosition()
        {
            throw new NotImplementedException();
        }

        public void SetPosition(double coordinate)
        {
            throw new NotImplementedException();
        }
    }
}
