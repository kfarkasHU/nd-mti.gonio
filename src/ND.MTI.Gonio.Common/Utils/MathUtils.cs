using System;
using System.Linq;
using ND.MTI.Gonio.Model.Enum;
using System.Collections.Generic;
using ND.MTI.Gonio.Common.Exceptions;

namespace ND.MTI.Gonio.Common.Utils
{
    public static class MathUtils
    {
        public static IList<double> Operate(IList<double> results, MathOperation operation)
        {

            switch (operation)
            {
                case MathOperation.RAW:
                    {
                        return results;
                    }
                case MathOperation.AVG:
                    {
                        var result = results.Sum(m => m) / results.Count;
                        return new List<double>() { result };
                    }
                case MathOperation.SUM:
                    {
                        var result = results.Sum(m => m);

                        return new List<double>() { result };
                    }
                case MathOperation.MED:
                    {
                        var orderedResults = results.OrderBy(m => m).ToList();

                        if (orderedResults.Count % 2 == 0)
                        {
                            var index = orderedResults.Count / 2.0;
                            var lowerNeighbour = orderedResults[(int)Math.Floor(index)];
                            var biggerNeighbour = orderedResults[(int)Math.Ceiling(index)];

                            var result = (lowerNeighbour + biggerNeighbour) / 2;

                            return new List<double>() { result };
                        }
                        else
                        {
                            var result = orderedResults[orderedResults.Count / 2];

                            return new List<double>() { result };
                        }
                    }
                case MathOperation.MOD:
                    {
                        var result = results
                            .GroupBy(m => m)
                            .OrderByDescending(m => m.Count())
                            .ThenBy(m => m.Key)
                            .First()
                            .First()
                        ;

                        return new List<double>() { result };
                    }
                default:
                    throw new Gonio_Exception("Measures in same position is invalid!");
            }
        }
    }
}
