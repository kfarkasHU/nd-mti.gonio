using System;
using System.Windows.Forms;

namespace ND.MTI.Service.Worker.Pokeys
{
    public abstract class Pokeys57UWorker : IPokeys57UWorker
    {
        private readonly Timer _timer;
        private readonly PoKeysDevice_DLL.PoKeysDevice _device;

        public string LastXResponse { get; private set; }
        public string LastYResponse { get; private set; }


        public Pokeys57UWorker()
        {
            _device = new PoKeysDevice_DLL.PoKeysDevice();
            _timer = new Timer();
            _timer.Tick += new EventHandler(OnTimerTick);
            _timer.Interval = 100;

        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            LastXResponse = ReadXInternal();
            LastYResponse = ReadYInternal();
        }

        public bool Connect() => _device.ConnectToDevice(0);

        public void Disconnect() => _device.DisconnectDevice();

        public void Init()
        {
            #region [ X bits ]

            #region [ X bits > read ]
            
            // X Encoder data
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_1, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_2, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_3, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_4, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_5, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_6, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_7, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_8, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_9, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_10, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_11, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_12, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_13, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);

            // X right end state switch
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_14, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);

            // X left end state switch
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_15, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);

            // X reserved bit
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_16, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);

            #endregion [ X bits > read ]

            #region [ X bits > write ]

            // X PUL+ (PWM)
            //_device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_33, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_OUTPUT);

            // X DIR+
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_34, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_OUTPUT);

            // X ENA+
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_35, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_OUTPUT);

            // X reserved bit
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_36, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_OUTPUT);

            #endregion [ X bits > write ]

            #endregion [ X bits ]

            #region [ Y bits ]

            #region [ Y bits > read ]

            // Y Encoder data
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_17, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_18, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_19, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_20, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_21, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_22, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_23, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_24, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_25, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_26, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_27, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_28, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_29, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);

            // Y right end state switch
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_30, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);

            // Y left end state switch
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_31, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);

            // Y reserved bit
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_32, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_INPUT);

            #endregion [ X bits > read ]

            #region [ Y bits > write ]

            // Y PUL+ (PWM)
            //_device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_37, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_OUTPUT);

            // Y DIR+
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_38, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_OUTPUT);

            // Y ENA+
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_39, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_OUTPUT);

            // Y reserved bit
            _device.SetPinData((byte)Pokeys57U_PinNumbers.PIN_40, (byte)Pokeys57U_PinFunctions.PIN_DIGITAL_OUTPUT);

            #endregion [ Y bits > write ]

            #endregion [ Y bits ]

            #region [ set up PWMs ]

            var pwmOutputs = new bool[6];

            pwmOutputs[5] = true;  // 17 (X)
            pwmOutputs[4] = true;  // 18 (Y)
            pwmOutputs[3] = false; // 19
            pwmOutputs[2] = false; // 20
            pwmOutputs[1] = false; // 21
            pwmOutputs[0] = false; // 22

            // 12MHz / 300 = 40kHz
            var period = (uint)_device.GetPWMFrequency() / 300; // 40 kHz

            // Create 50% PWM.
            var dutyScale = new uint[6];

            dutyScale[5] = (uint)(0.5 * period);
            dutyScale[4] = (uint)(0.5 * period);

            _device.SetPWMOutputs(ref pwmOutputs, ref period, ref dutyScale);

            #endregion [ set up PWMs ]

            _timer.Enabled = true;
        }

        public void WriteDataX(string message)
        {
            if (message.Length > 3)
                throw new ArgumentOutOfRangeException();

            if (message.Length < 3)
                throw new ArgumentNullException();

            var bytes = CreateMessageBytesInternal(message);

            // PIN 33 is PWM
            _device.SetOutput((byte)Pokeys57U_PinNumbers.PIN_34, bytes[0]);
            _device.SetOutput((byte)Pokeys57U_PinNumbers.PIN_35, bytes[1]);
            _device.SetOutput((byte)Pokeys57U_PinNumbers.PIN_36, bytes[2]);
        }

        public void WriteDataY(string message)
        {
            if (message.Length > 3)
                throw new ArgumentOutOfRangeException();

            if (message.Length < 3)
                throw new ArgumentNullException();

            var bytes = CreateMessageBytesInternal(message);

            // PIN 37 is PWM
            _device.SetOutput((byte)Pokeys57U_PinNumbers.PIN_38, bytes[0]);
            _device.SetOutput((byte)Pokeys57U_PinNumbers.PIN_39, bytes[1]);
            _device.SetOutput((byte)Pokeys57U_PinNumbers.PIN_40, bytes[2]);
        }

        private bool[] CreateMessageBytesInternal(string message)
        {
            var result = new bool[3];

            result[0] = ParseBool(message[0]);
            result[1] = ParseBool(message[1]);
            result[2] = ParseBool(message[2]);

            return result;

            bool ParseBool(char c) => c == '1';
        }

        private string ReadXInternal()
        {
            var response = string.Empty;
            var pinState = false;

            var xPins = new Pokeys57U_PinNumbers[]
            {
                Pokeys57U_PinNumbers.PIN_1,
                Pokeys57U_PinNumbers.PIN_2,
                Pokeys57U_PinNumbers.PIN_3,
                Pokeys57U_PinNumbers.PIN_4,
                Pokeys57U_PinNumbers.PIN_5,
                Pokeys57U_PinNumbers.PIN_6,
                Pokeys57U_PinNumbers.PIN_7,
                Pokeys57U_PinNumbers.PIN_8,
                Pokeys57U_PinNumbers.PIN_9,
                Pokeys57U_PinNumbers.PIN_10,
                Pokeys57U_PinNumbers.PIN_11,
                Pokeys57U_PinNumbers.PIN_12,
                Pokeys57U_PinNumbers.PIN_13,
                Pokeys57U_PinNumbers.PIN_14,
                //Pokeys57U_PinNumbers.PIN_15,
                //Pokeys57U_PinNumbers.PIN_16,
            };

            var state = false;
            if (_device.GetInput((byte)Pokeys57U_PinNumbers.PIN_15, ref state))
                throw new Exception("Endpoint reached: P15");

            if (_device.GetInput((byte)Pokeys57U_PinNumbers.PIN_16, ref state))
                throw new Exception("Endpoint reached: P16");

            for (var i = 0; i < xPins.Length; i++)
                AppendResponse(ref response, _device.GetInput((byte)xPins[i], ref pinState));

            return response;
        }

        private string ReadYInternal()
        {
            var response = string.Empty;
            var pinState = false;

            var xPins = new Pokeys57U_PinNumbers[]
            {
                Pokeys57U_PinNumbers.PIN_17,
                Pokeys57U_PinNumbers.PIN_18,
                Pokeys57U_PinNumbers.PIN_19,
                Pokeys57U_PinNumbers.PIN_20,
                Pokeys57U_PinNumbers.PIN_21,
                Pokeys57U_PinNumbers.PIN_22,
                Pokeys57U_PinNumbers.PIN_23,
                Pokeys57U_PinNumbers.PIN_24,
                Pokeys57U_PinNumbers.PIN_25,
                Pokeys57U_PinNumbers.PIN_26,
                Pokeys57U_PinNumbers.PIN_27,
                Pokeys57U_PinNumbers.PIN_28,
                Pokeys57U_PinNumbers.PIN_29,
                Pokeys57U_PinNumbers.PIN_30,
                //Pokeys57U_PinNumbers.PIN_31,
                //Pokeys57U_PinNumbers.PIN_32,

            };

            var state = false;
            if (_device.GetInput((byte)Pokeys57U_PinNumbers.PIN_31, ref state))
                throw new Exception("Endpoint reached: P31");

            if (_device.GetInput((byte)Pokeys57U_PinNumbers.PIN_32, ref state))
                throw new Exception("Endpoint reached: P32");

            for (var i = 0; i < xPins.Length; i++)
                AppendResponse(ref response, _device.GetInput((byte)xPins[i], ref pinState));

            return response;
        }

        private void AppendResponse(ref string response, bool state) => response += state ? "1" : "0";
    }
}
