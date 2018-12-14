namespace Travel.Entities.Airplanes
{
    public class LightAirplane : Airplane
    {
        private const int DefaultSeats = 5;
        private const int DefaultBaggageComp = 8;

        public LightAirplane()
            : base(DefaultSeats, DefaultBaggageComp)
        {
        }
    }
}