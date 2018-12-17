using TheTankGame.Entities.CommonContracts;

namespace TheTankGame.Entities.Parts.Contracts
{
    public interface IPart : IModelable
    {
        double Weight { get; }

        decimal Price { get; }
    }
}