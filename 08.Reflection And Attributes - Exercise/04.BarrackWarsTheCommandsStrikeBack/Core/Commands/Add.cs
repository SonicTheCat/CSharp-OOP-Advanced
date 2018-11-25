using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class Add : Command
    {
        IUnit unit;
       // IRepository repository; 

        public Add(string[] data, IRepository repository, IUnitFactory factory) 
            : base(data, repository, factory)
        {
        }

        public override string Execute()
        {
            this.unit = base.UnitFactory.CreateUnit(base.Data[1]);
            this.Repository.AddUnit(this.unit);
            string output = base.Data[1] + " added!";
            return output;
        }
    }
}
