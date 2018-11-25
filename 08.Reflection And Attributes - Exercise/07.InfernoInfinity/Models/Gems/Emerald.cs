namespace InfernoInfinity.Models.Gems
{
    using InfernoInfinity.Enums;

    public class Emerald : Gem
    {
        private const int strength = 1;
        private const int agility = 4;
        private const int vitality = 9;

        public Emerald(Clarity clarity)
            : base(strength, agility, vitality, clarity)
        {
        }
    }
}