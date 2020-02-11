using System;

namespace ND.MTI.Gonio.Tests
{
    class Program
    {
        private static GonioTests _gonioTests;

        static void Main(string[] args)
        {
            _gonioTests = new GonioTests();

            string cmd;
            do
            {
                cmd = Console.ReadLine();

                switch(cmd)
                {
                    case "?":
                        {
                            Console.WriteLine("?, gonio");
                            break;
                        }
                    case "gonio":
                        {
                            TestGonio();

                            break;
                        }
                }
            }
            while (cmd != "exit");
        }

        private static void TestGonio()
        {
            Console.WriteLine("Testing gonio");

            var connected = _gonioTests.TestConnection();
            Console.WriteLine("Connection test: {0}", connected);

            var measured = _gonioTests.TestMeasure();
            Console.WriteLine("Measurement test: {0}", measured);
        }
    }
}
