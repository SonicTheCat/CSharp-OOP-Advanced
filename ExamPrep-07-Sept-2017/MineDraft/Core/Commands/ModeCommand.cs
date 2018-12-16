using System.Collections.Generic;

public class ModeCommand : Command
{
    private readonly IHarvesterController harvesterController;
  
    public ModeCommand(List<string> arguments, IHarvesterController hc)
         : base(arguments)
    {
        this.harvesterController = hc;
    }

    public override string Execute()
    {
        var result = this.harvesterController.ChangeMode(this.Arguments[0]);
        return result; 
    }
}