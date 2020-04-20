using System;
using System.IO;
using System.Linq;
using System.Reflection;
using ND.MTI.Gonio.Common.Utils;
using System.Collections.Generic;
using ND.MTI.Gonio.Service.Worker;

namespace ND.MTI.Gonio.Service
{
    public class ExcelExportServiceHelper
    {
        private readonly IIOWorker _ioWorker;
        private readonly IList<Tuple<double, double>> _cache;
        private readonly string _helpFilePath;

        public ExcelExportServiceHelper()
        {
            _ioWorker = new IOWorker();

            _helpFilePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\calculations.cfg";
            var helpLines = _ioWorker.ReadAllLines(_helpFilePath, '=');

            _cache = new List<Tuple<double, double>>();
            foreach(var line in helpLines)
                _cache.Add(
                    new Tuple<double, double>(
                        Parser.StringToDouble(line.Item1),
                        Parser.StringToDouble(line.Item2)
                    )
                );

            _cache = _cache
                .OrderBy(m => m.Item1)
                .ToList()
                ;
        }

        public double GetCorrectionValue(double measuredValue)
        {
            var equalItem = GetEqualItem();

            if (!(equalItem is null))
                return equalItem.Item2;

            var smallerNeightbour = GetBiggestSmallerItem();

            if (smallerNeightbour is null)
                return _cache.First().Item2;

            var biggerNeightbour = GetSmallestBiggerItem();

            if (biggerNeightbour is null)
                return _cache.Last().Item2;

            #region [ y = mx + b ]

            var dX = biggerNeightbour.Item1 - smallerNeightbour.Item1;
            var dY = biggerNeightbour.Item2 - smallerNeightbour.Item2;
            var m = dY / dX;

            var b = (smallerNeightbour.Item1 - smallerNeightbour.Item2 / m) * m;
            var y = m * measuredValue - b; // b will be smaller than zero

            return y;

            #endregion [ y = mx + b ]

            Tuple<double, double> GetBiggestSmallerItem() => _cache.LastOrDefault(n => n.Item1 > measuredValue);

            Tuple<double, double> GetSmallestBiggerItem() => _cache.FirstOrDefault(n => n.Item1 < measuredValue);

            Tuple<double, double> GetEqualItem() => _cache.FirstOrDefault(n => n.Item1 == measuredValue);
        }
    }
}
