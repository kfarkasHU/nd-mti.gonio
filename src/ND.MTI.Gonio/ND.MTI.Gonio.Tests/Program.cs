using ND.MTI.Gonio.Common.Utils;
using System;
using System.Threading;

namespace ND.MTI.Gonio.Tests
{
    class Program
    {
        private static GonioTests _gonioTests;
        private static PokeysTester _pokeysTester;

        static void Main(string[] args)
        {
            _gonioTests = new GonioTests();
            _pokeysTester = new PokeysTester();

            _pokeysTester.Init();

            var currentCase = TestCase.TestCase_Main;

            do
            {
                Console.Write("> ");
                var command = Console.ReadLine();

                currentCase = TestCommandCollection.GetTestCase(command);

                DoCommand(currentCase);
            }
            while (currentCase != TestCase.TestCase_Exit);
        }

        private static void DoCommand(TestCase testCase)
        {
            switch (testCase)
            {
                case TestCase.TestCase_GonioConnect:
                    Console.WriteLine("Expected: TRUE");

                    var gcResult = _gonioTests.TestConnection();

                    Console.WriteLine($"Got: {gcResult.ToString().ToLower()}");
                    break;

                case TestCase.TestCase_GonioDisconnect:
                    Console.WriteLine("Disconnecting from FSM Gonio 01");
                    Console.WriteLine("No return value!");

                    _gonioTests.TestDisconnect();
                    break;

                case TestCase.TestCase_GonioMeasure:
                    Console.WriteLine("Measuring with FSM Gonio 01");

                    var gmResult = _gonioTests.TestMeasure();

                    Console.WriteLine($"Measurement result: {gmResult}");

                    break;

                case TestCase.TestCase_GonioReset:
                    Console.WriteLine("Resetting the FSM Gonio 01");
                    Console.WriteLine("No return value!");

                    _gonioTests.TestReset();
                    break;

                case TestCase.TestCase_GrayToDecimal:
                    Console.WriteLine("Enter a gray coded number");
                    var grayNumber = Console.ReadLine();
                    var decimalNumber = GrayUtils.GrayToInteger(grayNumber);

                    Console.WriteLine($"Result: {decimalNumber}");
                    break;

                case TestCase.TestCase_PokeysConnect:
                    Console.WriteLine("Connect to pokeys device");
                    Console.WriteLine("Expected: TRUE");

                    try
                    {
                        var pcResult = _pokeysTester.Connect();
                        Console.WriteLine($"Got: {pcResult.ToString().ToLower()}");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;

                case TestCase.TestCase_PokeysDisconnect:
                    Console.WriteLine("Disconnecting from pokeys device");
                    Console.WriteLine("No return value!");

                    _pokeysTester.Disconnect();
                    break;

                case TestCase.TestCase_PokeysRead:
                    Console.WriteLine("Reading from pokeys device");
                    var prResult = _pokeysTester.Read();

                    Console.WriteLine($"Result: {prResult}");
                    break;

                case TestCase.TestCase_PokeysReadAndConvert:
                    Console.WriteLine("Reading from pokeys device");
                    var prgResult = _pokeysTester.Read();

                    Console.WriteLine($"Gray Result: {prgResult}");
                    var prcResult = GrayUtils.GrayToInteger(prgResult);

                    Console.WriteLine($"Decimal Result: {prcResult}");
                    break;

                case TestCase.TestCase_PokeysWrite:
                    Console.WriteLine("Writing to pokeys device");

                    _pokeysTester.Write();
                    break;

                case TestCase.TestCase_PokeysPWM:
                    Console.WriteLine("Creating pokeys PWMs");

                    _pokeysTester.Pwm();
                    break;

                case TestCase.TestCase_Help:
                    var commands = TestCommandCollection.GetInstance();

                    foreach (var command in commands)
                        Console.WriteLine($"{command.Key} - {command.Description}");

                    break;
            }
        }
    }
}
