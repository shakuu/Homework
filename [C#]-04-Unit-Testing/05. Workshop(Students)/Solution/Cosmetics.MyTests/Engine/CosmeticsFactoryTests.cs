namespace Cosmetics.MyTests.Engine
{
    using System;

    using NUnit.Framework;

    using Cosmetics.Common;
    using Cosmetics.Engine;

    [TestFixture]
    public class CosmeticsFactoryTests
    {
        //CreateShampoo should throw NullReferenceException, 
        //when the passed "name" parameter is invalid. (Null or Empty)
        [TestCase(null)]
        [TestCase("")]
        public void CreateShampoo_ShouldThrowNullReferenceException_WhenNameParameterIsNullOrEmpty(string name)
        {
            var factory = new CosmeticsFactory();

            var brand = "brand";
            var price = 10m;
            var genderType = GenderType.Unisex;
            var milliliters = (uint)500;
            var usageType = UsageType.Medical;

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, brand, price, genderType, milliliters, usageType));
        }

        //CreateShampoo should throw IndexOutOfRangeException, 
        //when the passed "name" parameter is invalid. (length out of range)
        [TestCase("n")]
        [TestCase("incrediblyridonculouslyhugelyunexpectedlyourageouslyhumoungouslyhugelongtriplequadruplelongnamewithoutanyreadablility")]
        [TestCase("na")]
        [TestCase("12345678910")]
        public void CreateShampoo_ShouldThrowIndexOutOfRangeException_WhenNameParameterLengthIsNotWithinExpectedRange(string name)
        {
            var factory = new CosmeticsFactory();

            var brand = "brand";
            var price = 10m;
            var genderType = GenderType.Unisex;
            var milliliters = (uint)500;
            var usageType = UsageType.Medical;

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, brand, price, genderType, milliliters, usageType));
        }

        //CreateShampoo should throw NullReferenceException, 
        //when the passed "brand" parameter is invalid. (Null or Empty)
        [TestCase(null)]
        [TestCase("")]
        public void CreateShampoo_ShouldThrowNullReferenceException_WhenBrandParameterIsNullOrEmpty(string brand)
        {
            var factory = new CosmeticsFactory();

            var name = "name";
            var price = 10m;
            var genderType = GenderType.Unisex;
            var milliliters = (uint)500;
            var usageType = UsageType.Medical;

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, brand, price, genderType, milliliters, usageType));
        }

        //CreateShampoo should throw IndexOutOfRangeException,
        //when the passed "brand" parameter is invalid. (length out of range)
        [TestCase("n")]
        [TestCase("incrediblyridonculouslyhugelyunexpectedlyourageouslyhumoungouslyhugelongtriplequadruplelongnamewithoutanyreadablility")]
        [TestCase("na")]
        [TestCase("12345678910")]
        public void CreateShampoo_ShouldThrowIndexOutOfRangeException_WhenBrandParameterLengthIsNotWithinExpectedRange(string brand)
        {
            var factory = new CosmeticsFactory();

            var name = "name";
            var price = 10m;
            var genderType = GenderType.Unisex;
            var milliliters = (uint)500;
            var usageType = UsageType.Medical;

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, brand, price, genderType, milliliters, usageType));
        }

        //CreateShampoo should return a new Shampoo, 
        //when the passed parameters are all valid.

        //CreateCategory should throw NullReferenceException, 
        //when the passed "name" parameter is invalid. (Null or Empty)

        //CreateCategory should throw IndexOutOfRangeException, 
        //when the passed "name" parameter is invalid. (length out of range)

        //CreateCategory should return a new Category, 
        //when the passed parameters are all valid.

        //CreateToothpaste should throw NullReferenceException,
        //when the passed "name" parameter is invalid. (Null or Empty)

        //CreateToothpaste should throw IndexOutOfRangeException, 
        //when the passed "name" parameter is invalid. (length out of range)

        //CreateToothpaste should throw NullReferenceException, 
        //when the passed "brand" parameter is invalid. (Null or Empty)

        //CreateToothpaste should throw IndexOutOfRangeException, 
        //when the passed "brand" parameter is invalid. (length out of range)

        //CreateToothpaste should throw IndexOutOfRangeException,
        //when the lenght of any item's name is not in the allowed boundaries.

        //CreateShoppingCart should always return a new ShoppingCart.
    }
}
