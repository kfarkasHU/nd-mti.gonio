using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ND.MTI.Gonio.Common.Configuration;

namespace ND.MTI.Gonio.GCT
{
    class Program
    {
        private static IGonioConfiguration _config;

        static void Main(string[] args)
        {
            _config = GonioConfiguration.GetInstance();

            var _FSM_GonioConfig = _config.FSM_GonioConfig;
            var _Sensor_Distance = _config.Sensor_Distance;
            var _Pokeys_ReadInterval = _config.Pokeys_ReadInterval;
            var _Encoder_DecXEnd = _config.Encoder_DecXEnd;
            var _Encoder_IncXEnd = _config.Encoder_IncXEnd;
            var _Encoder_MaxXEnc = _config.Encoder_MaxXEnc;
            var _Encoder_DecYEnd = _config.Encoder_DecYEnd;
            var _Encoder_IncYEnd = _config.Encoder_IncYEnd;
            var _Encoder_MaxYEnc = _config.Encoder_MaxYEnc;
            var _Application_ConnectGonioAuto = _config.Application_ConnectGonioAuto;
            var _Application_ConnectPokeysAuto = _config.Application_ConnectPokeysAuto;
            var _Position_AbsoluteZeroX = _config.Position_AbsoluteZeroX;
            var _Position_AbsoluteZeroY = _config.Position_AbsoluteZeroY;

            Console.WriteLine($"FSM_GonioConfig: {_FSM_GonioConfig}");
            Console.WriteLine($"Sensor_Distance: {_Sensor_Distance}");
            Console.WriteLine($"Pokeys_ReadInterval: {_Pokeys_ReadInterval}");
            Console.WriteLine($"Encoder_DecXEnd: {_Encoder_DecXEnd}");
            Console.WriteLine($"Encoder_IncXEnd: {_Encoder_IncXEnd}");
            Console.WriteLine($"Encoder_MaxXEnc: {_Encoder_MaxXEnc}");
            Console.WriteLine($"Encoder_DecYEnd: {_Encoder_DecYEnd}");
            Console.WriteLine($"Encoder_IncYEnd: {_Encoder_IncYEnd}");
            Console.WriteLine($"Encoder_MaxYEnc: {_Encoder_MaxYEnc}");
            Console.WriteLine($"Application_ConnectGonioAuto: {_Application_ConnectGonioAuto}");
            Console.WriteLine($"Application_ConnectPokeysAuto: {_Application_ConnectPokeysAuto}");
            Console.WriteLine($"Position_AbsoluteZeroX: {_Position_AbsoluteZeroX}");
            Console.WriteLine($"Position_AbsoluteZeroY: {_Position_AbsoluteZeroY}");

            Console.ReadKey();
        }
    }
}
