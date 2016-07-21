namespace School.Tests
{
    using System;
    using System.Collections.ObjectModel;

    using NUnit.Framework;

    using School.Exceptions;
    using School.Utils;

    [TestFixture]
    public class IdGeneratorTests
    {
        [Test]
        public void GenerateUniqueIdInRange_shouldThrow_ifThereIsNoAvailableUniqueIdWithinTheGivenRange()
        {
            var testInputExistingIds = new Collection<int>() { 1, 2, 3, 4, 5 };
            var testInputMinimumValue = 1;
            var testInputMaximumValue = 5;

            var ouputException = Assert.Throws<Exception>(() =>
                IdGenerator.GenerateUniqueIdInRange(testInputExistingIds, testInputMinimumValue, testInputMaximumValue));
        }

        [Test]
        public void GenerateUniqueIdInRange_shouldThrowArgumentNotUniqueException_ifThereIsNoAvailableUniqueIdWithinTheGivenRange()
        {
            var testInputExistingIds = new Collection<int>() { 1, 2, 3, 4, 5 };
            var testInputMinimumValue = 1;
            var testInputMaximumValue = 5;

            Assert.Catch<ArgumentNotUniqueException>(() =>
                IdGenerator.GenerateUniqueIdInRange(testInputExistingIds, testInputMinimumValue, testInputMaximumValue));
        }
    }
}
