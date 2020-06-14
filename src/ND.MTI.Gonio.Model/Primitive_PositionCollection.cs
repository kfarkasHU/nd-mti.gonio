using System.Collections.Generic;

namespace ND.MTI.Gonio.Model
{
    public sealed class Primitive_PositionCollection : List<Primitive_Position>
    {
        public Primitive_PositionCollection RemoveDuplicates()
        {
            var distinct = new Primitive_PositionCollection();

            for (var i = 0; i < this.Count; i++)
                if (!distinct.Contains(this[i]))
                    distinct.Add(this[i]);

            return distinct;
        }
    }
}
