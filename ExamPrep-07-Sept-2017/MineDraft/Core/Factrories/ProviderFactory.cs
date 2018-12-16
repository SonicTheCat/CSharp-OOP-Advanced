using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    private const string SuffixProvider = "Provider";

    public IProvider GenerateProvider(IList<string> args)
    {
        string type = args[0];
        int id = int.Parse(args[1]);
        double energyOutput = double.Parse(args[2]);

        Type model = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == type + SuffixProvider);

        return (IProvider)Activator.CreateInstance(model, new object[] { id, energyOutput }); 
    }
}