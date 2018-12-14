namespace Travel
{
    using System.IO;
    using System.Linq;
    using Core;
    using Core.Contracts;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;
    using Entities.Airplanes;
    using Entities.Contracts;

    public static class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IAirport airport = new Airport();
            IAirportController airportController = new AirportController(airport);
            IFlightController flightController = new FlightController(airport);
           
            var engine = new Engine(reader, writer, airportController, flightController);
            engine.Run();
        }
    }
}