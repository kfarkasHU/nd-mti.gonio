using System;
using System.Linq;
using System.Collections.Generic;
using ND.MTI.Gonio.Common.Exceptions;

namespace ND.MTI.Gonio.Common.Extensions
{
    public static class ListExtensions
    {
        public static void CreateFromMerge(
            this IList<Tuple<double, double>> list,
            IList<double> item1List,
            IList<double> item2List
        ) {
            if (item1List.Count != item2List.Count)
                throw new Gonio_Exception("The length of the two lists must match!");

            list.Clear();

            foreach (var i in Enumerable.Range(0, item1List.Count))
                list.Add(new Tuple<double, double>(item1List[i], item2List[i]));
        }
    }
}
