using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person;
        private ExtendedDatabase data;
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void MorePersonsThanSixteen()
        {
            data = new ExtendedDatabase();
            Person[] arguments = new Person[17];
            int n = 17;

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"Username{i}");
            }
            Assert.That(() =>
            {
                data = new ExtendedDatabase(arguments);
            }, Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }
        [Test]
        public void AddPesrons()
        {

            data = new ExtendedDatabase();
            int n = 16;
            for (int i = 0; i < n; i++)
            {
                data.Add(person = new Person(i, $"User{i}"));
            }
            Assert.That(data.Count, Is.EqualTo(n));
        }
        [Test]
        public void AddMorePersonsInArray()
        {
            data = new ExtendedDatabase();
            int n = 16;
            for (int i = 0; i < n; i++)
            {
                data.Add(person = new Person(i, $"User{i}"));
            }
            Assert.That(() =>
            {
                data.Add(person = new Person(16, "Ivan"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));

        }

        [Test]
        public void ConstructorTest()
        {
            Person people = new Person(098, "Ivan");
            data = new ExtendedDatabase(people);

            Person seconPeople = new Person(098, "Ivan");
            data = new ExtendedDatabase(seconPeople);

            Assert.AreEqual(seconPeople.UserName, people.UserName);
            Assert.AreEqual(seconPeople.Id, people.Id);

        }

        [Test]
        public void IfThereAreUsersWithThisUsername()
        {
            person = new Person(1234567, "Ivan");
            Person oder = new Person(12456, "Ivan");
            data = new ExtendedDatabase(person);

            Assert.That(() =>
            {
                data.Add(oder);
            }, Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));

        }
        [Test]
        public void IfAreAlreadyUsersWithThisId()
        {
            person = new Person(123456, "Ivan");
            Person oder = new Person(123456, "Petur");
            data = new ExtendedDatabase(person);
            Assert.That(() =>
            {
                data.Add(oder);
            }, Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }
        [Test]
        public void RemoveEmptyPersonException()
        {
            data = new ExtendedDatabase();
            Assert.That(() =>
            {
                data.Remove();
            }, Throws.InvalidOperationException);
        }
        [Test]
        public void RemoveCorrectlyPerson()
        {
            Person oder = new Person(123456, "Petur");
            data = new ExtendedDatabase(oder);
            data.Remove();
            Assert.AreEqual(data.Count, 0);
        }
        [Test]
        public void UserNotPresentedByThisName()
        {
            person = new Person(0864, "Ivan");
            data = new ExtendedDatabase(person);
            string name = "Petur";
            Assert.That(() =>
            {
                data.FindByUsername(name);
            }, Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void UsernameIsNull(string name)
        {
            Person people = new Person(089, "Ivan");
            data = new ExtendedDatabase(people);


            Assert.That(() =>
            {
                data.FindByUsername(name);
            }, Throws.ArgumentNullException);
        }
        [Test]
        public void CaseSensitive()
        {
            Person people = new Person(089, "Ivan");
            data = new ExtendedDatabase(people);
            string name = "Iva";
            Assert.That(() =>
            {
                data.FindByUsername(name);
            }, Throws.InvalidOperationException);




        }
        [Test]
        public void NoUsersPresendWithThisID()
        {
            Person people = new Person(0894, "Ivan");
            data = new ExtendedDatabase(people);
            Assert.That(() =>
            {
                data.FindById(088);
            }, Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }
        [Test]

        public void NegativeIdTest()
        {
            Person people = new Person(88888, "Ivan");
            data = new ExtendedDatabase(people);


            Assert.Throws<ArgumentOutOfRangeException>
               (() => data.FindById(-3555));

        }
        [Test]
        public void FindByIdCorrect()
        {
            long id = 12345;
            Person people = new Person(id, "ivan");
            data = new ExtendedDatabase(people);

            Assert.That(data.FindById(id), Is.EqualTo(people));
        }
        [Test]
        public void FindByUsername()
        {
            Person people = new Person(001, "Ivan");
            data = new ExtendedDatabase(people);
            Assert.That(data.FindByUsername("Ivan"), Is.EqualTo(people));
        }
    }
}