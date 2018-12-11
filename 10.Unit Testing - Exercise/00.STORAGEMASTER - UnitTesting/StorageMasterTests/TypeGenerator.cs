namespace StorageMasterTests
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class TypeGenerator
    {
        private static readonly Assembly ProjectAssembly = typeof(StorageMaster.StartUp).Assembly;

        public static Type GetType(string name)
        {
            var type = ProjectAssembly
               .GetTypes()
               .FirstOrDefault(x => x.Name == name);

            return type;
        }
    }
}