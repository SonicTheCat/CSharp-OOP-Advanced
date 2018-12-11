namespace StorageMasterTests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class AllClassesTests
    {
        private static readonly string[] abstractClasses = new[]
        {
                 "Vehicle",
                 "Storage",
                 "Product"
        };

        [Test]
        public void Validate_ConcreteClassExist_SouldAllBeTrue()
        {
            var factoryClasses = new[] {
                 "ProductFactory",
                 "StorageFactory",
                 "VehicleFactory"
            };

            var entityClasses = new[]
            {
                "Gpu",
                "HardDrive",
                "Ram",
                "SolidStateDrive",
                "Product",

                "Storage",
                "AutomatedWarehouse",
                "DistributionCenter",
                "Warehouse",

                "Vehicle",
                "Semi",
                "Truck",
                "Van"
            };

            var controllerClasses = new[]
            {
                "StorageMaster"
            };

            var allClasses = new[]
            {
                factoryClasses,
                entityClasses,
                controllerClasses
            };

            foreach (var @class in allClasses)
            {
                foreach (var typeName in @class)
                {
                    var type = TypeGenerator.GetType(typeName);
                    var message = $"{typeName} type does not exist!";

                    Assert.That(type, Is.Not.Null, message);
                }
            }
        }

        [Test]
        public void Validate_AbstractClasses_ShouldBeTrue()
        {
            foreach (var className in abstractClasses)
            {
                var type = TypeGenerator.GetType(className);
                var message = $"{className} type is not abstract!";

                Assert.That(type.IsAbstract, Is.True, message);
            }
        }

        [Test]
        public void Validate_AbstractClassesHasProtectedConstructor_ShoudBeTrue()
        {
            foreach (var classType in abstractClasses)
            {
                var type = TypeGenerator.GetType(classType);
                var constructors = type.GetConstructors();

                var message = $"{classType} has public constructor.";
                Assert.That(constructors.Length, Is.EqualTo(0), message);

               constructors = type
                    .GetConstructors((BindingFlags.Instance | BindingFlags.NonPublic));

                foreach (var constructor in constructors)
                {
                    message = $"{classType} does not contain protected constructor!";
                    Assert.That(constructor.IsFamily, Is.True, message);
                }
            }
        }

        [TestCase(new object[] { "Van", "Truck", "Semi" }, "Vehicle")]
        [TestCase(new object[] { "Gpu", "HardDrive", "Ram", "SolidStateDrive" }, "Product")]
        [TestCase(new object[] { "AutomatedWarehouse", "DistributionCenter", "Warehouse" }, "Storage")]
        public void Validate_ChildClassesInheritFromBaseType_ShouldBeEqual(object[] values, string baseType)
        {
            foreach (var typeName in values.Select(Convert.ToString).ToArray())
            {
                var type = TypeGenerator.GetType(typeName);
                var message = $"{typeName} does not inherit from {baseType} class";

                Assert.That(type.BaseType.Name, Is.EqualTo(baseType), message);
            }
        }
    }
}