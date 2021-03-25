using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyConstructor()
        {
            Car car = new Car("Make", "Model", 0.50, 65);
            Assert.That(car = new Car("Make", "Model", 0.50, 65), Is.EqualTo(car));
        }
        [Test]
        [TestCase("", "Model", 0.50, 65)]
        [TestCase(null, "Model", 0.50, 65)]
        [TestCase("Make", "", 0.50, 65)]
        [TestCase("Make", null, 0.50, 65)]
        [TestCase("Make", "Model", 0, 65)]
        [TestCase("Make", "Model", -20, 65)]
        [TestCase("Make", "Model", 0.50, 0)]
        [TestCase("Make", "Model", 0.50, -20)]
        public void NullParameter(string make, string model, double consumption, double capacity)
        {
            Car car;
            Assert.Throws<ArgumentException>(() => car = new Car(make, model, consumption, capacity));

        }
        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void NegativeAndZeroRefuelParametar(double refuel)
        {
            Car car = new Car("Make", "Model", 0.50, 0.50);
            Assert.That(() =>
            {
                car.Refuel(refuel);
            }, Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }
        [Test]
        [TestCase(30)]
        public void RefuelCurrectParameter(double refuel)
        {
            Car car = new Car("Make", "Model", 0.50, 20);
            car.Refuel(refuel);
            Assert.That(car.FuelCapacity, Is.EqualTo(car.FuelAmount));
        }
        [Test]
        [TestCase(50)]
        public void DriveDistanceWithBigDistanceAndReturnException(double distance)
        {
            Car car = new Car("Make", "Model", 10, 20);
            Assert.That(() =>
            {
                car.Drive(distance);
            }, Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
        }
        [Test]
        [TestCase(20)]
        public void DriveInRange(double distance)
        {
            Car car = new Car("Make", "Model", 50, 50);
            car.Refuel(60);
            car.Drive(distance);

            Assert.That(car.FuelAmount, Is.EqualTo(40));

        }
        //[Test]
        //public void FuelCannotBeNegative()
        //{
        //    Car car = new Car("Make", "Model", 10, 20);
        //    car.Refuel(21);

        //    Assert.That(() =>
        //    {
        //        car.Drive(199);
        //    }, Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be negative!"));
        //}
    }
}