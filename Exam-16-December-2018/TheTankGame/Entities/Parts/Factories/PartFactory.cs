using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Parts.Factories.Contracts;

namespace TheTankGame.Entities.Parts.Factories
{
    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type wantedType = assembly.GetTypes().FirstOrDefault(x => x.Name == partType + "Part");
     
            var @params = new object[] { model, weight, price, additionalParameter };
            var part = (IPart)Activator.CreateInstance(wantedType, @params);

            return part;
        }
    }
}
