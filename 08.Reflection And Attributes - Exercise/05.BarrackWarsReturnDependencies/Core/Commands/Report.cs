using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class Report : Command
    {
        public Report(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }

        [Inject]
        public IRepository Repository { get; set; }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}