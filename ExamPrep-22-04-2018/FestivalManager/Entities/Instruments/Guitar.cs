namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        private const int RepairAmountValue = 60;

        protected override int RepairAmount => RepairAmountValue;
    }
}