public class MachineGun : Ammunition
{
    private const double DefaultWeight = 10.6;
    private const double DefaultWear = DefaultWeight * 100;

    public MachineGun(string name)
        : base(name, DefaultWeight, DefaultWear)
    {
    }
}