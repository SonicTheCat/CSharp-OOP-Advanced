public class Hard : Mission
{
    private const string DefaultName = "Disposal of terrorists";
    private const double EnduranceDecreaser = 80;
    private const double WearLevelDecreaser = 70;
    private const double EnduranceRequiredForMission = 80;

    public Hard(double scoreToComplete)
        : base(DefaultName, EnduranceRequiredForMission, scoreToComplete, WearLevelDecreaser, EnduranceDecreaser)
    {

    }
}