namespace StorageMaster.Vehicles
{
    public class Truck : Vehicle
    {
        private const int DEFAULT_CAPACITY = 5;

        public Truck()
            : base(DEFAULT_CAPACITY)
        {
        }
    }
}