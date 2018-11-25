namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Enums;
    using InfernoInfinity.Core.Attributes;
    using System;

    public class Create : Command
    {
        public Create(string[] data, IRepository repository, IWeaponFactory weaponFactory)
            : base(data)
        {
            this.Repository = repository;
            this.WeaponFactory = weaponFactory;
        }

        [Inject]
        public IRepository Repository { get; }

        [Inject]
        public IWeaponFactory WeaponFactory { get; }

        public override void Execute()
        {
            var split = this.Data[0].ToString().Split();
            var type = split[1];
            RarityLevel rarityLevel = (RarityLevel)Enum.Parse(typeof(RarityLevel), split[0]);
            string name = this.Data[1].ToString();
            var weapon = this.WeaponFactory.CreateWeapon(type, name, rarityLevel);
            this.Repository.AddWeapon(weapon);
        }
    }
}