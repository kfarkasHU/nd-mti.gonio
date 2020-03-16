using System;
using System.Timers;
using System.Collections.Generic;
using ND.MTI.Gonio.Common.Exceptions;
using ND.MTI.Service.Worker.PokeysCore;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Service.Worker.Pokeys.Helper;
using ND.MTI.Service.Worker.PokeysCore.Helper;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Common.Extensions;

namespace ND.MTI.Service.Worker.Pokeys
{
    public abstract class Pokeys57UWorker : Pokeys57UCore, IPokeys57UWorker
    {
        private readonly Timer _timer;

        private bool _endpoint_X;
        private bool _endpoint_Y;

        private int _xOperator = 1;
        private int _yOperator = 1;

        protected readonly IGonioConfiguration _configuration;

        protected string LastXDirection { get; private set; }
        protected string LastYDirection { get; private set; }

        public static Tuple<string, short> LastXResponse { get; private set; } = new Tuple<string, short>(string.Empty, 0);
        public static Tuple<string, short> LastYResponse { get; private set; } = new Tuple<string, short>(string.Empty, 0);

        private List<string> _xCache;
        private IList<string> _yCache;

        public Pokeys57UWorker()
        {
            _configuration = GonioConfiguration.GetInstance();

            _xCache = new List<string>();
            _yCache = new List<string>();

            _timer = new Timer(_configuration.Pokeys_ReadInterval);
            _timer.Elapsed += OnTimerTick;
        }

        public new bool Connect()
        {
            var res = base.Connect();

            InitInternal();
            _timer.Start();

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

        private void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            ReadDataX();
            ReadDataY();

            ReadEndpointX();
            ReadEndpointY();
        }

        protected void WriteDataX(string command) => WriteBytes(ParseCommandToAxis(GonioPokeys_Axis.X, command));

        protected void WriteDataY(string command) => WriteBytes(ParseCommandToAxis(GonioPokeys_Axis.Y, command));

        private void ReadEndpointX()
        {
            /*
            var data = ReadEndpoint(GonioPokeys_Axis.X);

            if (!string.Equals("11", data) && !_endpoint_X)
            {
                _endpoint_X = true;
                throw new Gonio_EndpointException(GonioPokeys_Axis.X.ToString());
            }
            else if(string.Equals("11", data) && _endpoint_X)
            {
                WriteDataX(GonioPokeys_Commands.ENA0_SR0_DIR0_RES0);
                _endpoint_X = false;
            }
            */
        }
        private void ReadEndpointY()
        {
            /*
            var data = ReadEndpoint(GonioPokeys_Axis.Y);

            if (!string.Equals("11", data) && !_endpoint_Y)
            {
                _endpoint_Y = true;
                throw new Gonio_EndpointException(GonioPokeys_Axis.Y.ToString());

                return;
            }
            else if (string.Equals("11", data) && _endpoint_Y)
            {
                WriteDataY(GonioPokeys_Commands.ENA0_SR0_DIR0_RES0);
                _endpoint_Y = false;

                return;
            }
            */
        }

        private string ReadEndpoint(GonioPokeys_Axis axis)
        {
            var result = "11";
            if (!IsConnected)
                return result;

            switch (axis)
            {
                case GonioPokeys_Axis.X:
                    {
                        result = ReadBytes(GonioPokeys_Pinout.X_Endpoints);

                        break;
                    }
                case GonioPokeys_Axis.Y:
                    {
                        result = ReadBytes(GonioPokeys_Pinout.Y_Endpoints);

                        break;
                    }
            }

            return result;
        }

        private void ReadDataX()
        {
            var data = ReadBytes(GonioPokeys_Pinout.X_Input);

            _xCache.Add(data);

            if(_xCache.Count == 3)
            {
                var xReadData = _xCache.GetModus();

                _xCache.Clear();

                var xMaxData = 4000;
                var xLastData = GrayUtils.GrayToInteger(LastXResponse.Item1);

                if (GrayUtils.GrayToInteger(xReadData) < xMaxData && xLastData > xMaxData)
                    _xOperator = _xOperator == 1 ? -1 : 1;

                LastXResponse = new Tuple<string, short>(xReadData, (short)_xOperator);
            }
        }

        private void ReadDataY()
        {
            var data = ReadBytes(GonioPokeys_Pinout.X_Input);

            _yCache.Add(data);

            if (_yCache.Count == 3)
            {
                var yReadData = _yCache.GetModus();

                _yCache.Clear();

                var yMaxData = 4000;
                var yLastData = GrayUtils.GrayToInteger(LastYResponse.Item1);

                if (GrayUtils.GrayToInteger(yReadData) < yMaxData && yLastData > yMaxData)
                    _yOperator = _yOperator == 1 ? -1 : 1;

                LastXResponse = new Tuple<string, short>(yReadData, (short)_yOperator);
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

            IList<Tuple<Pokeys57U_Pin, bool>> ParseToAxis(Pokeys57U_Pin[] pins, IList<bool> stateArray)
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

            IList<bool> ParseCommandCore()
            {
                var list = new List<bool>();

                for (var i = 0; i < command.Length; i++)
                    list.Add(command[i] == '1');

                return list;
            }
        }
    }
}
