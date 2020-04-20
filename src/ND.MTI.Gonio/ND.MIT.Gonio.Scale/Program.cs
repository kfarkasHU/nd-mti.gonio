using System;
using System.Collections.Generic;
using System.Timers;
using ND.MTI.Service.Worker;

namespace ND.MIT.Gonio.Scale
{
    class Program
    {
        private static IPositionWorker _positionWorker;
        private static Timer _timer;

        private static IList<string> _cache;

        static void Main()        
        {
            _cache = new List<string>();

            _positionWorker = PositionWorker.GetInstance();
            _positionWorker.StopX();
            _positionWorker.StopY();

            _timer = new Timer();
            _timer.Elapsed += OnTimerTick;
            _timer.Interval = 1;
            _timer.Start();

            #region x

            Console.WriteLine("Start DEC X");
            Console.ReadKey();

            _positionWorker.DecrementX();

            Console.WriteLine("Stop DEC X");
            Console.ReadKey();

            _positionWorker.StopX();

            Console.WriteLine("Start INC X");
            Console.ReadKey();

            _positionWorker.IncrementX();

            Console.WriteLine("Stop INC X");
            Console.ReadKey();

            _positionWorker.StopX();

            #endregion

            #region y

            Console.WriteLine("Start DEC Y");
            Console.ReadKey();

            _positionWorker.DecrementY();

            Console.WriteLine("Stop DEC Y");
            Console.ReadKey();

            _positionWorker.StopY();

            Console.WriteLine("Start INC Y");
            Console.ReadKey();

            _positionWorker.IncrementY();

            Console.WriteLine("Stop INC Y");
            Console.ReadKey();

            _positionWorker.StopY();

            #endregion

            Console.WriteLine("Stop timer");
            Console.ReadKey();

            _timer.Stop();

            System.IO.File.WriteAllText("C:\\Users\\win10\\Desktop\\aaa.txt", string.Join(Environment.NewLine, _cache));

            Console.ReadKey();
        }

        private static void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            var pos = _positionWorker.GetPosition();

            _cache.Add(pos.ToString());

            Console.WriteLine(pos.ToString());
        }
    }
}
