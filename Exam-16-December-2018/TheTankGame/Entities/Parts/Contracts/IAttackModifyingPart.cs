namespace TheTankGame.Entities.Parts.Contracts
{
    public interface IAttackModifyingPart : IPart
    {
        int AttackModifier { get; }
    }
}