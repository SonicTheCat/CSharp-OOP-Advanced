using StorageMaster.Vehicles;
using System.Collections.Generic;

namespace StorageMaster.Storages
{
    public class DistributionCenter : Storage
    {
        private const int DEFAULT_CAPACITY = 2;
        private const int DEFAULT_SLOTS = 5;

        public DistributionCenter(string name)
            : base(name, DEFAULT_CAPACITY, DEFAULT_SLOTS, new List<Vehicle>() { new Van(), new Van(), new Van() })
        {

        }
    }
}