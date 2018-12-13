public class Gun : Ammunition
{
    private const double DefaultWeight = 1.4;
    private const double DefaultWear = DefaultWeight * 100;

    public Gun(string name)
        : base(name, DefaultWeight, DefaultWear)
    {
    }
}