using System.Collections.Generic;

public abstract class Command : ICommand
{
    public IList<string> Arguments { get; }

    protected Command(List<string> arguments)
    {
        this.Arguments = arguments;
    }

    public abstract string Execute();
}