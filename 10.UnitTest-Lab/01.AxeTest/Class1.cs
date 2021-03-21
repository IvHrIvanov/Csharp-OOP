using NUnit.Framework;
using System;

namespace Skeleton.Test
{

    public class Class1
    {
        private const int AxeAtack = 1;
        private const int AxeDurability = 1;
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;
        private Axe axe;
        private Dummy dummy;
        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAtack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }   
        [Test]
        public void BrokenAxeCantAttack()
        {
            // Arragne (made in TestInit)

            // Act
            this.axe.Attack(this.dummy);

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
            Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
        }
    }
}

