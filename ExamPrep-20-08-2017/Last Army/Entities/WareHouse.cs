using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private readonly Dictionary<string, int> availableAmmunitions;
    private readonly IAmmunitionFactory ammunitionFactory; 

    public WareHouse()
    {
        this.availableAmmunitions = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory(); 
    }

    public IReadOnlyDictionary<string, int> AvailableAmmunitions => this.availableAmmunitions;

    public void AddAmmunitions(string type, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (!this.AvailableAmmunitions.ContainsKey(type))
            {
                this.availableAmmunitions[type] = 0;
            }
            this.availableAmmunitions[type]++; 
        }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier); 
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        var hasAll = true;

        var missingWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToArray();

        foreach (var weapon in missingWeapons)
        {
            if (this.AvailableAmmunitions.ContainsKey(weapon) && this.AvailableAmmunitions[weapon] > 0)
            {
                soldier.Weapons[weapon] = this.ammunitionFactory.CreateAmmunition(weapon);
                this.availableAmmunitions[weapon]--;
            }
            else
            {
                hasAll = false;
            }
        }
        return hasAll; 
    }
}