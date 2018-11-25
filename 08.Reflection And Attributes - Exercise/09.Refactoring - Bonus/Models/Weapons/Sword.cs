namespace InfernoInfinity.Models.Weapons
{
    using InfernoInfinity.Enums;

    public class Sword : Weapon
    {
        private const int minDemage = 4;
        private const int maxDemage = 6;
        private const int countOfSockets = 3;

        public Sword(string name, RarityLevel rarity) 
            : base(name, minDemage, maxDemage, countOfSockets, rarity)
        {
        }
    }
}