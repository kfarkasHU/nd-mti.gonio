using System.Collections.Generic;

namespace ND.MTI.Gonio.Common.Extensions
{
    public static class ListExtenions
    {
        public static T GetModus<T>(this IList<T> list)
        {
            for (var i = 1; i < list.Count; i++)
                if (list[i].Equals(list[i - 1]))
                    return list[i];

            return list[0];
        }
    }
}
