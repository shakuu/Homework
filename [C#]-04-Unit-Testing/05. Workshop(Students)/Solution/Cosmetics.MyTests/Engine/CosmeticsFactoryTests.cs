namespace Cosmetics.MyTests.Engine
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
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
        [Test]
        public void CreateShampoo_ShouldReturnANewShampoo_WhenPassedValidParameters()
        {
            var factory = new CosmeticsFactory();

            var name = "name";
            var brand = "brand";
            var price = 10m;
            var genderType = GenderType.Unisex;
            var milliliters = (uint)500;
            var usageType = UsageType.Medical;

            var actualShampoo = factory.CreateShampoo(name, brand, price, genderType, milliliters, usageType);
            Assert.IsInstanceOf<IShampoo>(actualShampoo);
        }

        [Test]
        public void CreateToothpaste_ShouldReturnANewToothpaste_WhenPassedValidParameters()
        {
            var factory = new CosmeticsFactory();

            var name = "name";
            var brand = "brand";
            var price = 10m;
            var genderType = GenderType.Unisex;
            var ingredients = new List<string>() { "ingredient0", "ingredient1" };

            var actualToothpaste = factory.CreateToothpaste(name, brand, price, genderType, ingredients);
            Assert.IsInstanceOf<IToothpaste>(actualToothpaste);
        }

        //CreateCategory should throw NullReferenceException, 
        //when the passed "name" parameter is invalid. (Null or Empty)
        [TestCase(null)]
        [TestCase("")]
        public void CreateCategory_ShouldThrowNullReferenceException_WhenNameParameterIsNullOrEmpty(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(name));
        }

        //CreateCategory should throw IndexOutOfRangeException, 
        //when the passed "name" parameter is invalid. (length out of range)
        [TestCase("A")]
        [TestCase("0123456789012345")]
        [TestCase("superduperflippingfluffingstuffing")]
        public void CreateCategory_ShouldThrowIndexOutOfRangeException_WhenNameParametereIsLessThanTwoCharactersOrMoreThanFifteenCharactersLong(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateCategory(name));
        }

        //CreateCategory should return a new Category, 
        //when the passed parameters are all valid.
        [Test]
        public void CreateCategory_ShouldReturnANewCategory_WhenInputParameterIsValid()
        {
            var name = "category";
            var factory = new CosmeticsFactory();

            var actualCategory = factory.CreateCategory(name);

            Assert.IsInstanceOf<ICategory>(actualCategory);
        }

        //CreateToothpaste should throw NullReferenceException,
        //when the passed "name" parameter is invalid. (Null or Empty)
        [TestCase(null)]
        [TestCase("")]
        public void CreateToothpaste_ShouldThrowNullReferenceException_WhenNameParameterIsNullOrEmpty(string name)
        {
            var factory = new CosmeticsFactory();

            var brand = "brand";
            var price = 10m;
            var genderType = GenderType.Unisex;
            var ingredients = new List<string>() { "ingredient0", "ingredient1" };

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(name, brand, price, genderType, ingredients));
        }

        //CreateToothpaste should throw IndexOutOfRangeException, 
        //when the passed "name" parameter is invalid. (length out of range)
        [TestCase("n")]
        [TestCase("na")]
        [TestCase("incrediblyridonculouslyhugelyunexpectedlyourageouslyhumoungouslyhugelongtriplequadruplelongnamewithoutanyreadablility")]
        [TestCase("12345678910")]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenNameParameterLengthIsNotWithinExpectedRange(string name)
        {
            var factory = new CosmeticsFactory();

            var brand = "brand";
            var price = 10m;
            var genderType = GenderType.Unisex;
            var ingredients = new List<string>() { "ingredient0", "ingredient1" };

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(name, brand, price, genderType, ingredients));
        }

        //CreateToothpaste should throw NullReferenceException, 
        //when the passed "brand" parameter is invalid. (Null or Empty)
        [TestCase(null)]
        [TestCase("")]
        public void CreateToothpaste_ShouldThrowNullReferenceException_WhenBrandParameterIsNullOrEmpty(string brand)
        {
            var factory = new CosmeticsFactory();

            var name = "name";
            var price = 10m;
            var genderType = GenderType.Unisex;
            var ingredients = new List<string>() { "ingredient0", "ingredient1" };

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(name, brand, price, genderType, ingredients));
        }

        //CreateToothpaste should throw IndexOutOfRangeException, 
        //when the passed "brand" parameter is invalid. (length out of range)
        [TestCase("n")]
        [TestCase("incrediblyridonculouslyhugelyunexpectedlyourageouslyhumoungouslyhugelongtriplequadruplelongnamewithoutanyreadablility")]
        [TestCase("12345678910")]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenBrandParameterLengthIsNotWithinExpectedRange(string brand)
        {
            var factory = new CosmeticsFactory();

            var name = "name";
            var price = 10m;
            var genderType = GenderType.Unisex;
            var ingredients = new List<string>() { "ingredient0", "ingredient1" };

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(name, brand, price, genderType, ingredients));
        }

        //CreateToothpaste should throw IndexOutOfRangeException,
        //when the lenght of any item's name is not in the allowed boundaries.
        [TestCase("ing", "ingredient0")]
        [TestCase("0123456789123", "ingredient0")]
        [TestCase("ingredeint0", "ingredient1", "ing", "0123456789123")]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenAnyIgredientNameIsNotWithinTheLimts(params string[] ingredientsArray)
        {
            var factory = new CosmeticsFactory();

            var name = "name";
            var brand = "brand";
            var price = 10m;
            var genderType = GenderType.Unisex;

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(name, brand, price, genderType, ingredientsArray));
        }

        //CreateShoppingCart should always return a new ShoppingCart.
        [Test]
        public void CreateShoppingCart_ShouldAlwaysReturnANewShoppingCart()
        {
            var factory = new CosmeticsFactory();

            var actualShoppingCart = factory.CreateShoppingCart();

            Assert.IsInstanceOf<IShoppingCart>(actualShoppingCart);
        }
    }
}
