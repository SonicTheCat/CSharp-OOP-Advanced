namespace FestivalManager.Entities.Instruments
{
	public class Drums : Instrument
	{
        private const int RepairAmountValue = 20;

        protected override int RepairAmount => RepairAmountValue; 
	}
}