namespace InfernoInfinity.Core.Factories
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string type, string name, RarityLevel rarityLevel)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var model = assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            if (model == null)
            {
                throw new ArgumentException("Invalid type!"); 
            }

            if (!typeof(IWeapon).IsAssignableFrom(model))
            {
                throw new ArgumentException(model + " is not Weapon type!");
            }

            return (IWeapon)Activator.CreateInstance(model, new object[] { name, rarityLevel }); 
        }
    }
}