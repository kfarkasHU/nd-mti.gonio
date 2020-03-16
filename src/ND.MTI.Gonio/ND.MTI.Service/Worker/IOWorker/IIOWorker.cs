using System;
using System.Collections.Generic;

namespace ND.MTI.Service.Worker
{
    public interface IIOWorker
    {
        void SaveFile(byte[] content);
        IList<Tuple<string, string>> ReadAllLines(string absolutePath, char separator);
    }
}
