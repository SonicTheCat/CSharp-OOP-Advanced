namespace InfernoInfinity.Models.Weapons
{
    using InfernoInfinity.Enums;

    public class Knife : Weapon
    {
        private const int minDemage = 3;
        private const int maxDemage = 4;
        private const int countOfSockets = 2;

        public Knife(string name, RarityLevel rarity) 
            : base(name, minDemage, maxDemage, countOfSockets, rarity)
        {
        }
    }
}