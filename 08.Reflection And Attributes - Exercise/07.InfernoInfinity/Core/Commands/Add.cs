namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Core.Attributes;
    using InfernoInfinity.Enums;
    using System;

    public class Add : Command
    {
        public Add(string[] data, IRepository repository, IGemFactory gemFactory)
            : base(data)
        {
            this.Repository = repository;
            this.GemFactory = gemFactory;
        }

        [Inject]
        public IRepository Repository { get; }

        [Inject]
        public IGemFactory GemFactory { get; }

        public override void Execute()
        {
            var name = this.Data[0];
            var index = int.Parse(this.Data[1]);
            var split = this.Data[2].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Clarity clarity = (Clarity)Enum.Parse(typeof(Clarity), split[0]);
            var gem = this.GemFactory.CreateGem(split[1], clarity);
            var weapon = this.Repository.GetWeapon(name);
            weapon.AddGem(gem, index);
        }
    }
}