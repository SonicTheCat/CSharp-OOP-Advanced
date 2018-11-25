using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class Retire : Command
    {
        public Retire(string[] data, IRepository repository) 
            : base(data)
        {
            this.Repository = repository;
        }

        [Inject]
        public IRepository Repository { get; set; }

        public override string Execute()
        {
            var unit = this.Data[1]; 
            this.Repository.RemoveUnit(unit);
            return unit + " retired!"; 
        }
    }
}