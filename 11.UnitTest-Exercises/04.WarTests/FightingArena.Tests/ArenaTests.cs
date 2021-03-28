using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void TestConstructor()
        {

            Assert.That(this.arena, Is.Not.Null);
        }
        [Test]
        public void CheckWarriorsInFight()
        {
            string name = "Ivan";
            Warrior warrior = new Warrior(name, 80, 80);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(new Warrior(name, 80, 80)));

        }
        [Test]
        public void AddSuccesfullWarriors()
        {
            this.arena.Enroll(new Warrior("Ivan", 50, 50));
            Assert.That(this.arena.Count, Is.EqualTo(1));
        }
        [Test]
        public void CountArenaIsEmpty()
        {
            Assert.That(this.arena.Count, Is.EqualTo(0));
        }
        [Test]

        [TestCase(null, "Kriska")]
        [TestCase("Ivan", null)]
        [TestCase(" ", "Kriska")]
        [TestCase("", "Kriska")]
        [TestCase("Ivan", "")]
        [TestCase("Ivan", " ")]
        public void AttackerDeffender(string attackerName, string deffenderName)
        {

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, deffenderName));
        }
        [Test]
        [TestCase(40, 40, 50, 50)]
        [TestCase(20, 20, 50, 50)]
        [TestCase(40, 40, 30, 30)]
        public void NotCorrectAttack(int firstWarhp, int firstWarDmg, int secondWarHp, int secondWarDmg)
        {
            Warrior firstWar = new Warrior("Ivan", firstWarhp, firstWarDmg);
            Warrior second = new Warrior("Kriska", secondWarHp, secondWarDmg);
            arena.Enroll(firstWar);
            arena.Enroll(second);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(firstWar.Name, second.Name));
        }
        [Test]
        [TestCase(60, 60, 50, 50)]
        public void CorrectAttack(int firstWarhp, int firstWarDmg, int secondWarHp, int secondWarDmg)
        {
            Warrior firstWar = new Warrior("Ivan", firstWarhp, firstWarDmg);
            Warrior second = new Warrior("Kriska", secondWarHp, secondWarDmg);
            arena.Enroll(firstWar);
            arena.Enroll(second);
            arena.Fight("Ivan", "Kriska");
            Assert.That(second.HP, Is.EqualTo(0));
        }
        [Test]
        [TestCase(40, 60, 50, 50)]
        public void DecreaseWarrHp(int firstWarhp, int firstWarDmg, int secondWarHp, int secondWarDmg)
        {
            Warrior firstWar = new Warrior("Ivan", firstWarhp, firstWarDmg);
            Warrior second = new Warrior("Kriska", secondWarHp, secondWarDmg);
            arena.Enroll(firstWar);
            arena.Enroll(second);
            arena.Fight("Ivan", "Kriska");
            Assert.That(second.HP, Is.EqualTo(10));
        }
        [Test]
        [TestCase("Ivan",null)]
        public void DefenderNullParameter(string atackerName, string defenderName)
        {
            Warrior firstWar = new Warrior(atackerName, 50, 50);
            Warrior second = new Warrior("Kriska", 40, 40);
            arena.Enroll(firstWar);
            arena.Enroll(second);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(atackerName, defenderName));

        }

    }
}
