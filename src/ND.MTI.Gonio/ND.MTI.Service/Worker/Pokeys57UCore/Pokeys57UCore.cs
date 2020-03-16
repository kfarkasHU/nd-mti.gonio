using System;
using PoKeysDevice_DLL;
using System.Collections.Generic;
using ND.MTI.Gonio.Common.Exceptions;
using ND.MTI.Service.Worker.PokeysCore.Helper;

namespace ND.MTI.Service.Worker.PokeysCore
{
    public abstract class Pokeys57UCore : IPokeys57UCore
    {
        private bool _connected { get; set; }
        private int _deviceNumber { get; set; }

        private readonly PoKeysDevice _device;

        public Pokeys57UCore()
        {
            _device = new PoKeysDevice();
        }

        public bool IsConnected => _connected;

        public int NumberOfDevices => _deviceNumber;

        public bool Connect()
        {
            _deviceNumber = _device.EnumerateDevices();

            if (_deviceNumber == 0)
                throw new Gonio_Exception("Device number");

            _connected = _device.ConnectToDevice(0);

            return _connected;
        }

        public void Disconnect()
        {
            if(_connected)
            {
                _device.DisconnectDevice();
                _connected = false;
            }
        }

        protected string ReadBytes(Pokeys57U_Pin[] pins)
        {
            var data = string.Empty;
            for (var index = 0; index < pins.Length; index++)
            {
                var pinNum = (byte)pins[index];

                data += ReadPin(pinNum) ? "1" : "0";
            }

            return data;

            bool ReadPin(byte pinNumber)
            {
                var state = false;

                var success = _device.GetInput(pinNumber, ref state);

                if (!success)
                    throw new Gonio_PinReadException(pinNumber);

                return state;
            }
        }

        protected bool WriteBytes(IList<Tuple<Pokeys57U_Pin, bool>> dataList)
        {
            for(var index = 0; index < dataList.Count; index++)
            {
                var data = dataList[index];

                WritePin((byte)data.Item1, data.Item2);
            }

            return true;

            void WritePin(byte pinNumber, bool data)
            {
                var success = _device.SetOutput(pinNumber, data);

                if (!success)
                    throw new Gonio_PinWriteException(pinNumber);
            }
        }

        protected bool InitDigitalInputPins(Pokeys57U_Pin[] inputPins)
        {
            foreach (var pin in inputPins)
                InitPin((byte)pin, (byte)Pokeys57U_PinFunction.DIGITAL_INPUT);

            return true;
        }

        protected bool InitDigitalOutputPins(Pokeys57U_Pin[] outputPins)
        {
            foreach (var pin in outputPins)
                InitPin((byte)pin, (byte)Pokeys57U_PinFunction.DIGITAL_OUTPUT);

            return true;
        }

        private void InitPin(byte pinNumber, byte pinFunction)
        {
            var success = _device.SetPinData(pinNumber, pinFunction);

            if (!success)
                throw new Gonio_PinInitException(pinNumber, pinFunction);
        }
    }
}
