namespace TheTankGame.Entities.Parts
{
    using Contracts;

    public class EndurancePart : Part, IHitPointsModifyingPart
    {
        public EndurancePart(string model, double weight, decimal price, int hitPointsModifier)
            : base(model, weight, price)
        {
            this.HitPointsModifier = hitPointsModifier;
        }

        public int HitPointsModifier { get; private set; }
    }
}