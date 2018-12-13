using System;
using System.Linq;
using System.Reflection;

public class GameController : IGameController
{
    private const string Suffix = "Command";

    private readonly IServiceProvider serviceProvider;

    public GameController(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IExecutable ParseCommand(string[] data)
    {
        var commandType = data[0] + Suffix;
        data = data.Skip(1).ToArray();

        var model = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == commandType);

        if (model == null)
        {
            throw new ArgumentException("Invalid type!");
        }

        if (!typeof(IExecutable).IsAssignableFrom(model))
        {
            throw new ArgumentException(model + " is not IExecutable type!");
        }

        var propsToInject = model
              .GetProperties(BindingFlags.Public | BindingFlags.Instance)
              .Where(x => x.GetCustomAttributes<InjectAttribute>().Any())
              .ToArray();

        var inject = propsToInject
            .Select(p => this.serviceProvider.GetService(p.PropertyType))
            .ToArray();

        var @params = new object[] { data }.Concat(inject).ToArray();

        IExecutable command = (IExecutable)Activator.CreateInstance(model, @params);
        return command;
    }
}