namespace StorageMasterTests.StorageMasterTests
{
    using NUnit.Framework;
    using StorageMaster;
    using StorageMaster.Products;
    using StorageMaster.Storages;
    using StorageMaster.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class StorageMasterTest
    {
        private const BindingFlags nonPublicFlags = BindingFlags.NonPublic | BindingFlags.Instance;

        private StorageMaster storageMaster;
        private Type type;
        private string message = string.Empty;

        [SetUp]
        public void InitializeBeforeEachTest()
        {
            type = TypeGenerator.GetType("StorageMaster");
            this.storageMaster = (StorageMaster)Activator.CreateInstance(this.type, new object[] { });
        }

        [Test]
        public void Add_ProductToStorageMaster_ShoulReturnCorrectString()
        {
            var methodName = "AddProduct";
            var method = this.type.GetMethod(methodName);

            var productType = "Ram";
            var price = 2.0;

            var expectedResult = $"Added { productType } to pool";
            var actualResutl = method.Invoke(this.storageMaster, new object[] { productType, price });

            message = $"Invalid return message!";
            Assert.That(actualResutl, Is.EqualTo(expectedResult), message);

            var productPool = GetPoolField();

            var expectedSize = 1;
            message = $"Invalid collection size!";
            Assert.That(productPool.Count, Is.EqualTo(expectedSize), message);
        }

        [Test]
        public void RegisterStorage_ShouldReturnCorrectSting()
        {
            var methodName = "RegisterStorage";
            var method = this.type.GetMethod(methodName);

            var storageType = "Warehouse";
            var storageName = "Softuni";

            var expectedResult = $"Registered {storageName}";
            var actualResult = method.Invoke(this.storageMaster, new object[] { storageType, storageName });

            message = $"Invalid return message!";
            Assert.That(actualResult, Is.EqualTo(expectedResult), message);

            var storageRegistry = GetStorageField();

            var expectedSize = 1;
            message = $"Invalid return message!";
            Assert.That(storageRegistry.Count, Is.EqualTo(expectedSize), message);
        }

        [Test]
        public void SelectVehicle_ShouldReturnCorrectVehicle()
        {
            var methodName = "SelectVehicle";
            var method = this.type.GetMethod(methodName);

            var storageRegistry = GetStorageField();
            storageRegistry.Add(new Warehouse("Softuni"));
            storageRegistry.Add(new DistributionCenter("C#"));

            var selectedVehicle = this.type
           .GetFields(nonPublicFlags)
           .First(x => x.FieldType.Name == typeof(Vehicle).Name);

            Assert.That(selectedVehicle.GetValue(this.storageMaster), Is.Null);

            var storageName = "Softuni";
            var garageSlot = 1;
            var actualResult = method.Invoke(this.storageMaster, new object[] { storageName, garageSlot });
            var expectedResult = $"Selected {typeof(Semi).Name}";

            message = $"Invalid vehicle returned!";
            Assert.That(actualResult, Is.EqualTo(expectedResult), message);

            Assert.That(selectedVehicle.GetValue(this.storageMaster), Is.Not.Null);
        }

        [Test]
        public void LoadVehicle_WithEmptyPool_ShouldThrowException()
        {
            var methodName = "LoadVehicle";
            var method = this.type.GetMethod(methodName);
            var methodParams = new List<string> { "Gpu", "HardDrive" };
            var @params = new object[] { methodParams };

            Assert.That(() => method.Invoke(this.storageMaster, @params),
            Throws.InnerException.InstanceOf(typeof(InvalidOperationException)));
        }

        [Test]
        public void LoadVehicle_WithValidPool_ShouldWorkCorrect()
        {
            var methodName = "LoadVehicle";
            var method = this.type.GetMethod(methodName);
            var methodParams = new List<string> { "Gpu", "HardDrive" };
            var @params = new object[] { methodParams };

            var productPool = GetPoolField();
            productPool.Add(new Gpu(10));
            productPool.Add(new HardDrive(17));

            this.type
          .GetFields(nonPublicFlags)
          .First(x => x.FieldType.Name == typeof(Vehicle).Name)
          .SetValue(this.storageMaster, new Truck());

            var expectedResult = $"Loaded {methodParams.Count}/{methodParams.Count} products into {typeof(Truck).Name}";

            var actualResult = method.Invoke(this.storageMaster, @params);

            message = "Invalid message returned!";
            Assert.That(actualResult, Is.EqualTo(expectedResult), message);

            var expectedPoolSize = 0;
            message = "Invalid Pool size";
            Assert.That(productPool.Count, Is.EqualTo(expectedPoolSize), message);
        }

        [Test]
        public void SendVehicleTo_ShouldWorkCorrect()
        {
            var methodName = "SendVehicleTo";
            var method = this.type.GetMethod(methodName);
            var sourceName = "Kaufland";
            var destination = "Fantastiko";
            var garageSlot = 1;

            var storageRegistry = GetStorageField();
            storageRegistry.Add(new Warehouse(sourceName));
            storageRegistry.Add(new AutomatedWarehouse(destination));

            var expectedResult = $"Sent {typeof(Semi).Name} to {destination} (slot {garageSlot})";
            var actualResult = method.Invoke(this.storageMaster, new object[] { sourceName, garageSlot, destination });

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        private ICollection<Product> GetPoolField()
        {
            return (ICollection<Product>)this.type
                 .GetFields(nonPublicFlags)
                 .First(x => x.FieldType == typeof(ICollection<Product>))
                 .GetValue(this.storageMaster);
        }

        private ICollection<Storage> GetStorageField()
        {
            return (ICollection<Storage>)this.type
                  .GetFields(nonPublicFlags)
                  .First(x => x.FieldType == typeof(ICollection<Storage>))
                  .GetValue(this.storageMaster);
        }
    }
}