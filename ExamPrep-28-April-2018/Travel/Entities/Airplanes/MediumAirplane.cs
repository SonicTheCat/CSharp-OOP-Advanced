namespace Travel.Entities.Airplanes
{
	public class MediumAirplane : Airplane
	{
        private const int DefaultSeats = 10;
        private const int DefaultBaggageComp = 14; 

		public MediumAirplane()
			: base(DefaultSeats, DefaultBaggageComp)
		{
		}
	}
}