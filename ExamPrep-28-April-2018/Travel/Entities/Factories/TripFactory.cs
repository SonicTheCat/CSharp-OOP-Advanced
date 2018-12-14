using Travel.Entities.Airplanes.Contracts;
using Travel.Entities.Contracts;
using Travel.Entities.Factories.Contracts;

namespace Travel.Entities.Factories
{
    public class TripFactory : ITripFactory
    {
        public ITrip CreateTrip(string source, string destination, IAirplane airplane)
        {
            return new Trip(source, destination, airplane); 
        }
    }
}
