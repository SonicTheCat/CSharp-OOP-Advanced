namespace Travel.Entities.Factories
{
    using Contracts;
    using Items;
    using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
    {
        public IItem CreateItem(string type)
        {
            Type model = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            if (model == null)
            {
                throw new ArgumentException("Invalid type!");
            }

            if (!typeof(IItem).IsAssignableFrom(model))
            {
                throw new ArgumentException(model + " is not IItem type!");
            }

            return (IItem)Activator.CreateInstance(model);
        }
    }
}
