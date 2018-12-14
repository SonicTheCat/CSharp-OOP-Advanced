using Travel.Entities.Contracts;

namespace Travel.Entities.Factories.Contracts
{
    public interface IPassengerFactory
    {
        IPassenger CreatePassenger(string username);
    }
}
