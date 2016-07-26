namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using NUnit.Framework;

    using Cars.Data;
    using Cars.Contracts;
    using Cars.Models;
    using Cars.Tests.JustMock.Fakes;

    [TestFixture]
    public class CarsRepositoryTests
    {
        [Test]
        public void Add_IDatabaseShoulseBeAccessedEachTimeAddMethodIsCalled()
        {
            // Arrange 
            const int numberOfRunsSetting = 5;

            var mockDb = new Mock<IDatabase>();
            var stubCar = new Mock<Fakes.FakeCar>();

            mockDb.SetupGet(db => db.Cars).Returns(new List<Car>());
            var carRepo = new CarsRepository(mockDb.Object);

            // Act
            for (int i = 0; i < numberOfRunsSetting; i++)
            {
                carRepo.Add(stubCar.Object);
            }

            // Assert
            mockDb.Verify(db => db.Cars, Times.Exactly(numberOfRunsSetting));
        }

        [Test]
        public void Add_ShouldThrow_IfCarParameterIsNull()
        {
            // Arrange
            Car car = null;
            var carRepo = new CarsRepository();

            var ex = Assert.Throws<ArgumentException>(() => carRepo.Add(car));
            Assert.IsTrue(ex.Message.Contains("Null car cannot be added"));
        }

        [Test]
        public void Remove_ShouldThrow_IfCarParameterIsNull()
        {
            // Arrange
            Car car = null;
            var carRepo = new CarsRepository();

            var ex = Assert.Throws<ArgumentException>(() => carRepo.Remove(car));
            Assert.IsTrue(ex.Message.Contains("Null car cannot be removed"));
        }

        [Test]
        public void GetById_ShouldThrow_IfIdCannotBeFound()
        {
            // Arrange
            var fakeDb = new Mock<IDatabase>();
            fakeDb.SetupGet(cp => cp.Cars).Returns(new List<Car>() { });

            var carRepo = new CarsRepository(fakeDb.Object);

            // Act 
            var ex = Assert.Throws<ArgumentException>(() => carRepo.GetById(10));
            Assert.IsTrue(ex.Message.Contains("Car with such Id could not be found"));
        }

        [Test]
        public void SortedByMake_ShouldReturnACollectionSortedInAlphabeticalOrder()
        {
            // Arrange 

            // Step 1: Build list of cars
            var dbListOfCars = new List<Car>();
            for (int i = 0; i < 26; i++)
            {
                var newCar = new FakeCar();
                newCar.Make = ((char)('z' - i)).ToString();
                //newCar.SetupGet(car => car.Make).Returns(((char)('z' - i)).ToString());
                dbListOfCars.Add(newCar);
            }

            // Step 2: Init Database and CarRepo
            var mockDb = new Mock<IDatabase>();
            mockDb.SetupGet(db => db.Cars).Returns(dbListOfCars);

            var carRepo = new CarsRepository(mockDb.Object);

            // Act
            var actualSortedList = carRepo.SortedByMake();
            var expected = "a";

            Assert.AreEqual(expected, (actualSortedList.First()).Make);
        }

        [Test]
        public void SortedByYear_ShouldReturnACollectionSortedInAlphabeticalOrder()
        {
            // Arrange 

            // Step 1: Build list of cars
            var dbListOfCars = new List<Car>();
            for (int i = 0; i <= 26; i++)
            {
                var newCar = new FakeCar();
                newCar.Year = 1990 + i;
                //newCar.SetupGet(car => car.Make).Returns(((char)('z' - i)).ToString());
                dbListOfCars.Add(newCar);
            }

            // Step 2: Init Database and CarRepo
            var mockDb = new Mock<IDatabase>();
            mockDb.SetupGet(db => db.Cars).Returns(dbListOfCars);

            var carRepo = new CarsRepository(mockDb.Object);

            // Act
            var actualSortedList = carRepo.SortedByYear();
            var expected = 2016;

            Assert.AreEqual(expected, (actualSortedList.First()).Year);
        }
    }
}
