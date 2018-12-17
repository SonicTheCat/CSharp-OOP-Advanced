using TheTankGame.Entities.Vehicles.Contracts;

namespace TheTankGame.Entities.Vehicles.Factories.Contracts
{
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints);
    }
}