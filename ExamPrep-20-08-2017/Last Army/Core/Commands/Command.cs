public abstract class Command : IExecutable
{
    protected Command(string[] data)
    {
        this.Data = data;
    }

    public string[] Data { get; protected set; }

    public abstract void Execute();
}