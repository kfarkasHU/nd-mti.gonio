using System;
using System.Timers;
using ND.MTI.Service.Worker;
using System.Collections.Generic;
using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Gonio.Common.Utils;

namespace ND.MTI.Gonio.EPT
{
    class Program
    {
        private static IPositionWorker _worker;
        private static Timer _timer;

        private static IList<EPTResultItem> _results;

        static void Main()
        {
            var cfg = GonioConfiguration.GetInstance();

            _worker = PositionWorker.GetInstance();

            if (!_worker.IsConnected)
                _worker.Connect();

            _results = new List<EPTResultItem>();

            _timer = new Timer(cfg.Pokeys_ReadInterval);
            _timer.Elapsed += OnTimerTick;
            _timer.Start();

            _worker.StopX();
            _worker.StopY();

            _ = Console.ReadKey();

            //_worker.DecrementX();
            //_worker.IncrementX();

            _worker.DecrementY();            
            //_worker.IncrementY();

            //_worker.StopX();
            //_worker.StopY();

            _ = Console.ReadKey();

            _worker.StopX();
            _worker.StopY();
            _worker.Disconnect();

            Export();
        }

        private static void Export()
        {
            var l = new List<string>();

            for (var i = 0; i < _results.Count; i++)
                l.Add(_results[i].ToString());

            System.IO.File.WriteAllLines($"C:\\Users\\win10\\Desktop\\gonioresult\\goniotest_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt", l);
        }

        private static void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            var res = _worker.LastYResponse;
            Console.WriteLine($"{res} - {GrayUtils.GrayToInteger(res)}");

            _results.Add(new EPTResultItem(res));
        }
    }
}
