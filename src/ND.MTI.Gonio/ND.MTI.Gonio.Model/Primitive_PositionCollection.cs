using System.Linq;
using System.Collections.Generic;

namespace ND.MTI.Gonio.Model
{
    public sealed class Primitive_PositionCollection : List<Primitive_Position>
    {
        public Primitive_PositionCollection RemoveDuplicates()
        {
            var distinct = this.Distinct();

            return (Primitive_PositionCollection)distinct;
        }
    }
}
