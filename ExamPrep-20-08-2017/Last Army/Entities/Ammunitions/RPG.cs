public class RPG : Ammunition
{
    private const double DefaultWeight = 17.1;
    private const double DefaultWear = DefaultWeight * 100;

    public RPG(string name)
        : base(name, DefaultWeight, DefaultWear)
    {
    }
}