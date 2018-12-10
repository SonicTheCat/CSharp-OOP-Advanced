using CurstomFrameworkDI.Modules.Contracts;

namespace CurstomFrameworkDI.Modules
{
    public class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module); 
        }
    }
}
