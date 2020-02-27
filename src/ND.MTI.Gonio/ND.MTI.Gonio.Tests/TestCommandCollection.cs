using System.Collections.Generic;
using System.Linq;

namespace ND.MTI.Gonio.Tests
{
    internal class TestCommandCollection : List<TestCommand>, IList<TestCommand>
    {
        private static TestCommandCollection _instance;

        private TestCommandCollection()
        {
            Add("gonio -c", "Connect to FSM Gonio 01", TestCase.TestCase_GonioConnect);
            Add("gonio -dc", "Disconnect from FSM Gonio 01", TestCase.TestCase_GonioDisconnect);
            Add("gonio -r", "Measure with FSM Gonio 01 if connected", TestCase.TestCase_GonioReset);
            Add("gonio -m", "Reset FSM Gonio 01 to startup settings", TestCase.TestCase_GonioMeasure);

            Add("gray -dec", "Converts a GRAY coded number to DECIMAL number", TestCase.TestCase_GrayToDecimal);

            Add("pokeys -c", "Connects to Pokey57U interface", TestCase.TestCase_PokeysConnect);
            Add("pokeys -dc", "Disconnects from Pokey57U interface", TestCase.TestCase_PokeysDisconnect);
            Add("pokeys -r", "Read data from Pokeys57U interface (PIN0-5)", TestCase.TestCase_PokeysRead);
            Add(
                "pokeys -rg",
                "Read data from Pokeys57U interface (PIN0-5) and converts it to decimal number. The data must be a gray coded number",
                TestCase.TestCase_PokeysReadAndConvert
            );
            Add("pokeys -w", "Writes data to Pokeys57U interface (PIN5-10)", TestCase.TestCase_PokeysWrite);
            Add("pokeys -pwm", "Create PWM-s (PIN17-22)", TestCase.TestCase_PokeysPWM);

            Add("help", "Help", TestCase.TestCase_Help);
            Add("all", "Run all tests", TestCase.TestCase_All);
            Add("exit", "Exit", TestCase.TestCase_Exit);
        }

        private void Add(string key, string description, TestCase testCase) =>Add(new TestCommand(key, description, testCase));

        public static TestCommandCollection GetInstance() => GetInstanceInternal();

        private static TestCommandCollection GetInstanceInternal()
        {
            if (_instance is null)
                _instance = new TestCommandCollection();

            return _instance;
        }

        public static TestCase GetTestCase(string command)
        {
            var collection = TestCommandCollection.GetInstanceInternal();

            var collectionItem = collection
                .Where(m => m.Key == command.ToLower())
                .SingleOrDefault()
                ;

            return collectionItem is null ? TestCase.TestCase_Main : collectionItem.TestCase;
        }
    }

    internal class TestCommand
    {
        public TestCommand(string key, string desc, TestCase testCase)
        {
            Key = key;
            Description = desc;
            TestCase = testCase;
        }

        public string Key { get; private set; }
        public string Description { get; private set; }
        public TestCase TestCase { get; private set; }
    }

    internal enum TestCase
    {
        TestCase_GonioConnect,
        TestCase_GonioDisconnect,
        TestCase_GonioReset,
        TestCase_GonioMeasure,
        TestCase_GrayToDecimal,
        TestCase_PokeysConnect,
        TestCase_PokeysDisconnect,
        TestCase_PokeysRead,
        TestCase_PokeysReadAndConvert,
        TestCase_PokeysWrite,
        TestCase_PokeysPWM,
        TestCase_Help,
        TestCase_All,
        TestCase_Exit,
        TestCase_Main
    }
}
