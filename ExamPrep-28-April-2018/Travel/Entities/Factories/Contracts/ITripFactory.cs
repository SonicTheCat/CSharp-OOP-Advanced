using Travel.Entities.Airplanes.Contracts;
using Travel.Entities.Contracts;

namespace Travel.Entities.Factories.Contracts
{
    public interface ITripFactory
    {
        ITrip CreateTrip(string source, string destination, IAirplane airplane); 
    }
}
