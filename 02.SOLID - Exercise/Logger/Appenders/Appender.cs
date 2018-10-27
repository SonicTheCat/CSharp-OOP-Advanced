using OpenClosedLiskov.Contracts;
using OpenClosedLiskov.Enums;

namespace OpenClosedLiskov.Appenders
{
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevel = ReportLevel.INFO; 
        }

        public int MessagesCount { get; protected set; }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public abstract void AppendMessage(string date, ReportLevel report, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesCount}";
        }
    }
}
