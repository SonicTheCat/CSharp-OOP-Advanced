using InfernoInfinity.Contracts;
using InfernoInfinity.Core.Attributes;

namespace InfernoInfinity.Core.Commands
{
    public class Remove : Command
    {
        public Remove(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }

        [Inject]
        public IRepository Repository { get; }

        public override void Execute()
        {
            var name = this.Data[0];
            var index = int.Parse(this.Data[1]);
            var weapon = this.Repository.GetWeapon(name);
            weapon.RemoveGem(index); 
        }
    }
}