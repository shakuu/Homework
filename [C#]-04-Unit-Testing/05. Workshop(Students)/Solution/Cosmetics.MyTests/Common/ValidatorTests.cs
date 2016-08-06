namespace Cosmetics.MyTests.Common
{
    using System;

    using NUnit.Framework;

    using Cosmetics.Common;

    [TestFixture]
    public class ValidatorTests
    {
        //CheckIfNull should throw NullReferenceException, when the parameter "obj" is null.
        [Test]
        public void CheckIfNull_ShouldThrowCorrectException_WhenObjParameterIsNull()
        {
            object obj = null;

            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(obj));
        }

        //CheckIfNull should NOT throw any Exceptions, when the parameter "obj" is NOT null.
        [Test]
        public void CheckIfNull_ShouldNotThrow_WhenObjParameterIsNotNull()
        {
            var obj = new Object();

            Assert.DoesNotThrow(() => Validator.CheckIfNull(obj));
        }

        //CheckIfStringIsNullOrEmpty should throw NullReferenceException, when the parameter "text" is null or empty.
        [TestCase(null)]
        [TestCase("")]
        public void CheckIfStringIsNullOrEmpty_ShouldThrowCorrectException_WhenTextParameterIsNullOrEmpty(string text)
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        //CheckIfStringIsNullOrEmpty should NOT throw any Exceptions, when the parameter "text" is NOT null or empty.
        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldNotThrowAnyExceptions_WhenTheParameterTextIsNotNullOrEmpty()
        {
            var text = "asdasd123123%&^%&^%^&";

            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        //CheckIfStringLengthIsValid should throw IndexOutOfRangeException, when the length of the parameter "text" is lower than the minimum allowed value or greater than the maximum allowed value.
        [TestCase(27, 50)]
        [TestCase(0, 25)]
        [TestCase(20, 15)]
        [TestCase(int.MaxValue, int.MinValue)]
        public void CheckIfStringLengthIsValid_ShouldThrowCorrectException_WhenTheLengthOfTextParameterIsNotWithinTheProvidedMinMaxParameters(int min, int max)
        {
            var text = "abcdefghijklmnopqrstuvwxyz";

            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }

        //CheckIfStringLengthIsValid should NOT throw any Exceptions, when the length of the parameter "text" is in the allowed boundaries.
        [TestCase(26, 26)]
        [TestCase(10, 26)]
        [TestCase(26, 30)]
        [TestCase(int.MinValue, int.MaxValue)]
        public void CheckIfStringLengthIsValid_ShouldNotThrow_WhenTextParameterLengthIsWithinTheProvidedMinMaxParametersRange(int min, int max)
        {
            var text = "abcdefghijklmnopqrstuvwxyz";

            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }
    }
}
