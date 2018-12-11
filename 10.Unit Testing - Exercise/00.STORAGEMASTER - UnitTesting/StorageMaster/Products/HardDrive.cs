namespace StorageMaster.Products
{
    public class HardDrive : Product
    {
        private const double DEFAULT_WEIGHT = 1d;

        public HardDrive(double price) 
            : base(price, DEFAULT_WEIGHT)
        {
        }
    }
}