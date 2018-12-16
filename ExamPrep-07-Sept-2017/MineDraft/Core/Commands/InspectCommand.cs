using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    private readonly IHarvesterController harvesterController;
    private readonly IProviderController providerController;

    public InspectCommand(List<string> arguments, IHarvesterController hc, IProviderController pc)
         : base(arguments)
    {
        this.harvesterController = hc;
        this.providerController = pc;
    }

    public override string Execute()
    {
        var wantedId = int.Parse(this.Arguments[0]);

        var element =
            this.harvesterController.Entities.FirstOrDefault(x => x.ID == wantedId)
            ??
            this.providerController.Entities.FirstOrDefault(x => x.ID == wantedId);

        if (element != null)
        {
            return string.Format(Constants.InspectedType, element.GetType().Name, element.Durability);
        }

        return string.Format(Constants.NoEntityFoud, wantedId);
    }
}