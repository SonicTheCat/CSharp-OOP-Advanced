using System;
using StorageMaster.Storages;
using StorageMaster.Vehicles;

namespace StorageMaster
{
    public static class ExeptionTracker
    {
        public static void CheckIfNegativePrice(double price)
        {
            if (price < 0)
            {
                throw new InvalidOperationException("Price cannot be negative!");
            }
        }

        public static void IsValidGarageSlot(int garageSlot, Storage storage)
        {
            if (garageSlot >= storage.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
        }

        public static void IsVehicleInside(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
        }

        public static void IsFullStorage(bool isFull)
        {
            if (isFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }
        }

        public static void FullVehicle()
        {
            throw new InvalidOperationException("Vehicle is full!");
        }

        public static void NoProductsInVehicle()
        {
            throw new InvalidOperationException("No products left in vehicle!");
        }

        public static string NoRoomInGarage()
        {
            return "No room in garage!";
        }

        public static void IsProductInStock(bool contains, string name)
        {
            if (!contains)
            {
                throw new InvalidOperationException($"{name} is out of stock!");
            }
        }

        public static void DoesSourceExists(Storage storage)
        {
            if (storage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
        }

        public static void DoesDestinationExists(Storage storage)
        {
            if (storage == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }
        }
    }
}