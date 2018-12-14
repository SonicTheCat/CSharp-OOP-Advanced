namespace Travel.Entities.Factories.Contracts
{
	using Items.Contracts;

	public interface IItemFactory
	{
		IItem CreateItem(string type);
	}
}