using StorageMaster.Vehicles;
using System.Collections.Generic;

namespace StorageMaster.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int DEFAULT_CAPACITY = 1;
        private const int DEFAULT_SLOTS = 2;

        public AutomatedWarehouse(string name)
            : base(name, DEFAULT_CAPACITY, DEFAULT_SLOTS, new List<Vehicle>() { new Truck() })
        {

        }
    }
}