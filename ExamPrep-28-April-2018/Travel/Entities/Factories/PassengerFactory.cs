using Travel.Entities.Contracts;
using Travel.Entities.Factories.Contracts;

namespace Travel.Entities.Factories
{
   public class PassengerFactory : IPassengerFactory
    {
        public IPassenger CreatePassenger(string username)
        {
            return new Passenger(username); 
        }
    }
}
