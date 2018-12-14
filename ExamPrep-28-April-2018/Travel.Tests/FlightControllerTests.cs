// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
	using NUnit.Framework;
    using Travel.Core.Controllers;
    using Travel.Core.Controllers.Contracts;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Airplanes.Contracts;
    using Travel.Entities.Contracts;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    [TestFixture]
    public class FlightControllerTests
    {
        [Test]
        public void Tester()
        {
            var airport = new Airport();
            var airplane = new LightAirplane();
            var trip = new Trip("Yambol", "Sofia", airplane);

            for (int i = 0; i <= 5; i++)
            {
                var current = new Passenger("Passenger" + i);
                trip.Airplane.AddPassenger(current);
                airport.AddPassenger(current);
            }

            var passenger = airport.GetPassenger("Passenger1");
            var bag = new Bag(passenger, new IItem[] { new Colombian() });
            passenger.Bags.Add(bag);

            var completedTrip = new Trip("a", "b", new MediumAirplane());
            completedTrip.Complete();

            airport.AddTrip(trip);
            airport.AddTrip(completedTrip);

            var flightController = new FlightController(airport);

            var actualResult = flightController.TakeOff();

            var expectedResult = "YambolSofia1:\r\nOverbooked! Ejected Passenger1\r\nConfiscated 1 bags ($50000)\r\nSuccessfully transported 5 passengers from Yambol to Sofia.\r\nConfiscated bags: 1 (1 items) => $50000";

            Assert.That(trip.IsCompleted, Is.True);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}