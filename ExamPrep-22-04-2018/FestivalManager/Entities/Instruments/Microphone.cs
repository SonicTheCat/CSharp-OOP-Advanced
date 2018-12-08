namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
        private const int RepairAmountValue = 80;

        protected override int RepairAmount => RepairAmountValue;
    }
}
