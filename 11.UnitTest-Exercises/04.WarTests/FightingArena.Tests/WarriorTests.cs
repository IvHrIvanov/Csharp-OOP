using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior war;
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        [TestCase("",80,80)]
        [TestCase(" ",80,80)]
        [TestCase(null,80,80)]
        [TestCase("Ivan",-10,80)]
        [TestCase("Ivan",0,80)]
        [TestCase("Ivan",10,-1)]
        public void UncorrectParameters(string name,int dmg, int hp)
        {
            Assert.Throws<ArgumentException>(() => war = new Warrior(name, dmg, hp));
        }
        [Test]
        [TestCase("Ivan", 80, 80)]
        public void CorretParameter(string name, int dmg, int hp)
        {
            war = new Warrior(name, dmg, hp);
            Assert.That(war, Is.Not.Null);
        }
        
       
    }
}