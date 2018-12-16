using NUnit.Framework;
using System.Collections.Generic;

public class MinedraftTest
{
    private IEnergyRepository energyRepository;
    private ProviderController providerController;

    [SetUp]
    public void SetUpBeforeEach()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(this.energyRepository);
    }

    [Test]
    public void Test1()
    {
        this.providerController.Register(new List<string> { "Pressure", "1", "100" });
        this.providerController.Register(new List<string> { "Solar", "6", "100" });

        for (int i = 0; i < 2; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(600));
    }

    [Test]
    public void Test2()
    {
        this.providerController.Register(new List<string> { "Standart", "1", "100" });
        this.providerController.Register(new List<string> { "Solar", "6", "100" });

        for (int i = 0; i < 11; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.Entities.Count, Is.EqualTo(1)); 
    }
}