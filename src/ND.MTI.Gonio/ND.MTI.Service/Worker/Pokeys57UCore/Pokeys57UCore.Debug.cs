#if DEBUG

using System;
using System.Collections.Generic;
using ND.MTI.Service.Worker.PokeysCore.Debug_Helper;
using ND.MTI.Service.Worker.PokeysCore.Helper;

namespace ND.MTI.Service.Worker.PokeysCore
{
    public abstract class Pokeys57UCore : IPokeys57UCore
    {
        public Pokeys57UCore() => DebugHelper.InitDebugContext();

        public virtual bool IsConnected => true;

        public virtual bool Connect() => true;

        public virtual void Disconnect() { }

        private protected string ReadBytes(Pokeys57U_Pin[] pins) => DebugHelper.EvalCommand(pins);

        private protected bool GetPinData(Pokeys57U_Pin pin, Pokeys57U_PinFunction function) => DebugHelper.GetPinState(pin);

        private protected bool WriteBytes(IList<Tuple<Pokeys57U_Pin, bool>> dataList) => DebugHelper.SetCommand(dataList);

        private protected bool InitDigitalInputPins(Pokeys57U_Pin[] inputPins) => true;

        private protected bool InitDigitalOutputPins(Pokeys57U_Pin[] outputPins) => true;

        private void InitPin(byte pinNumber, byte pinFunction) { }
    }
}

#endif
