using System.Collections;
using System.Collections.Generic;

namespace OpenClosedLiskov.Contracts
{
    public interface ILogger
    {
        ICollection<IAppender> Appenders { get; }

        void Info(string date, string message);

        void Warn(string date, string message);

        void Error(string date, string message);

        void Critical(string date, string message);

        void Fatal(string date, string message);
    }
}