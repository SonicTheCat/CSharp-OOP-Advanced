namespace Travel.Entities
{
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	using Items.Contracts;

	/* 1/3
	 * A heart that's full up like a landfill
	 * A job that slowly kills you
	 * Bruises that won't heal...
	 */
	public class Bag : IBag
	{
		private readonly List<IItem> items;

		public Bag(IPassenger owner, IEnumerable<IItem> items)
		{
			this.Owner = owner;
			this.items = items.ToList();
		}

		public IPassenger Owner { get; }

		public IReadOnlyCollection<IItem> Items => this.items.AsReadOnly();
	}
}