using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private readonly IHarvesterController harvesterController;
    private readonly IProviderController providerController;

    public RegisterCommand(List<string> arguments, IHarvesterController hc, IProviderController pc)
         : base(arguments)
    {
        this.harvesterController = hc;
        this.providerController = pc;
    }

    public override string Execute()
    {
        string result = null;
        if (this.Arguments[0] == nameof(Harvester))
        {
            result += this.harvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        else if (this.Arguments[0] == nameof(Provider))
        {
            result += this.providerController.Register(this.Arguments.Skip(1).ToList());
        }
        return result;
    }
}