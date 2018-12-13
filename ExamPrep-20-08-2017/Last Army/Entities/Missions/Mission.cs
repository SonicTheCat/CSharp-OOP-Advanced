public abstract class Mission : IMission
{
    protected Mission(string name, double enduranceRequired, double scoreToComplete, double wearLevelDecreaser, double enduranceDecrement)
    {
        this.Name = name;
        this.EnduranceRequired = enduranceRequired;
        this.ScoreToComplete = scoreToComplete;
        this.WearLevelDecrement = wearLevelDecreaser;
        this.EnduranceDecrement = enduranceDecrement;
    }

    public string Name { get; }

    public double EnduranceRequired { get; }

    public double ScoreToComplete { get; }

    public double WearLevelDecrement { get; }

    public double EnduranceDecrement { get; }
}