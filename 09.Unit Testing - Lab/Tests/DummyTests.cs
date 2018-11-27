using NUnit.Framework;
using System;

namespace UnitTestingTests
{
    public class DummyTests
    {      
        private Dummy dummy;
        private const int dummyHealth = 100;
        private const int dummyXP = 10;

        [SetUp]
        public void CreateBeforeEachTest()
        {        
            this.dummy = new Dummy(100, 10);
        }

        [Test]
        public void DoesDummyLosesHealthWhenAttacked()
        {
            DummyTakeAttack(10);
            const int expectedValue = 90;
            Assert.AreEqual(this.dummy.Health, expectedValue, "Dummy dont loses health when attacked"); 
        }

        [Test]
        public void DeadDummyShoudThrowExeptionWhenAttacked()
        {
            DummyTakeAttack(110);
            const int expectedValue = -10;
            Assert.That(this.dummy.Health, Is.EqualTo(expectedValue));
            Assert.Throws<InvalidOperationException>(() => this.dummy.TakeAttack(1), "Dummy must throw exeption when attacked!");
        }

        [Test]
        public void DeadDummyIsAbleToGiveXp()
        {
            DummyTakeAttack(110);
            const int expectedValue = 10;
            Assert.That(this.dummy.GiveExperience(), Is.EqualTo(expectedValue));
        }

        [Test]
        public void AliveDummyShouldNotBeAbleGiveExperience()
        {
            Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience(), "Alive dummy must throw exeption when try to give XP");  
        }

        private void DummyTakeAttack(int value)
        {
            this.dummy.TakeAttack(value); 
        }
    }
}