namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Contracts;
	using Entities.Contracts;
	using Sets;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            var model = Assembly
                .GetCallingAssembly()   
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            if (model == null)
            {
                throw new ArgumentException("Invalid set type!");
            }

            if (!typeof(ISet).IsAssignableFrom(model))
            {
                throw new ArgumentException(type + " is not a Set Type!");
            }

            return (ISet)Activator.CreateInstance(model, new object[] { name });
		}
	}
}
