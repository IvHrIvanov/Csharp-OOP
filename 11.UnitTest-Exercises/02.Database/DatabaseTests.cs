using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;

        [Test]
        public void RemoveShouldRemoveOnlyTheLastElementIfThereIsSuch()
        {
            var database = new Database(1);

            database.Remove();

            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void AddMoreThanSixteenIntegers()
        {
            var array = new int[16];
            database = new Database(array);
            Assert.That(() =>
            {
                database.Add(17);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));

        }
        [Test]
        public void RemoveIntegerAtLastIndexLikeAStack()
        {
            database = new Database();
            Assert.That(() =>
            {
                database.Remove();
            }, Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }
        [Test]
        public void FetchMethodTest()
        {
            var array = new int[3] { 3,2,1};
            database = new Database(array);
            int[] massive = array;
            Assert.That(database.Fetch(), Is.EqualTo(massive));
        }
        [Test]
        public void TestConstructor()
        {
            var array = new int[16];
            var database = new Database(array);

            var expectedSize = 16;
            var actualSize = database.Count;

            Assert.AreEqual(expectedSize, actualSize);


        }
        [Test]
        public void ConstructorShouldThrowExceptionIfMoreThan17ElementsAreGivenThrough()
        {
            var array = new int[17];

            Database database;
            Assert.Throws<InvalidOperationException>(() => database = new Database(array));
        }
    }
}