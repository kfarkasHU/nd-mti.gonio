using System;
using System.IO.Ports;
using ND.MTI.Gonio.Common.Utils;

namespace ND.MTI.Service.Worker.Serial
{
    public abstract class SerialCore : ISerialCore
    {
        private const string MeasureCommand = "M";
        private const string ResetCommand = "!";

        private readonly SerialPort _serialPort;

        public SerialCore()
        {
            _serialPort = new SerialPort();
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
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public virtual void Disconnect() => _serialPort.Dispose();

        public virtual double Measure()
        {
            var result = SendCommandAndReadLine(MeasureCommand);

            return Parser.StringToDouble(result);
        }

        public virtual void Reset() => _ = SendCommandAndReadLine(ResetCommand);

        private string SendCommandAndReadLine(string command)
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
    }
}
