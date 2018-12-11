using System.Linq;
using System.Text;
using StorageMaster.Factories;
using StorageMaster.Products;
using StorageMaster.Storages;
using StorageMaster.Vehicles;
using System.Collections.Generic;

namespace StorageMaster
{
    public class StorageMaster
    {
        private ICollection<Product> productPool;
        private ICollection<Storage> storageRegistry;
        private Vehicle selectedVehicle;

        public StorageMaster()
        {
            this.productPool = new List<Product>();
            this.storageRegistry = new List<Storage>();
            this.selectedVehicle = null;
        }

        public string AddProduct(string type, double price)
        {
            ProductFactory factory = new ProductFactory();
            var product = factory.CreateProduct(type, price);

            this.productPool.Add(product);
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            StorageFactory factory = new StorageFactory();
            var storage = factory.CreateStorage(type, name);

            this.storageRegistry.Add(storage);
            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);
            var vehicle = storage.GetVehicle(garageSlot);

            this.selectedVehicle = vehicle;
            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            foreach (var name in productNames)
            {
                var contains = this.productPool.Any(x => x.GetType().Name == name);
                ExeptionTracker.IsProductInStock(contains, name);
            }

            return StartLoadingCurrentVehicle(productNames);
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var startStore = this.storageRegistry.FirstOrDefault(x => x.Name == sourceName);
            var targetStore = this.storageRegistry.FirstOrDefault(x => x.Name == destinationName);
            ExeptionTracker.DoesSourceExists(startStore);
            ExeptionTracker.DoesDestinationExists(targetStore);

            var vehicle = startStore.GetVehicle(sourceGarageSlot);
            var slot = startStore.SendVehicleTo(sourceGarageSlot, targetStore);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {slot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);
            var vehicle = storage.GetVehicle(garageSlot);

            var totalProductsIn = vehicle.Trunk.Count;
            var unloadedProducts = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProducts}/{totalProductsIn} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetGroupedProducts(storage));
            sb.AppendLine(GetAllVehiclesInGarage(storage));

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var store in this.storageRegistry.OrderByDescending(x => x.Products.Sum(p => p.Price)))
            {
                sb.AppendLine(store.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        private string StartLoadingCurrentVehicle(IEnumerable<string> productNames)
        {
            var namesToArray = productNames.ToArray();
            var addedProductsCounter = 0;
            for (int i = 0; i < namesToArray.Length; i++)
            {
                var name = namesToArray[i];
                var product = this.productPool.Last(x => x.GetType().Name == name);
                if (product != null && !this.selectedVehicle.IsFull)
                {
                    this.selectedVehicle.LoadProduct(product);
                    this.productPool.Remove(product);
                    addedProductsCounter++;
                }
            }

            return
                $"Loaded {addedProductsCounter}/{namesToArray.Length} products into" +
                $" {this.selectedVehicle.GetType().Name}";
        }

        private string GetGroupedProducts(Storage storage)
        {
            var totalWeight = storage.Products.Sum(p => p.Weight);
            var storaceCapacity = storage.Capacity;

            var groupedProducts = storage
                .Products
                .GroupBy(p => p.GetType().Name);

            List<string> products = new List<string>();
            foreach (var group in groupedProducts
                .OrderByDescending(g => g.ToList().Count)
                .ThenBy(g => g.Key))
            {
                products.Add($"{group.Key} ({group.Count()})");
            }

            return $"Stock ({totalWeight}/{storaceCapacity}): [{string.Join(", ", products)}]";
        }

        private string GetAllVehiclesInGarage(Storage storage)
        {
            var vehiclesInGarage = new List<string>();

            foreach (var v in storage.Garage)
            {
                if (v == null)
                {
                    vehiclesInGarage.Add("empty");
                }
                else
                {
                    vehiclesInGarage.Add(v.GetType().Name);
                }
            }
            return $"Garage: [{ string.Join("|", vehiclesInGarage)}]";
        }
    }
}