using System;
using System.Timers;
using System.Collections.Generic;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Service.Worker.PokeysCore.Helper;
using ND.MTI.Gonio.Common.Utils;

namespace ND.MTI.Service.Worker.PokeysCore.Debug_Helper
{
    internal static class DebugHelper
    {
        private static IDictionary<Pokeys57U_Pin, bool> _pinStates;
        private static IGonioConfiguration _configuration;
        private static Timer _timer;

        private static int _xVal;
        private static int _yVal;

        private static bool _xDec;
        private static bool _yDec;

        private const int STEP = 3;

        internal static void InitDebugContext()
        {
            _pinStates = new Dictionary<Pokeys57U_Pin, bool>();

            foreach (var pin in (Pokeys57U_Pin[])Enum.GetValues(typeof(Pokeys57U_Pin)))
                _pinStates.Add(pin, false);

            _configuration = GonioConfiguration.GetInstance();
            _xVal = _configuration.Encoder_DecXEnd;
            _yVal = _configuration.Encoder_IncYEnd;

            _xDec = true;
            _yDec = false;

            _timer = new Timer(5);
            _timer.Elapsed += RunCommand;
            _timer.Start();
        }

        private static void RunCommand(object sender, ElapsedEventArgs e)
        {
            SetEndpoint(false, Pokeys57U_Pin.PIN_2, Pokeys57U_Pin.PIN_3);
            SetEndpoint(false, Pokeys57U_Pin.PIN_20, Pokeys57U_Pin.PIN_21);

            if (_pinStates[Pokeys57U_Pin.PIN_17] && _pinStates[Pokeys57U_Pin.PIN_35])
            {
                if (_pinStates[Pokeys57U_Pin.PIN_36])
                    IncrementX();
                else
                    DecrementX();
            }

            if (_pinStates[Pokeys57U_Pin.PIN_18] && _pinStates[Pokeys57U_Pin.PIN_38])
            {
                if (_pinStates[Pokeys57U_Pin.PIN_39])
                    IncrementY();
                else
                    DecrementY();
            }

            var xGray = GrayUtils.IntgerToGray(_xVal);
            var yGray = GrayUtils.IntgerToGray(_yVal);

            _pinStates[Pokeys57U_Pin.PIN_4] = Value(xGray[0]);
            _pinStates[Pokeys57U_Pin.PIN_5] = Value(xGray[1]);
            _pinStates[Pokeys57U_Pin.PIN_6] = Value(xGray[2]);
            _pinStates[Pokeys57U_Pin.PIN_7] = Value(xGray[3]);
            _pinStates[Pokeys57U_Pin.PIN_8] = Value(xGray[4]);
            _pinStates[Pokeys57U_Pin.PIN_9] = Value(xGray[5]);
            _pinStates[Pokeys57U_Pin.PIN_10] = Value(xGray[6]);
            _pinStates[Pokeys57U_Pin.PIN_11] = Value(xGray[7]);
            _pinStates[Pokeys57U_Pin.PIN_12] = Value(xGray[8]);
            _pinStates[Pokeys57U_Pin.PIN_13] = Value(xGray[9]);
            _pinStates[Pokeys57U_Pin.PIN_14] = Value(xGray[10]);
            _pinStates[Pokeys57U_Pin.PIN_15] = Value(xGray[11]);
            _pinStates[Pokeys57U_Pin.PIN_16] = Value(xGray[12]);

            _pinStates[Pokeys57U_Pin.PIN_22] = Value(yGray[0]);
            _pinStates[Pokeys57U_Pin.PIN_23] = Value(yGray[1]);
            _pinStates[Pokeys57U_Pin.PIN_24] = Value(yGray[2]);
            _pinStates[Pokeys57U_Pin.PIN_25] = Value(yGray[3]);
            _pinStates[Pokeys57U_Pin.PIN_26] = Value(yGray[4]);
            _pinStates[Pokeys57U_Pin.PIN_27] = Value(yGray[5]);
            _pinStates[Pokeys57U_Pin.PIN_28] = Value(yGray[6]);
            _pinStates[Pokeys57U_Pin.PIN_29] = Value(yGray[7]);
            _pinStates[Pokeys57U_Pin.PIN_30] = Value(yGray[8]);
            _pinStates[Pokeys57U_Pin.PIN_31] = Value(yGray[9]);
            _pinStates[Pokeys57U_Pin.PIN_32] = Value(yGray[10]);
            _pinStates[Pokeys57U_Pin.PIN_33] = Value(yGray[11]);
            _pinStates[Pokeys57U_Pin.PIN_34] = Value(yGray[12]);

            bool Value(char c) => c == '1';

            #region [ locals ]

            void IncrementX()
            {
                if(_xDec)
                {
                    _xVal += STEP;

                    if (_xVal > _configuration.Encoder_MaxXEnc)
                        _xDec = false;
                }
                else
                {
                    if (_xVal > _configuration.Encoder_IncXEnd)
                        _xVal -= STEP;
                    else
                        SetXEndpoint(true);
                }
            }

            void DecrementX()
            {
                if (_xDec)
                {
                    if (_xVal > _configuration.Encoder_DecXEnd)
                        _xVal -= STEP;
                    else
                        SetXEndpoint(true);
                }
                else
                {
                    _xVal += STEP;

                    if (_xVal > _configuration.Encoder_MaxXEnc)
                        _xDec = true;
                }
            }

            void IncrementY()
            {
                if (_yDec)
                {
                    _yVal += STEP;

                    if (_yVal > _configuration.Encoder_MaxYEnc)
                        _yDec = false;
                }
                else
                {
                    if (_yVal > _configuration.Encoder_IncYEnd)
                        _yVal -= STEP;
                    else
                        SetYEndpoint(true);
                }
            }

            void DecrementY()
            {
                if (_yDec)
                {
                    if (_yVal > _configuration.Encoder_DecYEnd)
                        _yVal -= STEP;
                    else
                        SetYEndpoint(true);
                }
                else
                {
                    _yVal += STEP;

                    if (_yVal > _configuration.Encoder_MaxYEnc)
                        _yDec = true;
                }
            }

            void SetXEndpoint(bool state) => SetEndpoint(state, Pokeys57U_Pin.PIN_2, Pokeys57U_Pin.PIN_3);

            void SetYEndpoint(bool state) => SetEndpoint(state, Pokeys57U_Pin.PIN_20, Pokeys57U_Pin.PIN_21);

            void SetEndpoint(bool state, params Pokeys57U_Pin[] pins)
            {
                foreach (var pin in pins)
                    _pinStates[pin] = state;
            }

            #endregion
        }

        internal static string EvalCommand(Pokeys57U_Pin[] pins) => ReadPinStates(pins);

        internal static bool GetPinState(Pokeys57U_Pin pin) => _pinStates[pin];

        internal static bool SetCommand(IList<Tuple<Pokeys57U_Pin, bool>> dataList)
        {
            foreach (var data in dataList)
                _pinStates[data.Item1] = data.Item2;

            return true;
        }

        private static string ReadPinStates(Pokeys57U_Pin[] pins)
        {
            var response = string.Empty;

            for (var i = 0; i < pins.Length; i++)
                response += _pinStates[pins[i]] ? "1" : "0";

            return response;
        }
    }
}
