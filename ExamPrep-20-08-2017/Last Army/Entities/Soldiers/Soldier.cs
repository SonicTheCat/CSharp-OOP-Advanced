using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private readonly double skillMultiplier;

    protected Soldier(string name, int age, double experience, double endurance, double skillMultiplier)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.skillMultiplier = skillMultiplier;
        this.Weapons = this.IntializeWeapons();
    }

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    public double Endurance { get; private set; }

    public double OverallSkill => (this.Age + this.Experience) * this.skillMultiplier;

    public IDictionary<string, IAmmunition> Weapons { get; }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    protected abstract int RegenerateValue { get; }

    private Dictionary<string, IAmmunition> IntializeWeapons()
    {
        var helperDictionary = new Dictionary<string, IAmmunition>();

        foreach (var weapon in this.WeaponsAllowed)
        {
            helperDictionary.Add(weapon, null);
        }

        return helperDictionary;
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public void CompleteMission(IMission mission)
    {
        this.Endurance -= mission.EnduranceRequired;
        this.Experience += mission.EnduranceRequired;

        this.AmmunitionRevision(mission.WearLevelDecrement);
    }

    public void Regenerate()
    {
        this.Endurance += this.RegenerateValue + this.Age;
        if (this.Endurance > 100)
        {
            this.Endurance = 100;
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}