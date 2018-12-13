public class Medium : Mission
{
    private const string DefaultName = "Capturing dangerous criminals";
    private const double EnduranceDecreaser = 50;
    private const double WearLevelDecreaser = 50;
    private const double EnduranceRequiredForMission = 50;

    public Medium(double scoreToComplete)
        : base(DefaultName, EnduranceRequiredForMission, scoreToComplete, WearLevelDecreaser, EnduranceDecreaser)
    {

    }
}