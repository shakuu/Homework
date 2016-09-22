using MatrixPath.Logic.Values;

using NUnit.Framework;

namespace MatrixPath.Logic.Tests.Values
{
    [TestFixture]
    public class BasicCellValueSequenceTests
    {
        [Test]
        public void GetNextCellValue_ShouldReturnOne_WhenInvokedForTheFirstTime()
        {
            var valueSequence = new BasicCellValueSequence();

            var actualFirstValue = valueSequence.GetNextCellValue();

            Assert.That(actualFirstValue, Is.EqualTo(1));
        }

        [Test]
        public void GetNextCellValue_ShouldIncrementValuesByOne()
        {
            var valueSequence = new BasicCellValueSequence();

            for (int i = 0; i < 1000; i++)
            {
                valueSequence.GetNextCellValue();
            }

            var value = valueSequence.GetNextCellValue();
            var nextValue = valueSequence.GetNextCellValue();

            Assert.That(value + 1, Is.EqualTo(nextValue));
        }
    }
}
