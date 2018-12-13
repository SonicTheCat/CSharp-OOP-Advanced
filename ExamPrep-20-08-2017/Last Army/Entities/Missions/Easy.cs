public class Easy : Mission
{
    private const string DefaultName = "Suppression of civil rebellion";
    private const double EnduranceDecreaser = 20;
    private const double WearLevelDecreaser = 30;
    private const double EnduranceRequiredForMission = 20;

    public Easy(double scoreToComplete)
        : base(DefaultName, EnduranceRequiredForMission, scoreToComplete, WearLevelDecreaser, EnduranceDecreaser)
    {

    }
}