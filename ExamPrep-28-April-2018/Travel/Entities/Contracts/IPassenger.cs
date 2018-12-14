namespace Travel.Entities.Contracts
{
	using System.Collections.Generic;

	public interface IPassenger
	{
		string Username { get; }

		IList<IBag> Bags { get; }
	}
}