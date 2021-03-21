using NUnit.Framework;
using System;

namespace Skeleton.Test
{

    public class Class1
    {

        private const int DummyHealth = 5;
        private const int DummyExperience = 10;

        private Dummy dummy;
        [SetUp]
        public void TestInit()
        {
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void DummyAreLosesHealthIfAtacked()
        {
            int attackPoints = 3;
            this.dummy.TakeAttack(attackPoints);
            Assert.That(dummy.Health, Is.EqualTo(DummyHealth - attackPoints));
        }
        [Test]
        public void DeadDummyThrowsExceptionIfAtacked()
        {

            Assert.That(dummy.IsDead(), Is.EqualTo(false));
        }
        [Test]
        public void DeadDummyThrowsExceptioZero()
        {
            dummy = new Dummy(0, DummyExperience);
            Assert.That(dummy.IsDead(), Is.EqualTo(true));

        }
        [Test]
        public void DeadDumyNegative()
        {
            dummy = new Dummy(-10, DummyExperience);
            Assert.That(dummy.IsDead(), Is.EqualTo(true));
        }
        [Test]
        public void WhenAttackDeadDummy_Throw()
        {
            dummy = new Dummy(-5, DummyExperience);
            Assert.That(() =>
            {
                dummy.TakeAttack(3);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }
        [Test]
        public void DeadDummyCanGiveXp()
        {
            dummy = new Dummy(0, DummyExperience);
            Assert.That(dummy.GiveExperience(), Is.EqualTo(DummyExperience));
        }
        [Test]
        public void AliveDummyCantGiveXp()
        {
            dummy = new Dummy(5, 5);
            Assert.That(() =>
            {
                dummy.GiveExperience();
            },Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
            
        }
    }
}

