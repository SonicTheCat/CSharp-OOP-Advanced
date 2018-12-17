namespace TheTankGame.Entities.Parts
{
    using Contracts;

    public class ShellPart : Part, IDefenseModifyingPart
    {
        public ShellPart(string model, double weight, decimal price, int defenseModifier)
            : base(model, weight, price)
        {
            this.DefenseModifier = defenseModifier;
        }

        public int DefenseModifier { get; private set; }
    }
}