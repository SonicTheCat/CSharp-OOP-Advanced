namespace InfernoInfinity.Models.Weapons
{
    using System.Collections.Generic;
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Enums;
    using InfernoInfinity.Models.Gems;
    using System.Linq;

    public abstract class Weapon : IWeapon
    {
        private int minDemage;
        private int maxDemage;
        private IGem[] sockets;

        protected Weapon(string name, int minDemage, int maxDemage, int countOfSockets, RarityLevel rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.MinDemage = minDemage;
            this.MaxDemage = maxDemage;
            this.sockets = new Gem[countOfSockets];
        }

        public string Name { get; }

        public int MinDemage
        {
            get
            {
                return this.minDemage;
            }
            private set
            {
                this.minDemage = value * (int)this.Rarity;
            }
        }

        public int MaxDemage
        {
            get
            {
                return this.maxDemage;
            }
            private set
            {
                this.maxDemage = value * (int)this.Rarity;
            }
        }

        public RarityLevel Rarity { get; }

        public IReadOnlyCollection<IGem> Sockets => this.sockets;

        public void AddGem(IGem gem, int index)
        {
            if (index < 0 || index >= this.sockets.Length)
            {
                return;
            }

            this.sockets[index] = gem;
            IncreaseDemageValuesByGem(gem);
        }

        public void RemoveGem(int index)
        {
            if (index < 0 || index >= this.sockets.Length)
            {
                return;
            }

            var gemToRemove = this.sockets[index];
            this.sockets[index] = null;
            DecreaseDemageValuesByGem(gemToRemove);
        }

        private void IncreaseDemageValuesByGem(IGem gem)
        {
            this.minDemage += gem.Strength * 2;
            this.maxDemage += gem.Strength * 3;

            this.minDemage += gem.Agility;
            this.maxDemage += gem.Agility * 4;
        }

        private void DecreaseDemageValuesByGem(IGem gem)
        {
            this.minDemage -= gem.Strength * 2;
            this.maxDemage -= gem.Strength * 3;

            this.minDemage -= gem.Agility;
            this.maxDemage -= gem.Agility * 4;
        }

        public override string ToString()
        {
            var strenght = this.Sockets.Where(x => x != null).Sum(x => x.Strength); 
            var agility = this.Sockets.Where(x => x != null).Sum(x => x.Agility); 
            var vitality = this.Sockets.Where(x => x != null).Sum(x => x.Vitality); 

           return $"{this.Name}: {this.MinDemage}-{this.MaxDemage} Damage, +{strenght} Strength, +{agility} " +
                $"Agility, +{vitality} Vitality"; 
        }
    }
}