namespace FestivalManager.Entities.Instruments
{
    using System;
    using Contracts;

	public abstract class Instrument : IInstrument
	{
		private const int MaxWear = 100;

        private double wear;

        protected Instrument()
		{
			this.Wear = MaxWear;
		}

		public double Wear
		{
			get
			{
				return this.wear;
			}
			private set
			{
				this.wear = Math.Min(Math.Max(value, 0), MaxWear);
			}
		}

        public bool IsBroken => this.Wear <= 0;

        protected abstract int RepairAmount { get; }

        public void Repair() => this.Wear += this.RepairAmount;

		public void WearDown() => this.Wear -= this.RepairAmount;
	
		public override string ToString()
		{
			var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

			return $"{this.GetType().Name} [{instrumentStatus}]";
		}
	}
}