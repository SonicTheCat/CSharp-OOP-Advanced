namespace InfernoInfinity.Core
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Core.Attributes;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider provider)
        {
            this.serviceProvider = provider;
        }

        public IExecutable InterpretCommand(string[] data)
        {
            var commandType = data[0];
            data = data.Skip(1).ToArray();

            Assembly assembly = Assembly.GetExecutingAssembly();
            var model = assembly.GetTypes().FirstOrDefault(x => x.Name == commandType);

            if (model == null)
            {
                throw new ArgumentException("Invalid type!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(model))
            {
                throw new ArgumentException(model + " is not Weapon type!");
            }

            PropertyInfo[] propertiesToInject = model
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttributes<InjectAttribute>().Any()).ToArray();

            var injectProps = propertiesToInject
                .Select(p => serviceProvider.GetService(p.PropertyType))
                .ToArray();

            var joinedParams = new object[] { data }.Concat(injectProps).ToArray();

            IExecutable command = (IExecutable)Activator.CreateInstance(model, joinedParams);
            return command; 
        }
    }
}