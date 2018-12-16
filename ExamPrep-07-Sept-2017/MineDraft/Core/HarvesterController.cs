using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private readonly List<IHarvester> harvesters;
    private readonly IHarvesterFactory harvesterFactory;
    private readonly IEnergyRepository energyRepository;
    private WorkMode workMode;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.harvesters = new List<IHarvester>();
        this.harvesterFactory = new HarvesterFactory();
        this.workMode = WorkMode.Full;
        this.energyRepository = energyRepository;
    }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public double OreProduced { get; private set; }

    public string ChangeMode(string mode)
    {
        var isValid = Enum.TryParse(mode, out WorkMode newMode);

        if (isValid)
        {
            this.workMode = newMode;
        }
        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception ex)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ChangedMode, mode);
    }

    public string Produce()
    {
        var requiredEnergy = this.harvesters.Sum(x => x.EnergyRequirement) * ((int)this.workMode / 100.0);
        var collectedOre = 0d;

        if (this.energyRepository.TakeEnergy(requiredEnergy))
        {
            collectedOre = this.harvesters.Sum(x => x.Produce()) * ((int)this.workMode / 100.0);
            this.OreProduced += collectedOre;
        }

        return String.Format(Constants.OreOutputToday, collectedOre);
    }

    public string Register(IList<string> args)
    {
        var type = args[0];
        var harvester = this.harvesterFactory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }
}
