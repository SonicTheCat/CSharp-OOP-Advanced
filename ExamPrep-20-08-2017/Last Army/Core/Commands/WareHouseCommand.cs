public class WareHouseCommand : Command
{
    public WareHouseCommand(string[] data, IWareHouse wareHouse)
        : base(data)
    {
        this.WareHouse = wareHouse;
    }

    [Inject]
    public IWareHouse WareHouse { get; }

    public override void Execute()
    {
        var type = this.Data[0];
        var amount = int.Parse(this.Data[1]);
        this.WareHouse.AddAmmunitions(type, amount);
    }
}