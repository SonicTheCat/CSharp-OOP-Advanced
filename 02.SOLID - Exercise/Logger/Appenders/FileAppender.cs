using OpenClosedLiskov.Contracts;
using OpenClosedLiskov.Enums;
using System;

namespace OpenClosedLiskov.Appenders
{
    class FileAppender : Appender
    {
        public FileAppender(ILayout layout) 
            : base(layout)
        {
        }

        public ILogFile File { get; set; }

        public override void AppendMessage(string date, ReportLevel report, string message)
        {
            if (report >= ReportLevel)
            {
                this.File.Write(String.Format(Layout.Format, date, report, message));
                this.MessagesCount++;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}
