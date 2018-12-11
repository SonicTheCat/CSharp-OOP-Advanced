using StorageMaster.Storages;
using System;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            switch (type)
            {
                case "DistributionCenter": return new DistributionCenter(name);
                case "Warehouse": return new Warehouse(name);
                case "AutomatedWarehouse": return new AutomatedWarehouse(name);
                default: throw new InvalidOperationException("Invalid storage type!");
            }
        }
    }
}