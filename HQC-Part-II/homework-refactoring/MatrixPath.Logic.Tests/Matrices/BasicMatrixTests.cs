using System;

using MatrixPath.Logic.Cells.Contracts;
using MatrixPath.Logic.Directions.Contracts;
using MatrixPath.Logic.Matrices;
using MatrixPath.Logic.Utils;
using MatrixPath.Logic.Values.Contracts;

using Moq;
using NUnit.Framework;

namespace MatrixPath.Logic.Tests.Matrices
{
    [TestFixture]
    public class BasicMatrixTests
    {
        [Test]
        public void Constructor_ShouldThrow_WhenMatrixSizeParameterIsLessThanOrEqualToZero()
        {
            var invalidMatrixSize = 0;
            Func<int, int, int, ICell> createCellMethod = InstantiatingMethods.CreateMatrixCell;

            Assert.That(
                () => new BasicMatrix(invalidMatrixSize, createCellMethod),
                Throws.InstanceOf<ArgumentOutOfRangeException>().With.Message.Contains("Matrix size must be larger than 0"));
        }

        [Test]
        public void Constructor_ShouldThrow_WhenCreateCellParameterIsInvalid()
        {
            var validMatrixSize = 10;

            Assert.That(
                () => new BasicMatrix(validMatrixSize, null),
                Throws.ArgumentNullException.With.Message.Contains("createCell"));
        }

        [Test]
        public void Constructor_ShouldReturnANewBasicMatrixInstance_WhenAllParametersAreValid()
        {
            var validMatrixSize = 12;
            Func<int, int, int, ICell> createCellMethod = InstantiatingMethods.CreateMatrixCell;

            var actualMatrix = new BasicMatrix(validMatrixSize, createCellMethod);

            Assert.That(actualMatrix, Is.InstanceOf<BasicMatrix>());
        }

        [Test]
        public void Populate_ShouldThrow_WhenStartPositionParameterIsInvalid()
        {
            var validMatrixSize = 12;
            Func<int, int, int, ICell> createCellMethod = InstantiatingMethods.CreateMatrixCell;
            var matrix = new BasicMatrix(validMatrixSize, createCellMethod);

            var mockSequence = new Mock<IDirectionSequence>();
            var mockValues = new Mock<ICellValueSequence>();

            Assert.That(
                () => matrix.Populate(null, mockSequence.Object, mockValues.Object),
                Throws.ArgumentNullException.With.Message.Contains("startPosition"));
        }

        [Test]
        public void Populate_ShouldThrow_WhenDirectionsInstructionsParameterIsInvalid()
        {
            var validMatrixSize = 12;
            Func<int, int, int, ICell> createCellMethod = InstantiatingMethods.CreateMatrixCell;
            var matrix = new BasicMatrix(validMatrixSize, createCellMethod);

            var mockPosition = new Mock<IPosition>();
            var mockValues = new Mock<ICellValueSequence>();

            Assert.That(
                () => matrix.Populate(mockPosition.Object, null, mockValues.Object),
                Throws.ArgumentNullException.With.Message.Contains("directionsInstructions"));
        }

        [Test]
        public void Populate_ShouldThrow_WhenValueProviderParameterIsInvalid()
        {
            var validMatrixSize = 12;
            Func<int, int, int, ICell> createCellMethod = InstantiatingMethods.CreateMatrixCell;
            var matrix = new BasicMatrix(validMatrixSize, createCellMethod);

            var mockPosition = new Mock<IPosition>();
            var mockSequence = new Mock<IDirectionSequence>();

            Assert.That(
                () => matrix.Populate(mockPosition.Object, mockSequence.Object, null),
                Throws.ArgumentNullException.With.Message.Contains("valueProvider"));
        }
    }
}
