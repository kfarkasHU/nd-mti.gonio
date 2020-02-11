using System;

namespace ND.MTI.Service.Worker.LPT
{
    public abstract class LPTCore : ILPTCore
    {
        protected virtual bool Connect()
        {
            throw new NotImplementedException();
        }

        protected virtual void Disconnect()
        {
            throw new NotImplementedException();
        }

        protected string SendCommand(string command)
        {
            throw new NotImplementedException();
        }
    }
}
