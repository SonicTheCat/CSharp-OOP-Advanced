namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Core.Attributes;

    public class Print : Command
    {
        public Print(string[] data, IRepository repository, IWriter writer)
            : base(data)
        {
            this.Repository = repository;
            this.Writer = writer; 
        }

        [Inject]
        public IRepository Repository { get; }

        [Inject]
        public IWriter Writer { get; }

        public override void Execute()
        {
            var name = this.Data[0];
            var weapon = this.Repository.GetWeapon(name);
            var result = this.Repository.PrintWeapon(weapon);
            Writer.WriteLine(result); 
        }
    }
}