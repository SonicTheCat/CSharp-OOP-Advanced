using System;
using System.Linq;

namespace StorageMaster
{
    public class Engine
    {
        private StorageMaster storage;

        public Engine(StorageMaster storage)
        {
            this.storage = storage;
        }

        public void Run()
        {
            while (true)
            {
                var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];

                if (command == "END")
                {
                    break;
                }

                try
                {
                    switch (command)
                    {
                        case "AddProduct":
                            {
                                var type = tokens[1];
                                var price = double.Parse(tokens[2]);
                                Print(storage.AddProduct(type, price));
                            }
                            break;
                        case "RegisterStorage":
                            {
                                var type = tokens[1];
                                var name = tokens[2];
                                Print(storage.RegisterStorage(type, name));
                            }
                            break;
                        case "SelectVehicle":
                            {
                                var storageName = tokens[1];
                                var garageSlot = int.Parse(tokens[2]);
                                Print(storage.SelectVehicle(storageName, garageSlot));
                            }
                            break;
                        case "LoadVehicle":
                            {
                                var products = tokens.Skip(1).ToList();
                                Print(storage.LoadVehicle(products));
                            }
                            break;
                        case "SendVehicleTo":
                            {
                                var sourceName = tokens[1];
                                var garageSlot = int.Parse(tokens[2]);
                                var destinationName = tokens[3];
                                Print(storage.SendVehicleTo(sourceName, garageSlot, destinationName));
                            }
                            break;
                        case "UnloadVehicle":
                            {
                                var storageName = tokens[1];
                                var garageSlot = int.Parse(tokens[2]);
                                Print(storage.UnloadVehicle(storageName, garageSlot));
                            }
                            break;
                        case "GetStorageStatus":
                            {
                                var storageName = tokens[1];
                                Print(storage.GetStorageStatus(storageName));
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            Print(storage.GetSummary());
        }

        public void Print(string output)
        {
            Console.WriteLine(output);
        }
    }
}