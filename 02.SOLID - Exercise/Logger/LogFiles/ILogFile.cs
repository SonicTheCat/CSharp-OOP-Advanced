using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedLiskov.Contracts
{
    interface ILogFile
    {
        int Size { get; }

        void Write(string message);
    }
}
