using ND.MTI.Gonio.Common.Configuration;
using ND.MTI.Service.Worker;

namespace ND.MTI.Gonio.Tests
{
    public class GonioTests
    {
        private readonly IGonioWorker _gonioWorker;
        private readonly IGonioConfiguration _gonioConfiguration;

        public GonioTests()
        {
            _gonioWorker = new GonioWorker();
            _gonioConfiguration = GonioConfiguration.GetInstance();
        }

        public bool TestConnection() => _gonioWorker.Connect(_gonioConfiguration.FsmGonioConfig);

        public double TestMeasure() => _gonioWorker.Measure();

        public void TestReset() => _gonioWorker.Reset();

        public void TestDisconnect() => _gonioWorker.Reset();
    }
}
