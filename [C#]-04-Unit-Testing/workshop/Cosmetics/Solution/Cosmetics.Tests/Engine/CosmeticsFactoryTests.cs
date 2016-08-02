namespace Cosmetics.Tests.Engine
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using Cosmetics.Common;
    using Cosmetics.Engine;

    [TestFixture]
    public class CosmeticsFactoryTests
    {
        //- **CreateShampoo** should throw **ArgumentNullException**, when the passed "name" parameter is invalid. (Null or Empty, or with length out of range)  
        [Test]
        public void CreateShampoo_ShouldThrow_IfNameParameterIsNullOrEmpty()
        {
            //string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)

            string name = string.Empty;
            var brand = "brand";
            var price = 10m;
            var gender = GenderType.Unisex;
            var milliliters = (uint)10;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(
                name, brand, price, gender, milliliters, usage));
        }

        //- **CreateShampoo** should throw **ArgumentNullException**, when the passed "brand" parameter is invalid. (Null or Empty, or with length out of range)  
        [Test]
        public void CreateShampoo_ShouldThrow_IfBrandParameterIsNullOrEmpty()
        {
            //string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)

            var name = "name";
            string brand = string.Empty;
            var price = 10m;
            var gender = GenderType.Unisex;
            var milliliters = (uint)10;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(
                name, brand, price, gender, milliliters, usage));
        }

        //- **CreateShampoo** should return a** new Shampoo**, when the passed parameters are all valid.
        [Test]
        public void CreateShampoo_ShouldReturnANewShampoo_AllParametersAreValid()
        {
            var name = "name";
            var brand = "brand";
            var price = 10m;
            var gender = GenderType.Unisex;
            var milliliters = (uint)10;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            var newShampoo = factory.CreateShampoo(
                name, brand, price, gender, milliliters, usage);

            var actual = newShampoo.GetType().GetInterface("IShampoo");

            Assert.IsNotNull(actual);
        }

        //- **CreateCategory** should throw **ArgumentNullException**, when the passed "name" parameter is invalid. (Null or Empty, or with length out of range)
        [Test]
        public void CreateCategory_ShouldThrow_WhenNameParameterIsInvalid()
        {
            string name = null;

            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(name));
        }

        //- **CreateCategory** should return a** new Category**, when the passed parameters are all valid.
        [Test]
        public void CreateCategory_ShouldReturnANewCategory_IfAllParametersAreValid()
        {
            var name = "name";

            var factory = new CosmeticsFactory();

            var newCategory = factory.CreateCategory(name);

            var actual = newCategory.GetType().GetInterface("ICategory");

            Assert.IsNotNull(actual);
        }

        //- **CreateToothpaste** should throw **ArgumentNullException**, when the passed "name" parameter is invalid. (Null or Empty, or with length out of range)
        [Test]
        public void CreateToothpaste_ShouldThrow_IfNameParameterIsNullOrEmpty()
        {
            string name = string.Empty;
            var brand = "brand";
            var price = 10m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>()
            {
                "ingredient"
            };

            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(
                name, brand, price, gender, ingredients));
        }

        //- **CreateToothpaste** should throw **ArgumentNullException**, when the passed "brand" parameter is invalid. (Null or Empty, or with length out of range)
        [Test]
        public void CreateToothpaste_ShouldThrow_IfBrandParameterIsNullOrEmpty()
        {
            var name = "name";
            string brand = string.Empty;
            var price = 10m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>()
            {
                "ingredient"
            };

            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(
                name, brand, price, gender, ingredients));
        }

        //- **CreateToothpaste** should throw **IndexOutOfRangeException**, when the count of items in the list of ingredients is not in the allowed boundaries.
        [Test]
        public void CreateToothpaste_ShouldThrow_IfCountOfIngredientsIsNotInRange()
        {
            var name = "name";
            var brand = "brand";
            var price = 10m;
            var gender = GenderType.Unisex;
            var ingredients = new List<string>()
            {
                "1"
            };

            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(
                name, brand, price, gender, ingredients));
        }

        //- **CreateShoppingCart** should always return a new ** ShoppingCart**.
        [Test]
        public void CreateShappingCart_ShouldReturnANewShoppingCart()
        {
            var factory = new CosmeticsFactory();

            var newCategory = factory.CreateShoppingCart();

            var actual = newCategory.GetType().GetInterface("IShoppingCart");

            Assert.IsNotNull(actual);
        }
    }
}
