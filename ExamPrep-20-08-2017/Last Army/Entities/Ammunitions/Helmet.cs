public class Helmet : Ammunition
{
    private const double DefaultWeight = 2.3;
    private const double DefaultWear = DefaultWeight * 100;

    public Helmet(string name)
        : base(name, DefaultWeight, DefaultWear)
    {
    }
}