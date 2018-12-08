namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            var assembly = Assembly.GetCallingAssembly();

            var model = assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            if (model == null)
            {
                throw new ArgumentException("Invalid Instrument type!");
            }

            if (!typeof(IInstrument).IsAssignableFrom(model))
            {
                throw new ArgumentException(type + " is not a Instrument Type!");
            }

            return (IInstrument)Activator.CreateInstance(model, new object[] { }); 
		}
	}
}