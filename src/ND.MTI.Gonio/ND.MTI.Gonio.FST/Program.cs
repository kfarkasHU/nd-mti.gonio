using System;
using System.Linq;
using ND.MTI.Service.Worker;
using ND.MTI.Gonio.Common.Configuration;

namespace ND.MTI.Gonio.FST
{
    class Program
    {
        private static IGonioWorker _gonioWorker;
        private static IGonioConfiguration _gonioConfiguration;

        static void Main(string[] args)
        {
            _gonioWorker = new GonioWorker();
            _gonioConfiguration = GonioConfiguration.GetInstance();

            _ = _gonioWorker.Connect(_gonioConfiguration.FSM_GonioConfig);

            foreach(var _ in Enumerable.Range(0, 100))
                Console.WriteLine($"M: {_gonioWorker.Measure()}");

            Console.ReadKey();
        }
    }
}
