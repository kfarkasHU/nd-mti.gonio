using System;
using System.Linq;
using ND.MTI.Gonio.Common.Utils;
using System.Collections.Generic;
using ND.MTI.Gonio.Model;

namespace ND.MTI.Gonio.RMT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Start X coord: ");
            var startXStr = Console.ReadLine();

            Console.Write("End X coord: ");
            var endXStr = Console.ReadLine();

            Console.Write("Step X: ");
            var stepXStr = Console.ReadLine();

            Console.Write("Start Y coord: ");
            var startYStr = Console.ReadLine();

            Console.Write("End Y coord: ");
            var endYStr = Console.ReadLine();

            Console.Write("Step Y: ");
            var stepYStr = Console.ReadLine();

            Console.WriteLine();

            var XStart = Parser.StringToDouble(startXStr);
            var XEnd = Parser.StringToDouble(endXStr);
            var XStep = Parser.StringToDouble(stepXStr);
            var YStart = Parser.StringToDouble(startYStr);
            var YEnd = Parser.StringToDouble(endYStr);
            var YStep = Parser.StringToDouble(stepYStr);

            Console.WriteLine($"Generating route datas with params");
            Console.WriteLine($"AXIS ||  START  ||  END  ||  STEP ");
            Console.WriteLine($"   X ||{XStart.ToString().PadLeft(8, ' ')} || {XEnd.ToString().PadLeft(5, ' ')} || {XStep.ToString().PadLeft(6, ' ')}");
            Console.WriteLine($"   Y ||{YStart.ToString().PadLeft(8, ' ')} || {YEnd.ToString().PadLeft(5, ' ')} || {YStep.ToString().PadLeft(6, ' ')}");
            Console.WriteLine();

            var xVect = CreateAxisVect(XStart, XEnd, XStep);
            var yVect = CreateAxisVect(YStart, YEnd, YStep);

            Console.WriteLine($"X vector: {string.Join(", ", xVect.ToArray())}");
            Console.WriteLine($"Y vector: {string.Join(", ", yVect.ToArray())}");
            Console.WriteLine();

            var routeMatrix = CreateRouteMatrix(xVect, yVect);
            Console.WriteLine("Entire route matrix");
            for (var i = 0; i < routeMatrix.Count; i++)
                Console.WriteLine(routeMatrix[i].ToString());

            Console.ReadKey();
        }

        private static Primitive_PositionCollection CreateRouteMatrix(IList<double> xVect, IList<double> yVect)
        {
            var list = new Primitive_PositionCollection();

            for(var ix = 0; ix < xVect.Count; ix++)
            {
                var yRelatives = ix % 2 == 0
                    ? yVect
                    : yVect
                        .Reverse()
                        .ToList();

                for (var iy = 0; iy < yRelatives.Count; iy++)
                    list.Add(new Primitive_Position(xVect[ix], yRelatives[iy]));
            }

            return list;
        }

        private static IList<double> CreateAxisVect(double start, double end, double step)
        {
            if (start == end)
                return new List<double>() { start };

            var list = start > end
                ? CreateAxisVectCore(start, end)
                : CreateAxisVectCore(end, start)
                    .Reverse()
                    .ToList();

            return list;

            IList<double> CreateAxisVectCore(double bigger, double smaller)
            {
                var coreList = new List<double>();

                for (var current = bigger; current > smaller - step; current -= step)
                    coreList.Add(current);

                return coreList;
            }
        }
    }
}
