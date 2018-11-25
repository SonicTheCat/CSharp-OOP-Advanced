namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Contracts;

    public abstract class Command : IExecutable
    {
        public Command(string[] data)
        {
            this.Data = data;
        }

        public string[] Data { get; protected set; }

        public abstract void Execute();
    }
}