using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Commands;
using System;
using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    public class CommandFactory
    {
        public IExecutable CreateCommand(string[] data, IServiceProvider serviceProvider)
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

            PropertyInfo[] propsToInject = model
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
                .ToArray();

            object[] injectArgs = propsToInject
                .Select(x => serviceProvider.GetService(x.PropertyType))
                .ToArray();

            var arguments = new object[] { data }.Concat(injectArgs).ToArray(); 

            return (IExecutable)Activator.CreateInstance(model, arguments);
        }
    }
}