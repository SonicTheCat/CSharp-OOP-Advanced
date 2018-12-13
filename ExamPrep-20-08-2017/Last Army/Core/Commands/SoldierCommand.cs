using System;

public class SoldierCommand : Command
{
    private const string RegenerateString = "Regenerate";

    public SoldierCommand(string[] data, IArmy army, IWareHouse wareHouse, ISoldierFactory factory)
        : base(data)
    {
        this.Army = army;
        this.WareHouse = wareHouse;
        this.SoldierFactory = factory;
    }

    [Inject]
    public IArmy Army { get; }

    [Inject]
    public IWareHouse WareHouse { get; }

    [Inject]
    public ISoldierFactory SoldierFactory { get; }

    public override void Execute()
    {
        var command = this.Data[0];

        if (command != RegenerateString)
        {
            this.CreateSoldier(this.Data);
        }
        else
        {
            this.Army.RegenerateTeam(this.Data[1]);
        }
    }

    private void CreateSoldier(string[] tokens)
    {
        var type = tokens[0];
        var name = tokens[1];
        var age = int.Parse(tokens[2]);
        var experience = double.Parse(tokens[3]);
        var endurance = double.Parse(tokens[4]);
        var soldier = this.SoldierFactory.CreateSoldier(type, name, age, experience, endurance);

        if (this.WareHouse.TryEquipSoldier(soldier))
        {
            this.Army.AddSoldier(soldier);
        }
        else
        {
            throw new ArgumentException(string.Format(OutputMessages.NoWeaponsForSoldierType, type, name));
        }
    }
}