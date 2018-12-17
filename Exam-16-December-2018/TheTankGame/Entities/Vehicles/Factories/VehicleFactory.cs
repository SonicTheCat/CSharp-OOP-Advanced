using System;
using System.Linq;
using System.Reflection;
using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Vehicles.Factories.Contracts;

namespace TheTankGame.Entities.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type wantedType = assembly.GetTypes().FirstOrDefault(x => x.Name == vehicleType);

            var @params = new object[] { model, weight, price, attack, defense, hitPoints, new VehicleAssembler()};
            var vehicle = (IVehicle)Activator.CreateInstance(wantedType, @params);

            return vehicle; 
        }
    }
}