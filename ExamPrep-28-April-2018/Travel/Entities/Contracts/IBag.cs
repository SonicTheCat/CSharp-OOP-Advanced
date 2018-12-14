namespace Travel.Entities.Contracts
{
	using System.Collections.Generic;
	using Travel.Entities.Items.Contracts;

	public interface IBag
	{
		IPassenger Owner { get; }

		IReadOnlyCollection<IItem> Items { get; }
	}
}