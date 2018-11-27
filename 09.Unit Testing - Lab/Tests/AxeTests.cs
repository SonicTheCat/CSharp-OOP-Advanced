using NUnit.Framework;
using System;

namespace UnitTestingTests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe weapon;
        private Dummy dummy;
        private const int weaponAttack = 100;
        private const int weaponDurability = 10;
        private const int dummyHealth = 100;
        private const int dummyXP = 20;

        [SetUp]
        public void CreateWeaponBeforeEachTest()
        {
            this.weapon = new Axe(weaponAttack, weaponDurability);
            this.dummy = new Dummy(dummyHealth, dummyXP);
        }

        [Test]
        public void WeaponLosesDurabilityAfterEachAttack()
        {
            this.weapon.Attack(this.dummy);
            const int exepectedValue = 9;
            Assert.AreEqual(this.weapon.DurabilityPoints, exepectedValue, "Weapon does not loses durability after each attack");
        }

        [Test]
        public void AttackingWithBrokenWeapon()
        {
            this.weapon = new Axe(100, 0);

            Assert.Throws<InvalidOperationException>(() => this.weapon.Attack(this.dummy), "Attcking with broken weapon must throw InvalidOperationExeption!");
        }
    }
}