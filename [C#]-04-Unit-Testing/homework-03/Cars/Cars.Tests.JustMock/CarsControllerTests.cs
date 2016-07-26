namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Cars.Contracts;
    using Cars.Tests.JustMock.Fakes;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using Cars.Models;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        // : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void Add_ShouldAccessICarsRepositoryAddMethod()
        {
            // Arrange
            var car = new Car();
            car.Make = "asd";
            car.Model = "dsa";
            car.Id = 1;

            var fakeCarRepo = new Mock<ICarsRepository>();

            fakeCarRepo.Setup(cp => cp.GetById(It.IsAny<int>())).Returns(car);
            fakeCarRepo.Setup(cp => cp.Add(It.IsAny<Car>()));

            var controller = new CarsController(fakeCarRepo.Object);

            // Act
            var actual = controller.Add(car);

            // Assert
            fakeCarRepo.Verify(repo => repo.Add(It.IsAny<Car>()), Times.Exactly(1));
        }

        [TestMethod]
        public void Add_CarParameterIsNull_ShouldThrowTheCorrectExceptionMessage()
        {
            // Arrange
            var actual = false;

            Car car = null;
            var controller = new CarsController();

            // Act
            try
            {
                controller.Add(car);
            }
            catch (ArgumentNullException ex)
            {
                actual = ex.Message.Contains("Car cannot be null");
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Add_CarParameterMakeOrModelAreNull_ShouldThrowTheCorrectExceptionMessage()
        {
            // Arrange
            var actual = false;

            Car car = new FakeCar();
            var controller = new CarsController();

            // Act
            try
            {
                controller.Add(car);
            }
            catch (ArgumentNullException ex)
            {
                actual = ex.Message.Contains("Car make and model cannot be empty");
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Details_ShouldAccessICarsRepositoryGetById()
        {
            // Arrange
            var fakeCar = new Mock<Car>();

            var fakeCarRepo = new Mock<ICarsRepository>();
            fakeCarRepo.Setup(cp => cp.GetById(It.IsAny<int>())).Returns(fakeCar.Object);

            var controller = new CarsController(fakeCarRepo.Object);

            // Act
            var output = controller.Details(101);

            // Assert
            fakeCarRepo.Verify(cp => cp.GetById(It.IsAny<int>()), Times.Exactly(1));
        }

        [TestMethod]
        public void Details_CarReturnedByGetByIdIsNull_ShouldThrowTheCorrectMessage()
        {
            // Arrange
            var actual = false;

            Car car = null;

            var fakeCarRepo = new Mock<ICarsRepository>();
            fakeCarRepo.Setup(cp => cp.GetById(It.IsAny<int>())).Returns(car);

            var controller = new CarsController(fakeCarRepo.Object);

            // Act
            try
            {
                var result = controller.Details(100);
            }
            catch (ArgumentNullException ex)
            {
                actual = ex.Message.Contains("Car could not be found");
            }

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Search_ShouldAccessICarsRepositorySearch()
        {
            // Arrange
            var fakeCar = new Mock<Car>();

            var fakeCarRepo = new Mock<ICarsRepository>();
            fakeCarRepo.Setup(cp => cp.Search(It.IsAny<string>())).Returns(new List<Car>() { fakeCar.Object });

            var controller = new CarsController(fakeCarRepo.Object);

            // Act
            var actual = controller.Search(string.Empty);

            // Assert
            fakeCarRepo.Verify(cp => cp.Search(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void Sort_ParameterIsNotRecognized_ShouldThrowTheCorrectExceptionMessage()
        {
            // Arrange
            var actual = false;

            var sortParameter = "random string";
            var controller = new CarsController();

            // Act
            try
            {
                var result = controller.Sort(sortParameter);
            }
            catch (ArgumentException ex)
            {
                actual = ex.Message.Contains("Invalid sorting parameter");
            }

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Sort_ParameterMakeShouldCallTheCorrectSortingMethod()
        {
            // Arrange
            var sortParam = "make";

            var fakeCarRepo = new Mock<ICarsRepository>();
            fakeCarRepo.Setup(cp => cp.SortedByMake()).Returns(new List<Car>() { new Car() });

            var controller = new CarsController(fakeCarRepo.Object);

            // Act
            var result = controller.Sort(sortParam);

            // Assert
            fakeCarRepo.Verify(cp => cp.SortedByMake(), Times.Exactly(1));
        }

        [TestMethod]
        public void Sort_ParameterYearShouldCallTheCorrectSortingMethod()
        {
            // Arrange
            var sortParam = "year";

            var fakeCarRepo = new Mock<ICarsRepository>();
            fakeCarRepo.Setup(cp => cp.SortedByYear()).Returns(new List<Car>() { new Car() });

            var controller = new CarsController(fakeCarRepo.Object);

            // Act
            var result = controller.Sort(sortParam);

            // Assert
            fakeCarRepo.Verify(cp => cp.SortedByYear(), Times.Exactly(1));
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
