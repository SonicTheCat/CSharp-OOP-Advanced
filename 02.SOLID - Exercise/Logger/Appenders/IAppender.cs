using OpenClosedLiskov.Enums;

namespace OpenClosedLiskov.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void AppendMessage(string date, ReportLevel report, string message);
    }
}