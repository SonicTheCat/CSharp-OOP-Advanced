namespace FestivalManager.Entities.Instruments
{
    public class Bass : Guitar
    {
	    private const int RepairAmountConst = 80;

	    protected override int RepairAmount => RepairAmountConst;
    }
}