using NUnit.Framework;

public class LastArmyTest
{
    [Test]
    public void Test_MissionDeclined_ShouldReturnTrue()
    {
        IWareHouse wareHouse = new WareHouse();
        IArmy army = new Army();

        MissionController controller = new MissionController(army, wareHouse);

        string result = null;
        var mission = new Easy(1);
        for (int i = 0; i < 4; i++)
        {
            result += controller.PerformMission(mission);
        }

        Assert.IsTrue(result.Contains("declined"));
    }

    [Test]
    public void Test_MisionSuccessful_SouldReturnTrue()
    {
        IWareHouse wareHouse = new WareHouse();

        IArmy army = new Army();
        MissionController controller = new MissionController(army, wareHouse);

        IMission mission = new Easy(0);
        var result = controller.PerformMission(mission);

        var expectedResult = "Mission completed - Suppression of civil rebellion";

        Assert.That(result.StartsWith(expectedResult));
    }
}