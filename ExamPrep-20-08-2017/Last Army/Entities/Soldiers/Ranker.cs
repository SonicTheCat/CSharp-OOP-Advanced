using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallSkillMiltiplier = 1.5;

    private readonly List<string> weaponsAllowed = new List<string>
    {
            nameof(Gun),nameof(AutomaticMachine),nameof(Helmet)
    };

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance, OverallSkillMiltiplier)
    {      
    }

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed.AsReadOnly();

    protected override int RegenerateValue => 10;
}