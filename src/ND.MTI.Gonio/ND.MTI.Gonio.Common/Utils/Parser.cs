using System;
using System.Collections.Generic;

namespace ND.MTI.Gonio.Common.Utils
{
    public static class Parser
    {
        public static double StringToDouble(string str)
        {
            if (str.Contains("."))
                str = str.Replace(".", ",");

            var success = double.TryParse(str, out var doub);

            if (!success)
                throw new Exception($"Cannot parse {str} to double!");

            return doub;
        }

        public static int StringToInteger(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            var success = int.TryParse(str, out var integer);

            if (!success)
                throw new Exception($"Cannot parse {str} to integer!");

            return integer;
        }

        public static TEnum StringIntToEnum<TEnum>(string strInt) => (TEnum)Enum.Parse(typeof(TEnum), strInt);

        public static double DecimalToDouble(decimal dec) => (double)dec;

        public static bool StringToBoolean(string boolStr) => boolStr == "1" || boolStr.ToLower() == "true";

        public static IList<string> StringToStringList(string listStr)
        {
            var separator = ';';

            if (!listStr.Contains(separator.ToString()))
                return new List<string>() { listStr };

            var p = listStr.Split(separator);
            var list = new List<string>();

            foreach (var i in p)
                list.Add(i);

            return list;
        }
    }
}
