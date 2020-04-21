using System.Linq;
using ND.MTI.Gonio.Model;
using System.Collections.Generic;
using System;
using ND.MTI.Gonio.Service.Worker;
using ND.MTI.Gonio.Common.Utils;

namespace ND.MTI.Gonio.Service.Helper
{
    public class PositionMatrixHelper
    {
        public static Primitive_PositionCollection CalculatePositionMatrix(Complex_MainModel config)
        {
            var xVect = CreateAxisVectInternal(config.Start.X, config.End.X, config.StepX);
            var yVect = CreateAxisVectInternal(config.Start.Y, config.End.Y, config.StepY);

            return MergeVectorsInternal(xVect, yVect);
        }

        public static Primitive_PositionCollection MergeVectors(IList<double> vectA, IList<double> vectB) => MergeVectorsInternal(vectA, vectB);

        private static Primitive_PositionCollection MergeVectorsInternal(IList<double> vectA, IList<double> vectB)
        {
            var matrix = new Primitive_PositionCollection();
            for (var ix = 0; ix < vectA.Count; ix++)
            {
                var bRelatives = ix % 2 == 0
                    ? vectB
                    : vectB
                        .Reverse()
                        .ToList();

                for (var iy = 0; iy < bRelatives.Count; iy++)
                    matrix.Add(new Primitive_Position(vectA[ix], bRelatives[iy]));
            }

            return matrix;
        }

        public static IList<double> CreateAxisVect(double start, double end, double? step) => CreateAxisVectInternal(start, end, step);
        private static IList<double> CreateAxisVectInternal(double start, double end, double? step)
        {
            if (start == end)
                return new List<double>() { start };

            if (!step.HasValue)
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

                for (var current = bigger; current > smaller - step.Value; current -= step.Value)
                    coreList.Add(current);

                return coreList;
            }
        }

        internal static Primitive_PositionCollection GetRouteFrom(string externalRoute)
        {

            var ioWorker = new IOWorker();
            var matrix = new Primitive_PositionCollection();

            var lines = ioWorker.ReadAllLines(externalRoute);

            for (var i = 0; i < lines.Count; i++)
                matrix.Add(ToPosition(lines[i]));

            return matrix;

            Primitive_Position ToPosition(string line)
            {
                var p = line.Split(' ');
                return new Primitive_Position(
                    Parser.StringToDouble(p[1]),
                    Parser.StringToDouble(p[3])
                );
            }
        }
    }
}
