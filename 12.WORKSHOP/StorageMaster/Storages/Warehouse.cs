using StorageMaster.Vehicles;
using System.Collections.Generic;

namespace StorageMaster.Storages
{
    public class Warehouse : Storage
    {
        private const int DEFAULT_CAPACITY = 10;
        private const int DEFAULT_SLOTS = 10;

        public Warehouse(string name)
            : base(name, DEFAULT_CAPACITY, DEFAULT_SLOTS, new List<Vehicle>() { new Semi(), new Semi(), new Semi() })
        {

        }
    }
}