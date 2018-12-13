using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string type)
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        var model = assembly.GetTypes().FirstOrDefault(x => x.Name == type);

        if (model == null)
        {
            throw new ArgumentException("Invalid type!");
        }

        if (!typeof(IAmmunition).IsAssignableFrom(model))
        {
            throw new ArgumentException(model + " is not IAmmunition type!");
        }

        return (IAmmunition)Activator.CreateInstance(model, new object[] { type });
    }
}