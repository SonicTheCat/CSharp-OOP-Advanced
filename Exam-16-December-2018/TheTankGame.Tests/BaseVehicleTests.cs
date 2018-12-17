namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void Test()
        {
            var vehicle = new Revenger("sa", 100, 200, 1000, 500, 2000, new VehicleAssembler());
            Assert.That(vehicle.TotalWeight, Is.EqualTo(100));

            Assert.That(() => new Vanguard(null, 10, 20, 30, 40, 50, new VehicleAssembler()), Throws.ArgumentException);

            Assert.That(() => new Vanguard("sa", 0, 0, 30, 40, 50, new VehicleAssembler()), Throws.ArgumentException);
        }

        [Test]
        public void Test2()
        {
            var vehicle = new Revenger("sa", 100, 200, 1000, 500, 2000, new VehicleAssembler());
            Assert.That(vehicle.TotalWeight, Is.EqualTo(100));
            Assert.That(vehicle.TotalWeight, Is.EqualTo(100));
            Assert.That(vehicle.TotalDefense, Is.EqualTo(500));
            Assert.That(vehicle.TotalPrice, Is.EqualTo(200));
            Assert.That(vehicle.TotalAttack, Is.EqualTo(1000));
            Assert.That(vehicle.Model, Is.EqualTo("sa"));

            var result = vehicle.ToString();
            string expected = "Revenger - sa\r\nTotal Weight: 100.000\r\nTotal Price: 200.000\r\nAttack: 1000\r\nDefense: 500\r\nHitPoints: 2000\r\nParts: None";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            var vehicle = new Revenger("sa", 100, 200, 1000, 500, 2000, new VehicleAssembler());

            vehicle.AddArsenalPart(new ArsenalPart("3", 1, 2, 3));

            var result = vehicle.ToString();
            string expected = "Revenger - sa\r\nTotal Weight: 101.000\r\nTotal Price: 202.000\r\nAttack: 1003\r\nDefense: 500\r\nHitPoints: 2000\r\nParts: 3";

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}