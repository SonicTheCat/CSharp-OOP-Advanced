using System.Collections.Generic;
using System.Text;
using OpenClosedLiskov.Contracts;
using OpenClosedLiskov.Enums;

namespace OpenClosedLiskov.Models
{
    public class Logger : ILogger
    {
        public ICollection<IAppender> Appenders { get; set; }

        public Logger(ICollection<IAppender> appenders)
        {
            this.Appenders = appenders;
        }

        public void Critical(string date, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.AppendMessage(date, ReportLevel.CRITICAL, message);
            }
        }

        public void Error(string date, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.AppendMessage(date, ReportLevel.ERROR, message);
            }
        }

        public void Fatal(string date, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.AppendMessage(date, ReportLevel.FATAL, message);
            }
        }

        public void Info(string date, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.AppendMessage(date, ReportLevel.INFO, message);
            }
        }

        public void Warn(string date, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.AppendMessage(date, ReportLevel.WARNING, message);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Logger info");

            foreach (var appender in this.Appenders)
            {
                builder.AppendLine(appender.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}