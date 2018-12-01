using ExtendedDatabase;
using ExtendedDatabase.Contracts;
using NUnit.Framework;
using System;

namespace Tests.ExtendedDataBaseTests
{
    [TestFixture]
    public class DataBasePersonTests
    {
        private const int NotExistingId = 100;
        private const string NotExistingName = "UnitTesting";

        private const int ExistingId = 1;
        private const string ExistingName = "Ivan";

        private IPerson[] people = new Person[]
        {
            new Person(ExistingId, ExistingName),
            new Person(ExistingId + 1, "Dragan"),
        };

        private DataBasePerson database;

        [SetUp]
        public void InitializeBeforeEachTest()
        {
            this.database = new DataBasePerson(this.people);
        }

        [Test]
        public void ConstructorInitializedCorrectly()
        {
            Assert.DoesNotThrow(() => this.database = new DataBasePerson(this.people), "Constructor should not throw an exception!");
        }

        [Test]
        public void CkeckDataBaseSize()
        {
            Assert.AreEqual(this.people.Length, this.database.Size, "Invalid size!");
        }

        [Test]
        public void AddPeople_WithDiffrentNames_ShoulWorkCorrect()
        {
            int expectedValue = 3;
            IPerson person = new Person(NotExistingId, NotExistingName);
            Assert.DoesNotThrow(() => this.database.Add(person), "Addng person does not work ok!");
            Assert.AreEqual(expectedValue, this.database.Size, "Invalid database size");
        }

        [Test]
        public void AddPeople_WithSameName_ExpectedException()
        {
            IPerson person = new Person(NotExistingId, ExistingName);
            Assert.Throws<InvalidOperationException>(() => this.database.Add(person), "Exception has not be thrown, when adding people with same names!");
        }

        [Test]
        public void AddPeople_WithSameId_ExpectedException()
        {
            IPerson person = new Person(ExistingId, NotExistingName);
            Assert.Throws<InvalidOperationException>(() => this.database.Add(person), "Exception has not be thrown, when adding people with same IDs!");
        }

        [Test]
        public void AddPerson_ExistingNameCaseSensitiveTest_ExpectedException()
        {
            var expectedValue = 3;
            IPerson person = new Person(NotExistingId, NotExistingName.ToLower());
            Assert.DoesNotThrow(() => this.database.Add(person), "Addng person does not work fine!");
            Assert.AreEqual(expectedValue, this.database.Size, "Invalid database size");
        }

        [Test]
        public void RemoveExistingPersonAndAddPerson_WithSameName_ShouldWork()
        {
            this.database.Remove();
            this.database.Remove();
            Assert.AreEqual(0, this.database.Size);
            this.database.Add(new Person(ExistingId, ExistingName));
            Assert.AreEqual(1, this.database.Size);
        }

        [Test]
        public void FindByUsername_PassNullArgument_ExpectedExeption()
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null), "Searching with null does not throw exception!");
        }
 
        [Test]
        public void FindByUsername_NameNotExistInCollection_ExpectedExeption()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(NotExistingName), "Searching with not existing name does not throw exception!");
        }

        [Test]
        public void FindByUsername_StringExists_ExpectedObjectPerson()
        {
            var person = this.database.FindByUsername(ExistingName);

            Assert.AreEqual(typeof(Person).Name, person.GetType().Name, "Unmatching types!");
            Assert.AreEqual(ExistingName, person.Username, "Username does not match!");
            Assert.AreEqual(ExistingId, person.ID, "Id does not match!"); 
        }

        [Test]
        public void FindById_PassNegativeNumber_ExpectedException()
        {
            int negativeNumber = -1; 

            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(negativeNumber), "Searching with negative number does not throw exception!");
        }

        [Test]
        public void FindById_IdNotExistInCollection_ExpectedException()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(NotExistingId), "Searching with non existing number does not throw exception!");
        }

        [Test]
        public void FindById_ExistingIdNumber_ExpectedPersonObject()
        {
            var person = this.database.FindById(ExistingId);

            Assert.AreEqual(typeof(Person).Name, person.GetType().Name, "Unmatching types!");
            Assert.AreEqual(ExistingName, person.Username, "Username does not match!");
            Assert.AreEqual(ExistingId, person.ID, "Id does not match!");
        }
    }
}