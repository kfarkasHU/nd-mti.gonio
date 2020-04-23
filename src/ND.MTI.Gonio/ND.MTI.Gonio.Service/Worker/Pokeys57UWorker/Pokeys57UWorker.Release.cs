#if !DEBUG

using System;
using System.Linq;
using ND.MTI.Gonio.Common.Utils;
using System.Collections.Generic;
using ND.MTI.Gonio.Common.Exceptions;
using ND.MTI.Gonio.Service.Worker.PokeysCore;
using ND.MTI.Gonio.Service.Worker.Pokeys.Helper;
using ND.MTI.Gonio.Service.Worker.PokeysCore.Helper;

namespace ND.MTI.Gonio.Service.Worker.Pokeys
{
    public sealed class Pokeys57UWorker : Pokeys57UCore, IPokeys57UWorker
    {
        private readonly GonioTimer _timer;

        private bool _endpoint_X;
        private bool _endpoint_Y;

        public Pokeys57UWorker(int readInterval)
        {
            _timer = new GonioTimer(OnTimerTick, readInterval);
        }

        public override bool Connect()
        {
            var res = base.Connect();

            if(res)
            {
                InitInternal();
                _timer.Start();
            }

            return res;
        }

        private void InitInternal()
        {
            InitDigitalInputPins(GonioPokeys_Pinout.X_Input);
            InitDigitalInputPins(GonioPokeys_Pinout.Y_Input);

            InitDigitalInputPins(GonioPokeys_Pinout.X_Endpoints);
            InitDigitalInputPins(GonioPokeys_Pinout.Y_Endpoints);

            InitDigitalOutputPins(GonioPokeys_Pinout.X_Output);
            InitDigitalOutputPins(GonioPokeys_Pinout.Y_Output);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            ReadEndpointX();
            ReadEndpointY();
        }

        public bool WriteDataX(string command) => WriteBytes(ParseCommandToAxis(GonioPokeys_Axis.X, command));

        public bool WriteDataY(string command) => WriteBytes(ParseCommandToAxis(GonioPokeys_Axis.Y, command));

        private void ReadEndpointX()
        {
            var data = ReadBytes(GonioPokeys_Pinout.X_Endpoints);

            if(string.Equals(data, "11") && _endpoint_X)
                _endpoint_X = false;

            if (string.Equals(data, "11") && !_endpoint_X)
                return;

            if (!string.Equals(data, "11") && _endpoint_X)
                return;

            if(!string.Equals(data, "11") && !_endpoint_X)
            {
                _endpoint_X = true;

                throw new Gonio_EndpointException(GonioPokeys_Axis.X.ToString());
            }
        }

        private void ReadEndpointY()
        {
            var data = ReadBytes(GonioPokeys_Pinout.Y_Endpoints);

            if (string.Equals(data, "11") && _endpoint_Y)
                _endpoint_Y = false;

            if (string.Equals(data, "11") && !_endpoint_Y)
                return;

            if (!string.Equals(data, "11") && _endpoint_Y)
                return;

            if (!string.Equals(data, "11") && !_endpoint_Y)
            {
                _endpoint_Y = true;

                throw new Gonio_EndpointException(GonioPokeys_Axis.Y.ToString());
            }
        }

        private IList<Tuple<Pokeys57U_Pin, bool>> ParseCommandToAxis(GonioPokeys_Axis axis, string command)
        {
            switch (axis)
            {
                case GonioPokeys_Axis.X: return ParseToAxis(GonioPokeys_Pinout.X_Output, ParseCommandCore());
                case GonioPokeys_Axis.Y: return ParseToAxis(GonioPokeys_Pinout.Y_Output, ParseCommandCore());
            }

            throw new Gonio_Exception("Cannot parse command to axis");

            IList<Tuple<Pokeys57U_Pin, bool>> ParseToAxis(Pokeys57U_Pin[] pins, bool[] stateArray)
            {
                var list = new List<Tuple<Pokeys57U_Pin, bool>>();

                try
                {
                    for (var i = 0; i < pins.Length; i++)
                        list.Add(new Tuple<Pokeys57U_Pin, bool>(pins[i], stateArray[i]));
                }
                catch (ArgumentOutOfRangeException e)
                {
                    throw new Gonio_Exception("Argument out of range", e);
                }

                return list;
            }

            bool[] ParseCommandCore() => command.Select(m => m.Equals('1')).ToArray();
        }
    }
}

#endif
