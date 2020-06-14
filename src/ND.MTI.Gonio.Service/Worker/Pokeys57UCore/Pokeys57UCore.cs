using System;
using PoKeysDevice_DLL;
using System.Collections.Generic;
using ND.MTI.Gonio.Common.Exceptions;
using ND.MTI.Gonio.Service.Worker.PokeysCore.Helper;
using ND.MTI.Gonio.ServiceInterface;

namespace ND.MTI.Gonio.Service.Worker.PokeysCore
{
    public abstract class Pokeys57UCore : IPokeys57UCore
    {
        private bool _connected { get; set; }

        private readonly PoKeysDevice _device;

        public Pokeys57UCore()
        {
            _device = new PoKeysDevice();
        }

        public virtual bool IsConnected => _connected;

        public virtual bool Connect()
        {
            if (_connected)
                return _connected;

            var deviceNumber = _device.EnumerateDevices();

            if (deviceNumber != 1)
                throw new Gonio_Exception("Device number");

            _connected = _device.ConnectToDevice(0);

            return _connected;
        }

        public virtual void Disconnect()
        {
            if(_connected)
            {
                _device.DisconnectDevice();
                _connected = false;
            }
        }

        private protected string ReadBytes(Pokeys57U_Pin[] pins)
        {
            var data = string.Empty;
            var block = new bool[55];

            _ = _device.BlockGetInputAll55(ref block);

            for(var i = 0; i < pins.Length; i++)
                data += block[(int)pins[i]] ? "1" : "0";

            return data;
        }

        private protected bool GetPinData(Pokeys57U_Pin pin, Pokeys57U_PinFunction function)
        {
            var func = (byte)function;
            var state = _device.GetPinData((byte)pin, ref func);

            return state;
        }

        private protected bool WriteBytes(IList<Tuple<Pokeys57U_Pin, bool>> dataList)
        {
            for(var index = 0; index < dataList.Count; index++)
                WritePin(
                    (byte)dataList[index].Item1,
                    dataList[index].Item2
                );

            return true;

            void WritePin(byte pinNumber, bool data)
            {
                if (!_connected) return;

                _ = _device.SetOutput(pinNumber, data);
            }
        }
        
        private protected bool InitDigitalInputPins(Pokeys57U_Pin[] inputPins)
        {
            foreach (var pin in inputPins)
                InitPin((byte)pin, (byte)Pokeys57U_PinFunction.DIGITAL_INPUT);

            return true;
        }

        private protected bool InitDigitalOutputPins(Pokeys57U_Pin[] outputPins)
        {
            foreach (var pin in outputPins)
                InitPin((byte)pin, (byte)Pokeys57U_PinFunction.DIGITAL_OUTPUT);

            return true;
        }

        private void InitPin(byte pinNumber, byte pinFunction)
        {
            if (!_connected) return;

            var success = _device.SetPinData(pinNumber, pinFunction);

            if (!success)
                InitPin(pinNumber, pinFunction);
        }
    }
}
