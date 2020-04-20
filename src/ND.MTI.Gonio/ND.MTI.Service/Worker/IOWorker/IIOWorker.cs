﻿using System;
using System.Collections.Generic;

namespace ND.MTI.Gonio.Service.Worker
{
    public interface IIOWorker
    {
        void SaveFile(byte[] content, string extension);
        IList<Tuple<string, string>> ReadAllLines(string absolutePath, char separator);
    }
}
