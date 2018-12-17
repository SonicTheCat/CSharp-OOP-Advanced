using TheTankGame.Entities.Parts.Contracts;

namespace TheTankGame.Entities.Parts.Factories.Contracts
{
    public interface IPartFactory
    {
        IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter);
    }
}