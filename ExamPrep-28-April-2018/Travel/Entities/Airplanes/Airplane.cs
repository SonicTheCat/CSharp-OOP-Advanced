namespace Travel.Entities.Airplanes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities.Contracts;
    using Travel.Entities.Airplanes.Contracts;

    public abstract class Airplane : IAirplane
    {
        private readonly List<IBag> baggageCompartment;
        private readonly List<IPassenger> passengers;

        protected Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;
            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
        }

        public int Seats { get; }

        public int BaggageCompartments { get; }

        public bool IsOverbooked => this.passengers.Count > this.Seats;

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IPassenger RemovePassenger(int seat)
        {
            var passenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);

            return passenger;
        }
      
        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var bagsToRemove = this.BaggageCompartment
                .Where(b => b.Owner.Username == passenger.Username)
                .ToArray();

            foreach (var bag in bagsToRemove)
            {
                this.baggageCompartment.Remove(bag);
            }

            return bagsToRemove;
        }

        public void LoadBag(IBag bag)
        {
            if (this.BaggageCompartment.Count + 1 > this.BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }

            this.baggageCompartment.Add(bag);
        }
    }
}