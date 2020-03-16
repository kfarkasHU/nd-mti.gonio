using System;
using System.Linq;

namespace ND.MTI.Gonio.Common.Utils
{
    public static class GrayUtils
    {
        public static int GrayToInteger(string gray)
        {
            if (string.IsNullOrEmpty(gray))
                return 0;

            var output = string.Empty;
            
            for(var i = 0; i < gray.Length - 1; i++)
            {
                var current = gray[i];

                if (output == string.Empty)
                {
                    output += $"{current}";
                    continue;
                }

                var last = output.Last();

                var nextToAdd = xor(current.ToString(), last.ToString());
                output += $"{nextToAdd}";
            }

            return Convert.ToInt32(output, 2);

            int xor(string left, string right)
            {
                var iLeft = int.Parse(left);
                var iRight = int.Parse(right);

                return iLeft == iRight ? 0 : 1;
            }
        }
    }
}
