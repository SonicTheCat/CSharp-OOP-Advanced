using DataBaseNameSpace;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tests.DataBaseTests
{
    [TestFixture]
    public class DataBaseTestWithReflection
    {
        private DataBase database;

        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { int.MinValue })]
        [TestCase(new int[] { int.MaxValue })]
        public void Constructor_InitializeValidCollection_ShouldPass(params int[] values)
        {
            this.database = new DataBase(values);
            var type = typeof(DataBase);

            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo wantedField = fields.First(f => f.FieldType.BaseType == typeof(Array));

            IEnumerable<int> collection = ((int[])wantedField
                .GetValue(this.database))
                .Take(values.Length);

            Assert.That(collection, Is.EquivalentTo(values));
        }

        [Test]
        public void Constructor_TryInitializeWithBigCollection_ShouldThrowException()
        {
            var values = new int[17];
            Assert.That(() => this.database = new DataBase(values), Throws.InvalidOperationException);
        }

        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 })]
        public void Add_OnNextEmptyPosition_ShouldPass(params int[] values)
        {
            this.database = new DataBase(values);      
            this.database.Add(int.MinValue); 
            this.database.Add(int.MaxValue);

            var type = typeof(DataBase);
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;

            var wantedField = type
                .GetFields(flags)
                .First(f => f.FieldType == typeof(int[]));

            var collection = ((int[])wantedField
                .GetValue(database))
                .Take(values.Length + 2)
                .ToArray();

            Assert.That(collection.Last(), Is.EqualTo(int.MaxValue));
            Assert.That(collection[collection.Length - 2], Is.EqualTo(int.MinValue)); 
        }

        [Test]
        public void Add_ElementOnInvalidIndex_ShouldThrowException()
        {
            var values = new int[16];
            this.database = new DataBase(values);
            Assert.That(() => this.database.Add(int.MaxValue), Throws.InvalidOperationException); 
        }   
    }
}