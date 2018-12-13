using System;
using Microsoft.Extensions.DependencyInjection;

public class LastArmyMain
{
    static void Main()
    {
        IServiceProvider serviceProvider = ConfigureServices();
        IGameController gameController = new GameController(serviceProvider);
        IEngine engine = new Engine(gameController);

        engine.Run(); 
    }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddTransient<IWriter, ConsoleWriter>();
        services.AddTransient<IReader, ConsoleReader>(); 
        services.AddTransient<ISoldierFactory, SoldierFactory>(); 
        services.AddTransient<IAmmunitionFactory, AmmunitionFactory>(); 
        services.AddTransient<IMissionFactory, MissionFactory>();

        IArmy army = new Army();
        IWareHouse wareHouse = new WareHouse();
        IMissionController mission = new MissionController(army, wareHouse);

        services.AddSingleton(army); 
        services.AddSingleton(wareHouse); 
        services.AddSingleton(mission);

        return services.BuildServiceProvider();        
    }
}