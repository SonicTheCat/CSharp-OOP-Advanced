namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Reflection;

    public class PerformerFactory : IPerformerFactory
    {
        public IPerformer CreatePerformer(string name, int age)
        {
            //var model = Assembly
            //    .GetCallingAssembly()
            //    .GetType("FestivalManager.Entities.Performer");

            //if (model == null)
            //{
            //    throw new ArgumentException("Performer Type Does Not Exist!");
            //}

            //return (IPerformer)Activator.CreateInstance(model, new object[] { name, age });

            var performer = new Performer(name, age);

            return performer;
        }
    }
}