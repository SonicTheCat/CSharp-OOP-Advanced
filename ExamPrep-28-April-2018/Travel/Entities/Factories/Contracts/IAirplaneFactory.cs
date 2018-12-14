namespace Travel.Entities.Factories.Contracts
{
	using Airplanes.Contracts;

	public interface IAirplaneFactory
	{
		IAirplane CreateAirplane(string type);
	}
}