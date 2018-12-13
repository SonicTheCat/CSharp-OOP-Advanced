public class AutomaticMachine : Ammunition
{
    private const double DefaultWeight = 6.3;
    private const double DefaultWear = DefaultWeight * 100;

    public AutomaticMachine(string name)
        : base(name, DefaultWeight, DefaultWear)
    {
    }
}