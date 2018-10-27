using OpenClosedLiskov.Appenders;
using OpenClosedLiskov.Contracts;
using OpenClosedLiskov.Enums;
using System;

namespace OpenClosedLiskov.Models
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void AppendMessage(string date, ReportLevel report, string message)
        {
            if (ReportLevel <= report)
            {
                Console.WriteLine(String.Format(Layout.Format, date, report, message));
                this.MessagesCount++;
            }
        }
    }
}