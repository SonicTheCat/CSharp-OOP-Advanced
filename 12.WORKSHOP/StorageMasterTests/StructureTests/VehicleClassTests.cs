namespace StorageMasterTests
{
    using NUnit.Framework;
    using StorageMaster.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class VehicleClassTests
    {
        private const BindingFlags publicFlags = BindingFlags.Public | BindingFlags.Instance;
        private const string wantedType = "Vehicle";

        private Type type;
        private string message = string.Empty;

        [SetUp]
        public void GetTypeBeforeEachTest()
        {
            type = TypeGenerator.GetType(wantedType);
        }

        [Test]
        public void Validate_PropertiesExist_AllShouldNotBeNull()
        {
            var expectedProps = new[]
            {
                "Capacity",
                "Trunk",
                "IsFull",
                "IsEmpty"
            };

            var actualProps = type.GetProperties(publicFlags);

            foreach (var expProp in expectedProps)
            {
                var property = actualProps.FirstOrDefault(p => p.Name == expProp);

                message = $"Type Vehicle does not contain {expProp} property!";
                Assert.That(property, Is.Not.Null, message);
            }
        }

        [TestCase("Capacity", typeof(Int32))]
        [TestCase("Trunk", typeof(IReadOnlyCollection<Product>))]
        [TestCase("IsFull", typeof(Boolean))]
        [TestCase("IsEmpty", typeof(Boolean))]
        public void Validate_PropertiesTypes_AllShouldBeTrue(string propName, Type expectedType)
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
                "Unload",
                "LoadProduct",
            };

            var methods = type.GetMethods(publicFlags);

            foreach (var expectedMethod in expectedMethods)
            {
                var method = methods.FirstOrDefault(x => x.Name == expectedMethod);

                message = $"{expectedMethod} does not exist!";
                Assert.That(method, Is.Not.Null, message);
            }
        }

        [TestCase("Unload", typeof(Product))]
        [TestCase("LoadProduct", typeof(void))]
        public void Validate_MethodsReturnTypes_AllShouldBeTrue(string methodName, Type expectedType)
        {
            var method = type.GetMethod(methodName);

            message = $"{methodName} does not return correct type!";
            Assert.That(method.ReturnType, Is.EqualTo(expectedType), message);
        }

        [TestCase("LoadProduct", typeof(Product))]
        public void Validate_LoadProductMethodParams_ShoudBeTypeProduct(string methodName, Type expectedType)
        {
            var method = type.GetMethod(methodName);
            var @params = method.GetParameters();

            foreach (var param in @params)
            {
                var paramType = param.ParameterType.Name;

                message = $"{methodName} parameter is not from type {expectedType}";
                Assert.That(paramType, Is.EqualTo(expectedType.Name), message);
            }
        }
    }
}