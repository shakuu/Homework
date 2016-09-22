using MatrixPath.Logic.Cells;
using MatrixPath.Logic.Cells.Contracts;

using Moq;
using NUnit.Framework;

namespace MatrixPath.Logic.Tests.Cells
{
    [TestFixture]
    public class PositionTests
    {
        [Test]
        public void MoveInDirection_ShouldIncrementRowAndColPorpertiesWithDirectionDeltaProperites_WhenDirectionParameterIsValid()
        {
            var mockDirection = new Mock<IMovementDirection>();
            mockDirection.SetupGet(direction => direction.DeltaRow).Returns(1);
            mockDirection.SetupGet(direction => direction.DeltaCol).Returns(1);

            var position = new Position(0, 0);

            var positionAfterMovementIsApplied = position.MoveInDirection(mockDirection.Object);
            var expectedPosition = new Position(1, 1);

            Assert.That(positionAfterMovementIsApplied.Row, Is.EqualTo(expectedPosition.Row));
            Assert.That(positionAfterMovementIsApplied.Col, Is.EqualTo(expectedPosition.Col));
        }

        [Test]
        public void MoveInDirection_ShouldThrow_WhenDirectionPropertyIsNotValid()
        {
            var position = new Position(0, 0);

            Assert.That(() => position.MoveInDirection(null), Throws.ArgumentNullException.With.Message.Contains("direction"));
        }

        [Test]
        public void MoveTo_ReturnsANewPositionWithRowAndColPropertiesMatchingTheInputParameters()
        {
            var position = new Position(0, 0);
            var newRow = 5;
            var newCol = 5;

            var movedPosition = position.MoveTo(newRow, newCol);

            Assert.That(movedPosition.Row, Is.EqualTo(newRow));
            Assert.That(movedPosition.Col, Is.EqualTo(newCol));
        }
    }
}
