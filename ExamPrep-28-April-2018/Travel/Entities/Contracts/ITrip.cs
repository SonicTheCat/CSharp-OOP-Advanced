namespace Travel.Entities.Contracts
{
	using Airplanes.Contracts;

	public interface ITrip
	{
		string Id { get; }

		string Source { get; }

		string Destination { get; }

		bool IsCompleted { get; }

		IAirplane Airplane { get; }

		void Complete();
	}
}