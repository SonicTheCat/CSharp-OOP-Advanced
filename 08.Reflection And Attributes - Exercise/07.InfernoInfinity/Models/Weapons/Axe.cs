namespace InfernoInfinity.Models.Weapons
{
    using InfernoInfinity.Enums;

    public class Axe : Weapon
    {
        private const int minDemage = 5;
        private const int maxDemage = 10;
        private const int countOfSockets = 4;

        public Axe(string name, RarityLevel rarity)
            : base(name, minDemage, maxDemage, countOfSockets, rarity)
        {
        }
    }
}