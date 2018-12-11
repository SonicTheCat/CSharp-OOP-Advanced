using StorageMaster.Products;
using System;

namespace StorageMaster.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            switch (type)
            {
                case "Gpu": return new Gpu(price);
                case "HardDrive": return new HardDrive(price);
                case "Ram": return new Ram(price);
                case "SolidStateDrive": return new SolidStateDrive(price);
                default: throw new InvalidOperationException("Invalid product type!");
            }
        }
    }
}