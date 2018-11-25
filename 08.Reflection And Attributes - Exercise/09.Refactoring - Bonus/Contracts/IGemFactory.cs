using InfernoInfinity.Enums;

namespace InfernoInfinity.Contracts
{
    public interface IGemFactory
    {
        IGem CreateGem(string type, Clarity clarity); 
    }
}
