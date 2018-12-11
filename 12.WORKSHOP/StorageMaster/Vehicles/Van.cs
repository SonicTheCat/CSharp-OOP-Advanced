namespace StorageMaster.Vehicles
{
    public class Van : Vehicle
    {
        private const int DEFAULT_CAPACITY = 2;

        public Van() 
            : base(DEFAULT_CAPACITY)
        {
        }
    }
}