using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Factories;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;
        private CommandFactory factory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
            this.factory = new CommandFactory(); 
        }

        public IExecutable InterpretCommand(string[] data)
        {
            return factory.CreateCommand(data, this.repository, this.unitFactory); 
        }
    }
}