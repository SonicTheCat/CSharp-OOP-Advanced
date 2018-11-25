namespace InfernoInfinity
{
    using System;
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Core;
    using InfernoInfinity.Core.Factories;
    using InfernoInfinity.Core.IO;
    using InfernoInfinity.Data;
    using Microsoft.Extensions.DependencyInjection;

    public class StartUp
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader(); 
            IRunable engine = new Engine(commandInterpreter, writer, reader);
            engine.Run(); 
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IWeaponFactory, WeaponFactory>();
            services.AddTransient<IGemFactory, GemFactory>();
            services.AddTransient<IWriter, ConsoleWriter>(); 
            services.AddSingleton<IRepository, WeaponRepository>();

            IServiceProvider provider = services.BuildServiceProvider();
            return provider; 
        }
    }
}