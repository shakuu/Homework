using MatrixPath.Logic.Cells.Contracts;
using MatrixPath.Logic.Utils;

using NUnit.Framework;

namespace MatrixPath.Logic.Tests.Utils
{
    [TestFixture]
    public class InstantiatingMethodsTests
    {
        [Test]
        public void CreateMatrixCell_ShouldReturnANewICellInstance_WhenAllParametersAreValid()
        {
            var validRowCoordinate = -1;
            var validColCoordinate = 10;
            var cellValue = -5;

            var actual = InstantiatingMethods.CreateMatrixCell(
                validRowCoordinate,
                validColCoordinate,
                cellValue);

            Assert.That(actual, Is.InstanceOf<ICell>());
        }

        [Test]
        public void CreateMatrixCell_ShouldReturnANewICellInstance_WhenCellValueIsMissing()
        {
            var validRowCoordinate = -1;
            var validColCoordinate = 10;

            var actual = InstantiatingMethods.CreateMatrixCell(
                validRowCoordinate,
                validColCoordinate);

            Assert.That(actual, Is.InstanceOf<ICell>());
        }
    }
}
