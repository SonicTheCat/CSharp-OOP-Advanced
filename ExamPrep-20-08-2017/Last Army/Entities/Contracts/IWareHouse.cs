using System.Collections.Generic;

public interface IWareHouse
{
    IReadOnlyDictionary<string,int> AvailableAmmunitions { get; }

    bool TryEquipSoldier(ISoldier soldier);

    void AddAmmunitions(string type, int amount);

    void EquipArmy(IArmy army); 
}