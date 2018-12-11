namespace StorageMaster.Products
{
    public abstract class Product
    {
        private double price;
        private double weight;

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                ExeptionTracker.CheckIfNegativePrice(value);
                this.price = value;
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
                this.weight = value;
            }
        }
    }
}