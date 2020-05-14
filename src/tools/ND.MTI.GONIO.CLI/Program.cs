using System;
using ND.MTI.Gonio.Model;
using ND.MTI.Gonio.Common.Utils;
using ND.MTI.Gonio.Service.Worker;
using ND.MTI.Gonio.Common.RuntimeContext;

namespace ND.MTI.Gonio.CLI
{
    class Program
    {
        private static IGonioWorker _gonioWorker;
        private static IPositionWorker _positionWorker;

        static void Main()
        {
            _gonioWorker = GonioWorker.GetInstance();
            _positionWorker = PositionWorker.GetInstance();

            ReadCommand();
            Console.ReadKey();
        }

        private static void ReadCommand()
        {
            var command = string.Empty;
            do
            {
                command = Console.ReadLine();
                command = command.ToLower();

                if (string.Equals(command, "getp"))
                    GetPosition();

                if (command.StartsWith("setp"))
                    SetPosition(command);

                if (string.Equals(command, "fsm"))
                    Measure();

                if (string.Equals(command, "status"))
                    Status();

                if (string.Equals(command, "encoder"))
                    Encoder();

                if (string.Equals(command, "help"))
                    Help();
            }
            while (!string.Equals(command, "exit"));
        }

        private static void GetPosition()
        {
            var position = _positionWorker.GetPosition();
            Console.WriteLine($"Current position: {position}.");
        }

        private static void SetPosition(string command)
        {
            var p = command.Split(' ');

            if(p.Length == 3)
            {
                try
                {
                    var x = Parser.StringToDouble(p[1]);
                    var y = Parser.StringToDouble(p[2]);

                    _positionWorker.SetPosition(new Primitive_Position(x, y));
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void Measure()
        {
            var data = _gonioWorker.Measure();
            Console.WriteLine($"FSM Gonio 01: {data}lx");
        }

        private static void Status()
        {
            Console.WriteLine($"FSM Gonio connection status: {RuntimeContext.IsFSMGonioConnected}");
            Console.WriteLine($"SSI Panel connection status: {RuntimeContext.IsSSIPanelConnected}");
            Console.WriteLine($"Pokeys 57 connection status: {RuntimeContext.IsPokeys57Connected}");
        }

        private static void Encoder()
        {
            var data = _positionWorker.GetIncomeData();
            Console.WriteLine($"X: {data.Item1}");
            Console.WriteLine($"Y: {data.Item2}");
        }

        private static void Help()
        {
            Console.WriteLine("`getp` - gets current position");
            Console.WriteLine("`setp {x} {y} - sets target position");
            Console.WriteLine("`fsm` - measure");
            Console.WriteLine("`status` - prints device status");
            Console.WriteLine("`encoder - prints the raw value from encoders");
            Console.WriteLine("`help` - current list");
            Console.WriteLine("`exit` - closes the program");
        }
    }
}
