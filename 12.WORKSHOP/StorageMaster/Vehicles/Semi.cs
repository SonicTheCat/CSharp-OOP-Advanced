namespace StorageMaster.Vehicles
{
    public class Semi : Vehicle
    {
        private const int DEFAULT_CAPACITY = 10;

        public Semi() 
            : base(DEFAULT_CAPACITY)
        {
        }
    }
}