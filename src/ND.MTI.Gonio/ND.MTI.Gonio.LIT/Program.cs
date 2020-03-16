using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ND.MTI.Gonio.LIT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NormalizeInternal(2314, 2000, 2000, 4000, 1));
            Console.WriteLine(NormalizeInternal(2314, 2000, 2000, 4000, -1));

            // 180
            Console.WriteLine(NormalizeInternal(2000, 2000, 2000, 4000, 1));
            Console.WriteLine(NormalizeInternal(2000, 2000, 2000, 4000, -1));

            // 0
            Console.WriteLine(NormalizeInternal(4000, 2000, 2000, 4000, 1));
            Console.WriteLine(NormalizeInternal(4000, 2000, 2000, 4000, -1));

            // 90
            Console.WriteLine(NormalizeInternal(3000, 2000, 2000, 4000, 1));
            Console.WriteLine(NormalizeInternal(3000, 2000, 2000, 4000, -1));

            // 45
            Console.WriteLine(NormalizeInternal(3500, 2000, 2000, 4000, 1));
            Console.WriteLine(NormalizeInternal(3500, 2000, 2000, 4000, -1));

            // 135
            Console.WriteLine(NormalizeInternal(2500, 2000, 2000, 4000, 1));
            Console.WriteLine(NormalizeInternal(2500, 2000, 2000, 4000, -1));

            Console.ReadKey();
        }

        private static double NormalizeInternal(
            int currentPosition,
            int decEndpointPosition,
            int incEndpointPostion,
            int maxEncPosition,
            int axisOperator
        )
        {
            // [] ------------------- || ------------------- []
            switch (axisOperator)
            {
                case 0: return 0;
                case -1: return axisOperator * NormalizeCore(decEndpointPosition);
                case +1: return axisOperator * NormalizeCore(incEndpointPostion);
            }

            return 0;

           double NormalizeCore(int localEndposition)
            {
                var localScale = maxEncPosition - localEndposition;
                var localSpectrum = 360 / 2;
                var normalizedEncPosition = currentPosition - localEndposition;

                var rate = ((double)normalizedEncPosition / localScale);
                var standardScale = localSpectrum * rate;

                return localSpectrum - standardScale;
            }
        }
    }
}
