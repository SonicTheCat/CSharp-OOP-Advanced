using System;
using System.Linq;
using System.Text;

public class OutputCommand : Command
{
    private const string ResultString = "Result:";
    private const string SoldiersString = "Soldiers:";

    public OutputCommand(string[] data, IArmy army, IWriter writer, IMissionController missionController)
        : base(data)
    {
        this.Army = army;
        this.Writer = writer;
        this.MissionController = missionController;
    }

    [Inject]
    public IArmy Army { get; }

    [Inject]
    public IWriter Writer { get; }

    [Inject]
    public IMissionController MissionController { get; }

    public override void Execute()
    {
        StringBuilder sb = new StringBuilder();

        this.MissionController.FailMissionsOnHold();
        sb.AppendLine(ResultString);
        sb.AppendLine(string.Format(OutputMessages.MissionsSummurySuccessful, this.MissionController.SuccessMissionCounter));
        sb.AppendLine(string.Format(OutputMessages.MissionsSummuryFailed, this.MissionController.FailedMissionCounter));
        sb.AppendLine(SoldiersString);

        foreach (var soldier in this.Army.Soldiers.OrderByDescending(x => x.OverallSkill))
        {
            sb.AppendLine(soldier.ToString());
        }

        this.Writer.WriteLine(sb.ToString().Trim());

        Environment.Exit(0);
    }
}