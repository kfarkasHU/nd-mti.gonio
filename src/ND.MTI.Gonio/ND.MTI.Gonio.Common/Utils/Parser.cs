using System;

namespace ND.MTI.Gonio.Common.Utils
{
    public static class Parser
    {
        public static double StringToDouble(string str)
        {
            var success = double.TryParse(str, out var doub);

            if (!success)
                throw new Exception($"Cannot parse {str} to double!");

            return doub;
        }

        public static int StringToInteger(string str)
        {
            var success = int.TryParse(str, out var integer);

            if (!success)
                throw new Exception($"Cannot parse {str} to integer!");

            return integer;
        }

        public static TEnum StringIntToEnum<TEnum>(string strInt) => (TEnum)Enum.Parse(typeof(TEnum), strInt);
    }
}
