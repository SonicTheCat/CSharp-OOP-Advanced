using System.Collections.Generic;
using Travel.Entities.Contracts;

namespace Travel.Entities.Airplanes.Contracts
{
	public interface IAirplane
	{
		int BaggageCompartments { get; }

		IReadOnlyCollection<IBag> BaggageCompartment { get; }

		bool IsOverbooked { get; }

		IReadOnlyCollection<IPassenger> Passengers { get; }

		int Seats { get; }

		void AddPassenger(IPassenger passenger);

		IPassenger RemovePassenger(int seat);

		IEnumerable<IBag> EjectPassengerBags(IPassenger passenger);

		void LoadBag(IBag bag);
	}
}