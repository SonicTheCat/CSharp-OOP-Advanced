using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class Report : Command
    {
        public Report(string[] data, IRepository repository, IUnitFactory factory)
            : base(data, repository, factory)
        {
        }

        public override string Execute()
        {
            string output = base.Repository.Statistics;
            return output;
        }
    }
}