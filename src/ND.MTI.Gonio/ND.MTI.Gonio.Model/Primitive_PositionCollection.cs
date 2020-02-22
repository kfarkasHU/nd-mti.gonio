using System.Collections.Generic;

namespace ND.MTI.Gonio.Model
{
    public class Primitive_PositionCollection : List<Primitive_Position>
    {
        public void Add(double x, double y) => base.Add(new Primitive_Position(x, y));
    }
}
