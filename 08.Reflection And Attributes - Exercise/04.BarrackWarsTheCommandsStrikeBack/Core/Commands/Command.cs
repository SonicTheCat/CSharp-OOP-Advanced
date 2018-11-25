using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public abstract class Command : IExecutable
    {
        public Command(string[] data, IRepository repository, IUnitFactory factory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = factory;
        }

        public string[] Data { get; set; }

        public IRepository Repository { get; set; }

        public IUnitFactory UnitFactory { get; set; }

        public abstract string Execute();
    }
}