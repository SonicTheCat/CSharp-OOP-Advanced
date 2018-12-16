using System;
using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    private readonly IHarvesterController harvesterController;
    private readonly IProviderController providerController;

    public ShutdownCommand(List<string> arguments, IHarvesterController hc, IProviderController pc)
         : base(arguments)
    {
        this.harvesterController = hc;
        this.providerController = pc;
    }

    public override string Execute()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(Constants.SystemShutDowned);
        sb.AppendLine(string.Format(Constants.EnergyStored, this.providerController.TotalEnergyProduced));
        sb.AppendLine(string.Format(Constants.TotalMinedOre, this.harvesterController.OreProduced));

        return sb.ToString().Trim();
    }
}