using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        var model = assembly.GetTypes().FirstOrDefault(x => x.Name == soldierTypeName);

        if (model == null)
        {
            throw new ArgumentException("Invalid type!");
        }

        if (!typeof(ISoldier).IsAssignableFrom(model))
        {
            throw new ArgumentException(model + " is not ISoldier type!");
        }

        var @params = new object[] { name, age, experience, endurance };
        return  (ISoldier)Activator.CreateInstance(model, @params); 
    }
}