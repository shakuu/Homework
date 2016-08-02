namespace Cosmetics.Tests.Engine
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Moq;
    using NUnit.Framework;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Engine;
    using Cosmetics.Tests.Fakes;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        //private void Random()
        //{
        //    Console.SetIn(new StringReader("ShowCategory ForMale"));
        //}

        //- **Start** should throw **ArgumentNullException**, when the "input" string of commands is not in the correct format.
        [Test]
        public void Start_ShouldThrow_WhenInputStringCommandIsNotInTheCorrectFormat()
        {
            Console.SetIn(new StringReader("name \r\n\r\n"));
            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockCart = new Mock<IShoppingCart>();

            var engine = new CosmeticsEngine(mockFactory.Object, mockCart.Object);

            Assert.Throws<ArgumentNullException>(() => engine.Start());
        }

        //- **Start** should read, parse and execute**"CreateCategory" command**, when the passed input string is in the format that represents a CreateCategory command, which should result in adding the new Category in the list of categories.
        [Test]
        public void Start_ShouldCreateANewCategory_WhenInputIsInAValidFormat()
        {
            Console.SetIn(new StringReader("CreateCategory ForMale\r\n\r\n"));
            Console.SetOut(new StringWriter());

            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngine(mockFactory.Object, mockCart.Object);

            mockFactory.Setup(factory => factory.CreateCategory(It.IsAny<string>())).Returns(new Mock<ICategory>().Object);

            engine.Start();

            mockFactory.Verify(mock => mock.CreateCategory(It.IsAny<string>()), Times.Once());
        }

        //- **Start** should read, parse and execute**"AddToCategory" command**, when the passed input string is in the format that represents a AddToCategory command, which should result in adding the selected product in the respective category.
        [Test]
        public void Start_ShouldExecuteAddToCategoryCommand_IfInputIsInTheCorrectFormat()
        {
            Console.SetIn(new StringReader("AddToCategory ForMale White+\r\n\r\n"));
            Console.SetOut(new StringWriter());

            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockCart = new Mock<IShoppingCart>();
            var mockProdcut = new Mock<IProduct>();
            var mockCategory = new Mock<ICategory>();
            var engine = new FakeCosmeticsEngine(mockFactory.Object, mockCart.Object);

            mockCategory.Setup(mock => mock.AddCosmetics(It.IsAny<IProduct>()));

            engine.BaseProducts.Add("White+", mockProdcut.Object);
            engine.BaseCategories.Add("ForMale", mockCategory.Object);

            engine.Start();

            mockCategory.Verify(mock => mock.AddCosmetics(It.IsAny<IProduct>()), Times.Once());
        }

        //- **Start** should read, parse and execute**"RemoveFromCategory" command**, when the passed input string is in the format that represents a RemoveFromCategory command, which should result in removing the selected product from the respective category.  
        [Test]
        public void Start_ShouldExecuteRemoveFromCategoryCommand_IfInputIsInTheCorrectFormat()
        {
            Console.SetIn(new StringReader("RemoveFromCategory ForMale White+\r\n\r\n"));
            Console.SetOut(new StringWriter());

            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockCart = new Mock<IShoppingCart>();
            var mockProdcut = new Mock<IProduct>();
            var mockCategory = new Mock<ICategory>();
            var engine = new FakeCosmeticsEngine(mockFactory.Object, mockCart.Object);

            mockCategory.Setup(mock => mock.RemoveCosmetics(It.IsAny<IProduct>()));

            engine.BaseProducts.Add("White+", mockProdcut.Object);
            engine.BaseCategories.Add("ForMale", mockCategory.Object);

            engine.Start();

            mockCategory.Verify(mock => mock.RemoveCosmetics(It.IsAny<IProduct>()), Times.Once());
        }

        //- **Start** should read, parse and execute**"ShowCategory" command**, when the passed input string is in the format that represents a ShowCategory command, which should result in calling the Print() method of the respective cateogry.
        [Test]
        public void Start_ShouldExecuteShowCategoryCommand_IfInputIsInTheCorrectFormat()
        {
            Console.SetIn(new StringReader("ShowCategory ForMale\r\n\r\n"));
            Console.SetOut(new StringWriter());

            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockCart = new Mock<IShoppingCart>();
            var mockProdcut = new Mock<IProduct>();
            var mockCategory = new Mock<ICategory>();
            var engine = new FakeCosmeticsEngine(mockFactory.Object, mockCart.Object);

            mockCategory.Setup(mock => mock.Print());

            engine.BaseProducts.Add("White+", mockProdcut.Object);
            engine.BaseCategories.Add("ForMale", mockCategory.Object);

            engine.Start();

            mockCategory.Verify(mock => mock.Print(), Times.Once());
        }

        //- **Start** should read, parse and execute**"CreateShampoo" command**, when the passed input string is in the format that represents a CreateShampoo command, which should result in adding the newly created shampoo in the list of products.

        [Test]
        public void Start_ShouldExecuteCreateShampoo_IfInputIsInTheCorrectFormat()
        {
            Console.SetIn(new StringReader("CreateShampoo Cool Nivea 0.50 men 500 everyday\r\n\r\n"));
            Console.SetOut(new StringWriter());

            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockCart = new Mock<IShoppingCart>();
            var engine = new FakeCosmeticsEngine(mockFactory.Object, mockCart.Object);
            var mockShampoo = new Mock<IShampoo>();

            mockFactory.Setup(mock => mock.CreateShampoo(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<GenderType>(),
                It.IsAny<uint>(),
                It.IsAny<UsageType>())).Returns(mockShampoo.Object);
          
            engine.Start();

            mockFactory.Verify(mock => mock.CreateShampoo(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<GenderType>(),
                It.IsAny<uint>(),
                It.IsAny<UsageType>()), Times.Once());
        }

        //- **Start** should read, parse and execute**"CreateToothpaste" command**, when the passed input string is in the format that represents a CreateToothpaste command, which should result in adding the newly created toothpaste in the list of products.    
        [Test]
        public void Start_ShouldExecuteCreateToothpaste_IfInputIsInTheCorrectFormat()
        {
            Console.SetIn(new StringReader("CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma\r\n\r\n"));
            Console.SetOut(new StringWriter());

            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockCart = new Mock<IShoppingCart>();
            var engine = new FakeCosmeticsEngine(mockFactory.Object, mockCart.Object);
            var mockToothpaste = new Mock<IToothpaste>();

            mockFactory.Setup(mock => mock.CreateToothpaste(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<GenderType>(),
                It.IsAny<IList<string>>())).Returns(mockToothpaste.Object);

            engine.Start();

            mockFactory.Verify(mock => mock.CreateToothpaste(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<GenderType>(),
                It.IsAny<IList<string>>()), Times.Once());
        }

        //- **Start** should read, parse and execute**"AddToShoppingCart" command**, when the passed input string is in the format that represents a AddToShoppingCart command, which should result in adding the selected product to the shopping cart.  
        [Test]
        public void Start_ShouldExecuteAddToShoppingCart_IfInputIsInTheCorrectFormat()
        {
            Console.SetIn(new StringReader("AddToShoppingCart White+\r\n\r\n"));
            Console.SetOut(new StringWriter());

            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockCart = new Mock<IShoppingCart>();
            var mockProduct = new Mock<IProduct>();
            var engine = new FakeCosmeticsEngine(mockFactory.Object, mockCart.Object);

            mockCart.Setup(mock => mock.AddProduct(It.IsAny<IProduct>()));

            engine.BaseProducts.Add("White+", mockProduct.Object);

            engine.Start();

            mockCart.Verify(mock => mock.AddProduct(It.IsAny<IProduct>()), Times.Once());
        }

        //- **Start** should read, parse and execute**"RemoveFromShoppingCart" command**, when the passed input string is in the format that represents a RemoveFromShoppingCart command, which should result in removing the selected product from the shopping cart.
        [Test]
        public void Start_ShouldExecuteRemoveFromShoppingCart_IfInputIsInTheCorrectFormat()
        {
            Console.SetIn(new StringReader("RemoveFromShoppingCart White+\r\n\r\n"));
            Console.SetOut(new StringWriter());

            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockCart = new Mock<IShoppingCart>();
            var mockProduct = new Mock<IProduct>();
            var engine = new FakeCosmeticsEngine(mockFactory.Object, mockCart.Object);

            mockCart.Setup(mock => mock.RemoveProduct(It.IsAny<IProduct>()));
            mockCart.Setup(mock => mock.ContainsProduct(It.IsAny<IProduct>())).Returns(true);

            engine.BaseProducts.Add("White+", mockProduct.Object);

            engine.Start();

            mockCart.Verify(mock => mock.RemoveProduct(It.IsAny<IProduct>()), Times.Once());
        }
    }
}
