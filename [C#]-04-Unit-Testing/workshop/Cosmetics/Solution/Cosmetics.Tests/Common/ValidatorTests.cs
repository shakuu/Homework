namespace Cosmetics.Tests.Common
{
    using System;

    using NUnit.Framework;

    using Cosmetics.Common;

    [TestFixture]
    public class ValidatorTests
    {
        // **CheckIfNull** should throw **NullReferenceException**, when the parameter**"obj"** is null.  
        [Test]
        public void CheckIfNull_ShouldThrow_WhenTheParameterObjIsNull()
        {
            object obj = null;

            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(obj));
        }

        //- **CheckIfNull** should **NOT throw** any Exceptions, when the parameter **"obj"** is NOT null.  
        [Test]
        public void CheckIfNull_ShouldNotThrow_WhenTheParameterObjIsNotNull()
        {
            object obj = new object();

            Assert.DoesNotThrow(() => Validator.CheckIfNull(obj));
        }

        //- **CheckIfStringIsNullOrEmpty** should throw **NullReferenceException**, when the parameter**"text"** is null or empty.
        [Test]
        public void CheckIfSringIsNullOrEmpty_ShouldThrow_WhenTheParameterTextIsNullOrEmpty()
        {
            string text = null;

            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        //- **CheckIfStringIsNullOrEmpty** should **NOT throw** any Exceptions, when the parameter**"text"** is NOT null or empty.  
        [Test]
        public void CheckIfSringIsNullOrEmpty_ShouldNotThrow_WhenTheParameterTextIsNotNullOrEmpty()
        {
            string text = "asdasdasdasd123123123!@#$";

            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        //- **CheckIfStringLengthIsValid** should throw **IndexOutOfRangeException**, when the length of the parameter **"text"** is lower than the minimum allowed value or greater than the maximum allowed value.
        [Test]
        [TestCase(6, 10)]
        [TestCase(0, 4)]

        public void CheckIfStringLengthIsValid_ShouldThrow_WhenTheLengthOfTheParameterTextIsShorterThanOrLongerThanParametersMinMax(int min, int max)
        {
            var text = "12345";

            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }

        //- **CheckIfStringLengthIsValid** should **NOT throw** any Exceptions, when the length of the parameter "text" is in the allowed boundaries.
        [Test]

        public void CheckIfStringLengthIsValid_ShouldNotThrow_WhenTheLengthOfTheParameterTextIsWithinTheSetRange()

        {
            var max = int.MaxValue;
            var min = int.MinValue;
            var text = "12345";

            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }
    }
}
