public class MissionCommand : Command
{
    public MissionCommand(string[] data, IMissionController mission, IMissionFactory factory, IWriter writer)
        : base(data)
    {
        this.MissionController = mission;
        this.MissionFactory = factory;
        this.Writer = writer;
    }

    [Inject]
    public IMissionController MissionController { get; }

    [Inject]
    public IMissionFactory MissionFactory { get; }

    [Inject]
    public IWriter Writer { get; }

    public override void Execute()
    {
        var type = this.Data[0];
        var neededPoints = int.Parse(this.Data[1]);
      
        var mission = this.MissionFactory.CreateMission(type, neededPoints);
        var reuslt = this.MissionController.PerformMission(mission);

        this.Writer.WriteLine(reuslt);
    }
}