using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double OverallSkillMiltiplier = 2.5;

    private readonly List<string> weaponsAllowed = new List<string>
        {
           nameof(Gun),nameof(AutomaticMachine),nameof(MachineGun),nameof(Helmet),nameof(Knife)
        };

    public Corporal(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance, OverallSkillMiltiplier)
    {
       
    }

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed.AsReadOnly();

    protected override int RegenerateValue => 10;
}