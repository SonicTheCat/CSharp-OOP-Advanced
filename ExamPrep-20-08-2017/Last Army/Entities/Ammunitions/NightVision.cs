public class NightVision : Ammunition
{
    private const double DefaultWeight = 0.8;
    private const double DefaultWear = DefaultWeight * 100;

    public NightVision(string name)
        : base(name, DefaultWeight, DefaultWear)
    {
    }
}