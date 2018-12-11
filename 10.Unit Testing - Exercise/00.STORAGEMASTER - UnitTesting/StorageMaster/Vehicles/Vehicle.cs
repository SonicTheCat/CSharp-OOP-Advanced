using System.Collections.Generic;
using StorageMaster.Products;
using System.Linq;

namespace StorageMaster.Vehicles
{
    public abstract class Vehicle
    {
        private List<Product> products;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.products = new List<Product>();
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<Product> Trunk => this.products.AsReadOnly();

        public bool IsFull => this.Trunk.Sum(x => x.Weight) >= this.Capacity;

        public bool IsEmpty => this.Trunk.Count < 1;

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                ExeptionTracker.FullVehicle();
            }

            this.products.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                ExeptionTracker.NoProductsInVehicle();
            }

            var lastProduct = this.products.Last();
            this.products.Remove(lastProduct);
            return lastProduct;
        }
    }
}