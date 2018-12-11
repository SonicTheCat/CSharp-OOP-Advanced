using StorageMaster.Products;
using StorageMaster.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Storages
{
    public abstract class Storage
    {
        private List<Product> products;
        private Vehicle[] garage;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[garageSlots];
            this.products = new List<Product>();
            vehicles.ToArray().CopyTo(this.garage, 0);
        }

        public string Name { get; }

        //maximum weight of products the storage can handle
        public int Capacity { get; }

        public int GarageSlots { get; }

        public bool IsFull => this.Products.Sum(x => x.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => this.garage;

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public Vehicle GetVehicle(int garageSlot)
        {
            ExeptionTracker.IsValidGarageSlot(garageSlot, this);
            ExeptionTracker.IsVehicleInside(this.garage[garageSlot]);

            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            ExeptionTracker.IsValidGarageSlot(garageSlot, this);
            ExeptionTracker.IsVehicleInside(this.garage[garageSlot]);

            var vehicle = this.garage[garageSlot];

            for (int i = 0; i < deliveryLocation.garage.Length; i++)
            {
                if (deliveryLocation.garage[i] == null)
                {
                    deliveryLocation.garage[i] = vehicle;
                    this.garage[garageSlot] = null;
                    return i;
                }
            }
            throw new InvalidOperationException(ExeptionTracker.NoRoomInGarage());
        }

        public int UnloadVehicle(int garageSlot)
        {
            ExeptionTracker.IsFullStorage(this.IsFull);
            ExeptionTracker.IsValidGarageSlot(garageSlot, this);
            ExeptionTracker.IsVehicleInside(this.garage[garageSlot]);

            var vehicle = this.garage[garageSlot];

            var countOfUnloadedProducts = 0;
            while (this.IsFull != true && vehicle.IsEmpty != true)
            {
                this.products.Add(vehicle.Unload());
                countOfUnloadedProducts++;
            }
            return countOfUnloadedProducts;
        }

        public override string ToString()
        {
            return this.Name + ":\n" + "Storage worth: $" + this.products.Sum(p => p.Price).ToString("F2");
        }
    }
}