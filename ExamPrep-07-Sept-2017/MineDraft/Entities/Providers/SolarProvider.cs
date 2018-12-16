public class SolarProvider : Provider
{
    private const double DurabilityIncreaser = 500; 

    public SolarProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.Durability += DurabilityIncreaser; 
    }
}