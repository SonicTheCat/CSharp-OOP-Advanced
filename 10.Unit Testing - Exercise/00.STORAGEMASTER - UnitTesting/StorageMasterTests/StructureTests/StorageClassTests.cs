namespace StorageMasterTests.StructureTests
{
    using NUnit.Framework;
    using StorageMaster.Products;
    using StorageMaster.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class StorageClassTests
    {
        private const BindingFlags publicFlags = BindingFlags.Public | BindingFlags.Instance;
        private const string wanteType = "Storage";

        private Type type;
        private string message = string.Empty;

        [SetUp]
        public void GetTypeBeforeEachTest()
        {
            type = TypeGenerator.GetType(wanteType);
        }

        [Test]
        public void Validate_AllPropertiesExist_AllShoudBeTrue()
        {
            var expectedProps = new[]
            {
                "Name",
                "Capacity",
                "GarageSlots",
                "IsFull",
                "Garage",
                "Products"
            };

            var actualProps = type.GetProperties(publicFlags);

            foreach (var expProp in expectedProps)
            {
                var property = actualProps.FirstOrDefault(x => x.Name == expProp);

                message = $"Type {wanteType} does not contain property {expProp}";
                Assert.That(property, Is.Not.Null, message);
            }
        }

        [TestCase("Name", typeof(String))]
        [TestCase("Capacity", typeof(Int32))]
        [TestCase("GarageSlots", typeof(Int32))]
        [TestCase("IsFull", typeof(Boolean))]
        [TestCase("Products", typeof(IReadOnlyCollection<Product>))]
        [TestCase("Garage", typeof(IReadOnlyCollection<Vehicle>))]
        public void Validate_PropertiesTypes_AllShouldRight(string propName, Type expectedType)
        {
            var property = type.GetProperty(propName);

            message = $"{propName} is not from type {expectedType}";
            Assert.That(property.PropertyType, Is.EqualTo(expectedType), message);
        }

        [Test]
        public void Validate_MethodsExist_ShouldNotBeNull()
        {
            var expectedMethods = new[]
            {
                "GetVehicle",
                "UnloadVehicle",
                "SendVehicleTo",
            };

            var methods = type.GetMethods(publicFlags);

            foreach (var expectedMethod in expectedMethods)
            {
                var method = methods.FirstOrDefault(x => x.Name == expectedMethod);

                message = $"{expectedMethod} does not exist!";
                Assert.That(method, Is.Not.Null, message);
            }
        }

        //TODO Methods return type and methods params!
    }
}