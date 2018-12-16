using System.Collections.Generic;

public class RepairCommand : Command
{
    private readonly IProviderController providerController;

    public RepairCommand(List<string> arguments, IProviderController providerController)
        : base(arguments)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var value = double.Parse(this.Arguments[0]);

        var result = this.providerController.Repair(value);

        return result;
    }
}