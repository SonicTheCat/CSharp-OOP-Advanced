namespace Travel.Entities.Factories
{
    using Contracts;
    using Airplanes.Contracts;
    using System.Reflection;
    using System;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
    {
        public IAirplane CreateAirplane(string type)
        {
            Type model = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            if (model == null)
            {
                throw new ArgumentException("Invalid type!");
            }

            if (!typeof(IAirplane).IsAssignableFrom(model))
            {
                throw new ArgumentException(model + " is not IAirplane type!");
            }

            return (IAirplane)Activator.CreateInstance(model);
        }
    }
}