namespace InfernoInfinity.Models.Gems
{
    using InfernoInfinity.Enums;

    public class Amethyst : Gem
    {
        private const int strength = 2;
        private const int agility = 8;
        private const int vitality = 4;

        public Amethyst(Clarity clarity)
            : base(strength, agility, vitality, clarity)
        {
        }
    }
}