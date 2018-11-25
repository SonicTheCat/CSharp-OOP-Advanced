namespace InfernoInfinity.Core.Factories
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string type, Clarity clarity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var model = assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            if (model == null)
            {
                throw new ArgumentException("Invalid type!");
            }

            if (!typeof(IGem).IsAssignableFrom(model))
            {
                throw new ArgumentException(model + " is not Weapon type!");
            }

            return (IGem)Activator.CreateInstance(model, new object[] { clarity }); 
        }
    }
}