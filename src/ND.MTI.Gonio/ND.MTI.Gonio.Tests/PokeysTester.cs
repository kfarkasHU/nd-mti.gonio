using ND.MTI.Service.Worker.Pokeys;

namespace ND.MTI.Gonio.Tests
{
    public class PokeysTester : Pokeys57UWorker
    {
        public override void Init()
        {
            _device.SetPinData(0, 4);
            _device.SetPinData(1, 4);
            _device.SetPinData(2, 4);
            _device.SetPinData(3, 4);
            _device.SetPinData(4, 4);

            _device.SetPinData(5, 2);
            _device.SetPinData(6, 2);
            _device.SetPinData(7, 2);
            _device.SetPinData(8, 2);
            _device.SetPinData(9, 2);
        }

        public string Read()
        {
            var result = string.Empty;

            var state = false;
            _device.GetInput(5, ref state);
            result += stateStr();

            _device.GetInput(6, ref state);
            result += stateStr();

            _device.GetInput(7, ref state);
            result += stateStr();

            _device.GetInput(8, ref state);
            result += stateStr();

            _device.GetInput(9, ref state);
            result += stateStr();

            return result;

            string stateStr() => state ? "1" : "0";
        }

        internal void Write()
        {
            _device.SetOutput(0, true);
            _device.SetOutput(1, true);
            _device.SetOutput(2, true);
            _device.SetOutput(3, true);
            _device.SetOutput(4, true);
        }

        internal void Pwm()
        {
            var pwmOutputs = new bool[6];

            pwmOutputs[5] = true;
            pwmOutputs[4] = true;
            pwmOutputs[3] = true;
            pwmOutputs[2] = true;
            pwmOutputs[1] = true;
            pwmOutputs[0] = true;

            var period = (uint)(_device.GetPWMFrequency() / 300);

            var dutyScale = new uint[6];

            dutyScale[5] = (uint)(0.5 * period);
            dutyScale[4] = (uint)(0.5 * period);
            dutyScale[3] = (uint)(0.5 * period);
            dutyScale[2] = (uint)(0.5 * period);
            dutyScale[1] = (uint)(0.5 * period);
            dutyScale[0] = (uint)(0.5 * period);

            _device.SetPWMOutputs(ref pwmOutputs, ref period, ref dutyScale);
        }
    }
}
