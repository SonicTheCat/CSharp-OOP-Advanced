public class Knife : Ammunition
{
    private const double DefaultWeight = 0.4;
    private const double DefaultWear = DefaultWeight * 100;

    public Knife(string name)
        : base(name, DefaultWeight, DefaultWear)
    {
    }
}