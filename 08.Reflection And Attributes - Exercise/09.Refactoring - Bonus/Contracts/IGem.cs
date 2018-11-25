using InfernoInfinity.Enums;

namespace InfernoInfinity.Contracts
{
    public interface IGem
    {
        int Strength { get; }

        int Agility { get; }

        int Vitality { get; }

        Clarity Clarity { get; }
    }
}
