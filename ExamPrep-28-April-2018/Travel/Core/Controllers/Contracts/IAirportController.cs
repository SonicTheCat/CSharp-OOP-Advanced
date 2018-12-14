namespace Travel.Core.Controllers.Contracts
{
	using System.Collections.Generic;

	public interface IAirportController
	{
		string RegisterPassenger(string username);

		string RegisterBag(string username, IEnumerable<string> bagItems);

		string RegisterTrip(string source, string destination, string planeType);

		string CheckIn(string username, string tripId, IEnumerable<int> bagIndices);
	}
}