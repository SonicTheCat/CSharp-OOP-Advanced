namespace TheTankGame.Entities.Parts.Contracts
{
    public interface IDefenseModifyingPart : IPart
    {
        int DefenseModifier { get; }
    }
}