using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string Suffix = "Command";

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
    {
        var commandType = args[0] + Suffix;

        var model = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == commandType);

        if (model == null)
        {
            throw new ArgumentException(Constants.InvalidType);
        }

        if (!typeof(ICommand).IsAssignableFrom(model))
        {
            throw new ArgumentException(string.Format(Constants.NotAssignableFrom, model, typeof(ICommand)));
        }

        ConstructorInfo ctor = model.GetConstructors().First();
        ParameterInfo[] parameterInfos = ctor.GetParameters();
        object[] @params = new object[parameterInfos.Length];

        for (int i = 0; i < @params.Length; i++)
        {
            Type wantedType = parameterInfos[i].ParameterType;

            if (wantedType == typeof(List<string>))
            {
                @params[i] = args.Skip(1).ToList();
            }
            else
            {
                PropertyInfo property = this
                    .GetType()
                    .GetProperties()
                    .FirstOrDefault(x => x.PropertyType == wantedType);

                @params[i] = property.GetValue(this);
            }
        }

        var command = (ICommand)Activator.CreateInstance(model, @params);

        var result = command.Execute();
        return result;
    }
}