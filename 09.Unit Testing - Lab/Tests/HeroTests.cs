using Moq;
using NUnit.Framework;
using Skeleton.Contracts;
using System;

namespace UnitTestingTests
{
    [TestFixture]
    public class HeroTests
    {
        private const int WeaponAttackPoints = 10;
        private const int WeaponDurabilituPoints = 10;

        private const string HeroName = "Hasan";
        private const int HeroDefaultXp = 0;

        private const int TargetXP = 100;
        private const int TargetHealth = 0;
        private const int HealthIncrement = 1;

        [Test]
        public void HeroAttack_ShoulGetExperience_WhenTargetIsDead_MochaTests()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(x => x.IsDead()).Returns(true);
            fakeTarget.Setup(x => x.GiveExperience()).Returns(TargetXP);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

            var hero = new Hero(HeroName, fakeWeapon.Object);
            hero.Attack(fakeTarget.Object);

            Assert.AreEqual(TargetXP, hero.Experience, "Hero does not get target's experience!"); 
        }

        [Test]
        public void HeroAttack_ShoulNotGetExperience_WhenTargetIsDead_MochaTests()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(x => x.IsDead()).Returns(false);
            fakeTarget.Setup(x => x.GiveExperience()).Returns(TargetXP);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

            var hero = new Hero(HeroName, fakeWeapon.Object);
            hero.Attack(fakeTarget.Object);

            Assert.AreEqual(HeroDefaultXp, hero.Experience, "Hero XP must remain unchanged when target is alive!");
        }

        //[Test]
        //public void GiveExperince_ShouldThrowException_WhenTargetAlive_MochTests()
        //{
        //    Mock<ITarget> fakeTarget = new Mock<ITarget>();
        //    fakeTarget.Setup(x => x.IsDead()).Returns(false);
        //    fakeTarget.Setup(x => x.GiveExperience())
        //        .Throws<InvalidOperationException>(); 
        //}

        [Test]
        public void HeroGetsXpWhenTargetDead()
        {
            Hero hero = new Hero("Az", new Axe(10, 10));
            ITarget dummy = new Dummy(10, 20);

            hero.Attack(dummy);
            Assert.AreEqual(20, hero.Experience, "Hero does not get Xp from the target");
        }

        [Test]
        public void HeroDoesNotGetXPWhenTargetAlive()
        {
            Hero hero = new Hero("Pael", new Axe(5, 20));
            ITarget target = new Dummy(10, 20);

            hero.Attack(target);
            Assert.AreEqual(0, hero.Experience);
        }

        [Test]
        public void HeroGetsExperinceWhenTargetIsDead()
        {
            var fakeTarget = new FakeTarget();
            var fakeWeapon = new FakeWeapon();
            var hero = new Hero(HeroName, fakeWeapon);
            hero.Attack(fakeTarget);

            Assert.AreEqual(TargetXP, hero.Experience, "Hero does not get targets XP!");
        }

        [Test]
        public void HeroDoesNotGetExperinceWhenTargetIsAlive()
        {
            var target = new Dummy(TargetHealth + HealthIncrement, TargetXP);
            var fakeWeapon = new FakeWeapon();
            var hero = new Hero(HeroName, fakeWeapon);
            hero.Attack(target);

            Assert.AreEqual(HeroDefaultXp, hero.Experience);
        }

        public class FakeWeapon : IWeapon
        {
            public int AttackPoints => WeaponAttackPoints;

            public int DurabilityPoints => WeaponDurabilituPoints;

            public void Attack(ITarget target)
            {
                // not implemented
            }
        }

        public class FakeTarget : ITarget
        {
            public int Health => TargetHealth;

            public int GiveExperience()
            {
                return TargetXP;
            }

            public bool IsDead()
            {
                return true;
            }

            public void TakeAttack(int attackPoints)
            {
                //not implemented
            }
        }
    }
}