using System;
using System.IO.Ports;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Common.Configuration;

namespace ND.MTI.Gonio.Service.Worker.Serial
{
    public abstract class SerialCore : ISerialCore
    {
        protected readonly SerialPort _serialPort;

        private readonly GonioTimer _timer;
        private readonly IGonioConfiguration _gonioConfiguration;

        public bool IsConnected => _serialPort.IsOpen;

        public SerialCore()
        {
            _serialPort = new SerialPort();
            _gonioConfiguration = GonioConfiguration.GetInstance();
            _timer = new GonioTimer(OnHeartbeatTick, _gonioConfiguration.SerialCore_Heartbeat);
        }

        private void OnHeartbeatTick(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
                return;

            throw new Exception($"Device removed from {_serialPort.PortName}!");
        }

        public virtual bool Connect(
            string comPortName,
            int dataBits,
            int speedInBaud,
            Parity parity,
            StopBits stopBits,
            int writeTimeout = 500,
            int readTimeout = 500
        )
        {
            try
            {
                _serialPort.DtrEnable = true;
                _serialPort.RtsEnable = true;
                _serialPort.PortName = comPortName;
                _serialPort.DataBits = dataBits;
                _serialPort.BaudRate = speedInBaud;
                _serialPort.Parity = parity;
                _serialPort.StopBits = stopBits;
                _serialPort.WriteTimeout = writeTimeout;
                _serialPort.ReadTimeout = readTimeout;

                _serialPort.Open();
                _timer.Start();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public virtual void Disconnect() => _serialPort.Dispose();

        private protected string SendCommandAndReadLine(string command)
        {
            try
            {
                _serialPort.Write(command + Environment.NewLine);

                var response = _serialPort.ReadLine();

                return response;
            }
            catch (TimeoutException tex)
            {
                throw tex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private protected void SendCommand(string command)
        {
            try
            {
                _serialPort.Write(command);
            }
            catch (TimeoutException tex)
            {
                throw tex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
