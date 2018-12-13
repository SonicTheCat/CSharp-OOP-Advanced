using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double OverallSkillMiltiplier = 3.5;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            nameof(Gun),
            nameof(AutomaticMachine),
            nameof(MachineGun),
            nameof(RPG),
            nameof(Helmet),
            nameof(Knife),
            nameof(NightVision)
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance, OverallSkillMiltiplier)
    { 
    }

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed.AsReadOnly();

    protected override int RegenerateValue => 30;
}