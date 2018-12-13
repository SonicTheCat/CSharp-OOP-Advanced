using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        var model = assembly.GetTypes().FirstOrDefault(x => x.Name == difficultyLevel);

        if (model == null)
        {
            throw new ArgumentException("Invalid type!");
        }

        if (!typeof(IMission).IsAssignableFrom(model))
        {
            throw new ArgumentException(model + " is not IMission type!");
        }

        return (IMission)Activator.CreateInstance(model, new object[] { neededPoints }); 
    }
}