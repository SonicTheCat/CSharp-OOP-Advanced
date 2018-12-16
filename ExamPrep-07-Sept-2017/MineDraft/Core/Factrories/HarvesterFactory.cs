using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    private const string SuffixHarvester = "Harvester"; 

    public IHarvester GenerateHarvester(IList<string> args)
    {
        string type = args[0];

        var id = int.Parse(args[1]);
        var oreOutput = double.Parse(args[2]);
        var energyReq = double.Parse(args[3]);

        Type model = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == type + SuffixHarvester);

        return (IHarvester)Activator.CreateInstance(model, new object[] { id, oreOutput, energyReq });
    }
}