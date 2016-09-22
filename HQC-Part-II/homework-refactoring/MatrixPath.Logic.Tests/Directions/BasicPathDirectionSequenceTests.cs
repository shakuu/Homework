using MatrixPath.Logic.Cells.Contracts;
using MatrixPath.Logic.Directions;
using MatrixPath.Logic.Utils;

using NUnit.Framework;

namespace MatrixPath.Logic.Tests.Directions
{
    [TestFixture]
    public class BasicPathDirectionSequenceTests
    {
        [Test]
        public void Constructor_ShouldThrow_WhenCreateDirectionParameterIsNotProvided()
        {
            Assert.That(() => new BasicPathDirectionSequence(null), Throws.ArgumentNullException.With.Message.Contains("createDirection"));
        }

        [Test]
        public void GetNext_ShouldReturnTheFirstElement_AfterDirectionSequenceLengthInvokations()
        {
            var basicSequence = new BasicPathDirectionSequence(InstantiatingMethods.CreateDirection);

            var firstDirection = basicSequence.GetNextDirection();
            IMovementDirection actualDirection = null;
            for (int runs = 0; runs < basicSequence.DirectionSequenceLength; runs++)
            {
                actualDirection = basicSequence.GetNextDirection();
            }

            Assert.That(actualDirection.DeltaRow, Is.EqualTo(firstDirection.DeltaRow));
            Assert.That(actualDirection.DeltaCol, Is.EqualTo(firstDirection.DeltaCol));
        }
    }
}
