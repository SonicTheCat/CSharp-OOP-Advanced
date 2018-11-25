using _03BarracksFactory.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    public class CommandFactory
    {
        public IExecutable CreateCommand(string[] data, IRepository repository, IUnitFactory factory)
        {
            var firstLetter = data[0][0].ToString().ToUpper();
            var type = firstLetter + string.Join("", data[0].Skip(1));

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            if (model == null)
            {
                throw new ArgumentException("Invalid Unit Type!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(model))
            {
                throw new ArgumentException(type + " is not a Unit Type!");
            }

            return (IExecutable)Activator.CreateInstance(model, new object[] { data, repository, factory });
        }
    }
}