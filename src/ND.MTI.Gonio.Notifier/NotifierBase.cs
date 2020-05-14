using System.Collections.Generic;

namespace ND.MTI.Gonio.Notifier
{
    public abstract class NotifierBase<T> : NotifierCore
    {
        protected readonly T _context;

        public NotifierBase(T context, IList<string> addresses) : base(addresses)
        {
            _context = context;
        }
    }
}
