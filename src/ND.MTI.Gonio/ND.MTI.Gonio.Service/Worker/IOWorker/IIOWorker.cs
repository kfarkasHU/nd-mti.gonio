using System;
using System.Collections.Generic;

namespace ND.MTI.Gonio.Service.Worker
{
    public interface IIOWorker
    {
        string LoadFile(string extension);
        IList<string> ReadAllLines(string path);
        void SaveFile(object[] lines, string extension);
        void SaveFile(byte[] content, string extension);
        IList<Tuple<string, string>> ReadAllLines(string absolutePath, char separator);
    }
}
