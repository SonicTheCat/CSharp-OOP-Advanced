using System;
using System.Collections.Generic;

public class DayCommand : Command
{
    private readonly IHarvesterController harvesterController;
    private readonly IProviderController providerController;

    public DayCommand(List<string> arguments, IHarvesterController hc, IProviderController pc)
         : base(arguments)
    {
        this.harvesterController = hc;
        this.providerController = pc;
    }

    public override string Execute()
    {
        var providerResult = this.providerController.Produce();
        var harvesterResult = this.harvesterController.Produce();

        return providerResult + Environment.NewLine + harvesterResult; 
    }
}