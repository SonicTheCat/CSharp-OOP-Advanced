namespace StorageMasterTests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;
    using System.Linq;

    [TestFixture]
    public class ProductClassTests
    {
        private const BindingFlags nonPublicFlags = BindingFlags.NonPublic | BindingFlags.Instance;
        private const BindingFlags publicFlags = BindingFlags.Public | BindingFlags.Instance;

        private const string priceProperty = "Price";
        private const string weightProperty = "Weight";

        private static readonly Assembly ProjectAssembly = typeof(StorageMaster.StartUp).Assembly;
        private string message = string.Empty;

        [Test]
        public void ValidateClassProduct_ContainsProps_ShouldBeTrue()
        {
            var properties = TypeGenerator.GetType("Product")
                .GetProperties(publicFlags)
                .Select(p => p.Name);

            this.message = $"Product type does not contain Price property";
            Assert.That(properties.Contains(priceProperty), Is.True, this.message);

            this.message = $"Product type does not contain Weight property";
            Assert.That(properties.Contains(weightProperty), Is.True, this.message);
        }

        [Test]
        public void ValidateClassProduct_GettersReturnType_AllShouldBeDouble()
        {
            var getMethods = TypeGenerator.GetType("Product")
                .GetMethods(publicFlags);

            foreach (var method in getMethods.Where(x => x.Name.StartsWith("get")))
            {
                this.message = $"{method.Name} does not return value of type double!";
                Assert.That(method.ReturnType, Is.EqualTo(typeof(Double)), message);
            }
        }

        [Test]
        public void ValidateClassProduct_PrivateSetters_AllShouldBeTrue()
        {
            var methods = TypeGenerator.GetType("Product")
                .GetMethods(nonPublicFlags);

            foreach (var method in methods.Where(x => x.Name.StartsWith("set")))
            {
                this.message = $"{method.Name} does not contain private setter";
                Assert.That(method.IsPrivate, Is.True, message);
            }
        }
    }
}