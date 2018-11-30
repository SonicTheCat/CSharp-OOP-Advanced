using NUnit.Framework;
using DataBaseNameSpace;
using System.Linq;
using System;

namespace Tests.DataBaseTests
{
    [TestFixture]
    public class DataBaseTest
    {
        private const int MaxCapacity = 16;

        private int[] validMaxCollection = Enumerable.Range(1, 16).ToArray();
        private int[] invalidBigArr = Enumerable.Range(1, 17).ToArray();
        private int[] validCollection = Enumerable.Range(1, 2).ToArray();
        private int[] emptyCollection = new int[0];

        private DataBase database;

        [Test]
        public void Constructor_MustThrowExeption_InvalidCapacity()
        {
            Assert.Throws<InvalidOperationException>(() => this.database = new DataBase(invalidBigArr));
        }

        [Test]
        public void Constructor_ShouldInitialize_ValidCapacity()
        {
            this.database = new DataBase(validCollection);
            var expectedSize = 2;
            Assert.AreEqual(expectedSize, this.database.Size);
        }

        public void AddElement_OnTheNextEmptyPosition()
        {
            this.database = new DataBase(validCollection);
            this.database.Add(10);
            var expectedSize = 3;
            Assert.AreEqual(expectedSize, this.database.Size);
            this.database.Add(10);
            this.database.Add(10);
            expectedSize = 5;
            Assert.AreEqual(expectedSize, this.database.Size);
        }

        [Test]
        public void Add_MustThrowExeption_WhenCalledOnFullCollection()
        {
            this.database = new DataBase(validMaxCollection);
            Assert.Throws<InvalidOperationException>(() => this.database.Add(10));
        }

        [Test]
        public void RemoveLastElement()
        {
            this.database = new DataBase(validCollection);
            int expectedValue = 2;
            Assert.AreEqual(expectedValue, database.Size);
            this.database.Remove();
            expectedValue = 1;
            Assert.AreEqual(expectedValue, database.Size);
        }

        [Test]
        public void RemoveFromFullCollectionAndThenAdd()
        {
            this.database = new DataBase(validMaxCollection);
            this.database.Remove();
            this.database.Add(10);
            Assert.AreEqual(MaxCapacity, database.Size);
        }

        [Test]
        public void RemoveOnEmptyCollection_ShouldThrowExeption()
        {
            this.database = new DataBase(emptyCollection);
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void Fetch_ShouldReturnCollection()
        {
            this.database = new DataBase(validMaxCollection);
            var collection = this.database.Fetch();
            Assert.AreEqual(this.database.Size, collection.Length); 
        }

        [Test]
        public void Fetch_EmptyCollection()
        {
            this.database = new DataBase(emptyCollection);
            var collection = this.database.Fetch();
            Assert.AreEqual(this.database.Size, collection.Length);
        }

        [Test]
        public void ModifyAndThenFetchCollection()
        {
            this.database = new DataBase(validMaxCollection);
            this.database.Remove();
            this.database.Remove();
            this.database.Remove();
            this.database.Add(10);
            this.database.Add(10);
            var collection = this.database.Fetch();
            Assert.AreEqual(this.database.Size, collection.Length);
        }
    }
}