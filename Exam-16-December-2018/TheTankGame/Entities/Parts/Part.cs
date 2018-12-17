namespace TheTankGame.Entities.Parts
{
    using System;

    using Contracts;

    public abstract class Part : IPart
    {
        private string model;
        private double weight;
        private decimal price;

        protected Part(string model, double weight, decimal price)
        {
            this.Model = model;
            this.Weight = weight;
            this.Price = price;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or white space!");
                }

                this.model = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Weight cannot be less or equal to zero!");
                }

                this.weight = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }

                this.price = value;
            }
        }
    }
}