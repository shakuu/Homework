namespace Cosmetics.MyTests.Engine
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using NUnit.Framework;

    using Cosmetics.Contracts;
    using Cosmetics.Common;
    using Cosmetics.Engine;
    using Cosmetics.MyTests.Engine.Mocks;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        // Start should read, parse and execute "CreateCategory" command,
        // when the passed input string is in the format that represents a CreateCategory command,
        // which should result in adding the new Category in the list of categories.
        [Test]
        public void Start_ShouldNotThrow_WhenInputCommandIsCreateCategory()
        {
            var mockFactory = new Mock<ICosmeticsFactory>();

            var mockShoppingCart = new Mock<IShoppingCart>();

            var mockCommand = new Mock<ICommand>();
            mockCommand.SetupGet(mock => mock.Name).Returns("CreateCategory");
            mockCommand.SetupGet(mock => mock.Parameters).Returns(new List<string>() { "For Men" });

            var mockCommandParser = new Mock<ICommandParser>();
            mockCommandParser.Setup(mock => mock.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var cosmeticsEngine = new CosmeticsEngine(mockFactory.Object, mockShoppingCart.Object, mockCommandParser.Object);

            Assert.DoesNotThrow(() => cosmeticsEngine.Start());
        }

        [Test]
        public void Start_ShouldAddANewCategory_WhenInputCommandIsCreateCategory()
        {
            var mockFactory = new Mock<ICosmeticsFactory>();
            mockFactory.Setup(mock => mock.CreateCategory(It.IsAny<string>())).Returns(new Mock<ICategory>().Object);

            var mockShoppingCart = new Mock<IShoppingCart>();

            var mockCommand = new Mock<ICommand>();
            mockCommand.SetupGet(mock => mock.Name).Returns("CreateCategory");
            mockCommand.SetupGet(mock => mock.Parameters).Returns(new List<string>() { "ForMen" });

            var mockCommandParser = new Mock<ICommandParser>();
            mockCommandParser.Setup(mock => mock.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var cosmeticsEngine = new ExposedCategoriesAndProductsMockCosmeticsEngine(mockFactory.Object, mockShoppingCart.Object, mockCommandParser.Object);
            cosmeticsEngine.Start();

            Assert.IsNotNull(cosmeticsEngine.Categories["ForMen"]);
        }

        [Test]
        public void Start_ShouldAddANewCategoryWithTheCorrectName_WhenInputCommandIsCreateCategory()
        {
            var mockFactory = new Mock<ICosmeticsFactory>();
            mockFactory.Setup(mock => mock.CreateCategory(It.IsAny<string>())).Returns(new Mock<ICategory>().Object);

            var mockShoppingCart = new Mock<IShoppingCart>();

            var mockCommand = new Mock<ICommand>();
            mockCommand.SetupGet(mock => mock.Name).Returns("CreateCategory");
            mockCommand.SetupGet(mock => mock.Parameters).Returns(new List<string>() { "ForMen" });

            var mockCommandParser = new Mock<ICommandParser>();
            mockCommandParser.Setup(mock => mock.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var cosmeticsEngine = new ExposedCategoriesAndProductsMockCosmeticsEngine(mockFactory.Object, mockShoppingCart.Object, mockCommandParser.Object);
            cosmeticsEngine.Start();

            mockFactory.Verify(mock => mock.CreateCategory("ForMen"), Times.Once());
        }

        //Start should read, parse and execute "AddToCategory" command, 
        //when the passed input string is in the format that represents a AddToCategory command,
        //which should result in adding the selected product in the respective category.
        [Test]
        public void Start_ShouldNotThrow_WhenInputCommandAddToCategoryIsInValidFormat()
        {
            var mockFactory = new Mock<ICosmeticsFactory>();

            var mockShoppingCart = new Mock<IShoppingCart>();

            var mockCommand = new Mock<ICommand>();
            mockCommand.SetupGet(mock => mock.Name).Returns("AddToCategory");
            mockCommand.SetupGet(mock => mock.Parameters).Returns(new List<string>() { "ForMen", "Product" });

            var mockCommandParser = new Mock<ICommandParser>();
            mockCommandParser.Setup(mock => mock.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var cosmeticsEngine = new ExposedCategoriesAndProductsMockCosmeticsEngine(mockFactory.Object, mockShoppingCart.Object, mockCommandParser.Object);
            cosmeticsEngine.Categories.Add("ForMen", null);
            cosmeticsEngine.Products.Add("Product", null);

            Assert.DoesNotThrow(() => cosmeticsEngine.Start());
        }

        [Test]
        public void Start_Should_AddTheSpecifiedProductToTheCorrectCategory_WhenInputIsValid()
        {
            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var mockCategory = new Mock<ICategory>();
            var mockProduct = new Mock<IProduct>();

            var mockCommand = new Mock<ICommand>();
            mockCommand.SetupGet(mock => mock.Name).Returns("AddToCategory");
            mockCommand.SetupGet(mock => mock.Parameters).Returns(new List<string>() { "ForMen", "Product" });

            var mockCommandParser = new Mock<ICommandParser>();
            mockCommandParser.Setup(mock => mock.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var cosmeticsEngine = new ExposedCategoriesAndProductsMockCosmeticsEngine(mockFactory.Object, mockShoppingCart.Object, mockCommandParser.Object);
            cosmeticsEngine.Categories.Add("ForMen", mockCategory.Object);
            cosmeticsEngine.Products.Add("Product", mockProduct.Object);

            cosmeticsEngine.Start();

            mockCategory.Verify(mock => mock.AddProduct(mockProduct.Object), Times.Once());
        }

        //Start should read, parse and execute "RemoveFromCategory" command, 
        //when the passed input string is in the format that represents a RemoveFromCategory command,
        //which should result in removing the selected product from the respective category.
        [Test]
        public void Start_ShouldNotThrow_WhenInputCommandRemoveFromCategoryIsInValidFormat()
        {
            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var mockCategory = new Mock<ICategory>();
            var mockProduct = new Mock<IProduct>();

            var mockCommand = new Mock<ICommand>();
            mockCommand.SetupGet(mock => mock.Name).Returns("RemoveFromCategory");
            mockCommand.SetupGet(mock => mock.Parameters).Returns(new List<string>() { "ForMen", "Product" });

            var mockCommandParser = new Mock<ICommandParser>();
            mockCommandParser.Setup(mock => mock.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var cosmeticsEngine = new ExposedCategoriesAndProductsMockCosmeticsEngine(mockFactory.Object, mockShoppingCart.Object, mockCommandParser.Object);
            cosmeticsEngine.Categories.Add("ForMen", mockCategory.Object);
            cosmeticsEngine.Products.Add("Product", mockProduct.Object);

            Assert.DoesNotThrow(() => cosmeticsEngine.Start());
        }

        [Test]
        public void Start_ShouldCallCategoryRemoveProduct_WhenInputCommandRemoveFromCategoryIsInValidFormat()
        {
            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var mockCategory = new Mock<ICategory>();
            var mockProduct = new Mock<IProduct>();

            var mockCommand = new Mock<ICommand>();
            mockCommand.SetupGet(mock => mock.Name).Returns("RemoveFromCategory");
            mockCommand.SetupGet(mock => mock.Parameters).Returns(new List<string>() { "ForMen", "Product" });

            var mockCommandParser = new Mock<ICommandParser>();
            mockCommandParser.Setup(mock => mock.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var cosmeticsEngine = new ExposedCategoriesAndProductsMockCosmeticsEngine(mockFactory.Object, mockShoppingCart.Object, mockCommandParser.Object);
            cosmeticsEngine.Categories.Add("ForMen", mockCategory.Object);
            cosmeticsEngine.Products.Add("Product", mockProduct.Object);

            cosmeticsEngine.Start();

            mockCategory.Verify(mock => mock.RemoveProduct(mockProduct.Object), Times.Once());
        }

        //Start should read, parse and execute "ShowCategory" command, 
        //when the passed input string is in the format that represents a ShowCategory command, 
        //which should result in calling the Print() method of the respective cateogry.
        [Test]
        public void Start_ShouldAccessCategoryPrint_WhenInputCommandShowCategoryIsInValidFormat()
        {
            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var mockCategory = new Mock<ICategory>();

            var mockCommand = new Mock<ICommand>();
            mockCommand.SetupGet(mock => mock.Name).Returns("ShowCategory");
            mockCommand.SetupGet(mock => mock.Parameters).Returns(new List<string>() { "ForMen" });

            var mockCommandParser = new Mock<ICommandParser>();
            mockCommandParser.Setup(mock => mock.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var cosmeticsEngine = new ExposedCategoriesAndProductsMockCosmeticsEngine(mockFactory.Object, mockShoppingCart.Object, mockCommandParser.Object);
            cosmeticsEngine.Categories.Add("ForMen", mockCategory.Object);

            cosmeticsEngine.Start();

            mockCategory.Verify(mock => mock.Print(), Times.Once());
        }

        //Start should read, parse and execute "CreateShampoo" command, 
        //when the passed input string is in the format that represents a CreateShampoo command, 
        //which should result in adding the newly created shampoo in the list of products.
        [Test]
        public void Start_ShouldAccessFactoryCreateShampoo_WhenInputCommandShowCategoryIsInValidFormat()
        {
            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var mockCommand = new Mock<ICommand>();
            var commandName = "CreateShampoo";
            var commandParameters = new List<string>() { "Cool", "Nivea", "0.50", "men", "500", "everyday" };
            mockCommand.SetupGet(mock => mock.Name).Returns(commandName);
            mockCommand.SetupGet(mock => mock.Parameters).Returns(commandParameters);

            var mockCommandParser = new Mock<ICommandParser>();
            mockCommandParser.Setup(mock => mock.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var cosmeticsEngine = new ExposedCategoriesAndProductsMockCosmeticsEngine(mockFactory.Object, mockShoppingCart.Object, mockCommandParser.Object);

            cosmeticsEngine.Start();

            mockFactory.Verify(mock =>
                mock.CreateShampoo("Cool", "Nivea", 0.50m, GenderType.Men, (uint)500, UsageType.EveryDay), Times.Once());
        }

        [Test]
        public void Start_ShouldAddTheNewShampooToProducts_WhenInputCommandShowCategoryIsInValidFormat()
        {
            var mockShampoo = new Mock<IShampoo>();

            var mockFactory = new Mock<ICosmeticsFactory>();
            mockFactory.Setup(mock => mock.CreateShampoo(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<decimal>(),
                    It.IsAny<GenderType>(),
                    It.IsAny<uint>(),
                    It.IsAny<UsageType>()))
                .Returns(mockShampoo.Object);

            var mockShoppingCart = new Mock<IShoppingCart>();

            var mockCommand = new Mock<ICommand>();
            var commandName = "CreateShampoo";
            var commandParameters = new List<string>() { "Cool", "Nivea", "0.50", "men", "500", "everyday" };
            mockCommand.SetupGet(mock => mock.Name).Returns(commandName);
            mockCommand.SetupGet(mock => mock.Parameters).Returns(commandParameters);

            var mockCommandParser = new Mock<ICommandParser>();
            mockCommandParser.Setup(mock => mock.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var cosmeticsEngine = new ExposedCategoriesAndProductsMockCosmeticsEngine(mockFactory.Object, mockShoppingCart.Object, mockCommandParser.Object);

            cosmeticsEngine.Start();

            var actualAddedShampoo = cosmeticsEngine.Products.First().Value;
            Assert.AreSame(mockShampoo.Object, actualAddedShampoo);
        }

        //Start should read, parse and execute "CreateToothpaste" command,
        //when the passed input string is in the format that represents a CreateToothpaste command, 
        //which should result in adding the newly created toothpaste in the list of products.
        [Test]
        public void Start_ShouldAccessFactoryCreateToothpaste_WhenInputCommandShowCategoryIsInValidFormat()
        {
            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var mockCommand = new Mock<ICommand>();
            var commandName = "CreateToothpaste";
            var commandParameters = new List<string>() { "White+", "Colgate", "15.50", "men", "fluor,bqla,golqma" };
            mockCommand.SetupGet(mock => mock.Name).Returns(commandName);
            mockCommand.SetupGet(mock => mock.Parameters).Returns(commandParameters);

            var mockCommandParser = new Mock<ICommandParser>();
            mockCommandParser.Setup(mock => mock.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var cosmeticsEngine = new ExposedCategoriesAndProductsMockCosmeticsEngine(mockFactory.Object, mockShoppingCart.Object, mockCommandParser.Object);

            cosmeticsEngine.Start();

            mockFactory.Verify(mock =>
                mock.CreateToothpaste("White+", "Colgate", 15.50m, GenderType.Men, new List<string>() { "fluor", "bqla", "golqma" }), Times.Once());
        }

        [Test]
        public void Start_ShouldAddTheNewToothpasteToProducts_WhenInputCommandShowCategoryIsInValidFormat()
        {
            var mockToothpaste = new Mock<IToothpaste>();

            var mockFactory = new Mock<ICosmeticsFactory>();
            mockFactory.Setup(mock => mock.CreateToothpaste(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<decimal>(),
                    It.IsAny<GenderType>(),
                    It.IsAny<List<string>>()))
                .Returns(mockToothpaste.Object);

            var mockShoppingCart = new Mock<IShoppingCart>();

            var mockCommand = new Mock<ICommand>();
            var commandName = "CreateToothpaste";
            var commandParameters = new List<string>() { "White+", "Colgate", "15.50", "men", "fluor,bqla,golqma" };
            mockCommand.SetupGet(mock => mock.Name).Returns(commandName);
            mockCommand.SetupGet(mock => mock.Parameters).Returns(commandParameters);

            var mockCommandParser = new Mock<ICommandParser>();
            mockCommandParser.Setup(mock => mock.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var cosmeticsEngine = new ExposedCategoriesAndProductsMockCosmeticsEngine(mockFactory.Object, mockShoppingCart.Object, mockCommandParser.Object);

            cosmeticsEngine.Start();

            var actualAddedToothpaste = cosmeticsEngine.Products.First().Value;
            Assert.AreSame(mockToothpaste.Object, actualAddedToothpaste);
        }

        //Start should read, parse and execute "AddToShoppingCart" command,
        //when the passed input string is in the format that represents a AddToShoppingCart command, 
        //which should result in adding the selected product to the shopping cart.
        [Test]
        public void Start_ShouldAccessShppingCartAddProduct_WhenInputCommandAddToCategoryIsInValidFormat()
        {
            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();

            var mockCommand = new Mock<ICommand>();
            mockCommand.SetupGet(mock => mock.Name).Returns("AddToShoppingCart");
            mockCommand.SetupGet(mock => mock.Parameters).Returns(new List<string>() { "Product" });

            var mockCommandParser = new Mock<ICommandParser>();
            mockCommandParser.Setup(mock => mock.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var cosmeticsEngine = new ExposedCategoriesAndProductsMockCosmeticsEngine(mockFactory.Object, mockShoppingCart.Object, mockCommandParser.Object);
            cosmeticsEngine.Products.Add("Product", null);

            cosmeticsEngine.Start();

            mockShoppingCart.Verify(mock => mock.AddProduct(It.IsAny<IProduct>()), Times.Once());
        }

        //Start should read, parse and execute "RemoveFromShoppingCart" command, 
        //when the passed input string is in the format that represents a RemoveFromShoppingCart command, 
        //which should result in removing the selected product from the shopping cart.
        [Test]
        public void Start_ShouldAccessShppingCartRemoveProduct_WhenInputCommandAddToCategoryIsInValidFormat()
        {
            var mockFactory = new Mock<ICosmeticsFactory>();
            var mockShoppingCart = new Mock<IShoppingCart>();
            mockShoppingCart.Setup(mock => mock.ContainsProduct(It.IsAny<IProduct>())).Returns(true);

            var mockCommand = new Mock<ICommand>();
            mockCommand.SetupGet(mock => mock.Name).Returns("RemoveFromShoppingCart");
            mockCommand.SetupGet(mock => mock.Parameters).Returns(new List<string>() { "Product" });

            var mockCommandParser = new Mock<ICommandParser>();
            mockCommandParser.Setup(mock => mock.ReadCommands()).Returns(new List<ICommand>() { mockCommand.Object });

            var cosmeticsEngine = new ExposedCategoriesAndProductsMockCosmeticsEngine(mockFactory.Object, mockShoppingCart.Object, mockCommandParser.Object);
            cosmeticsEngine.Products.Add("Product", null);

            cosmeticsEngine.Start();

            mockShoppingCart.Verify(mock => mock.RemoveProduct(It.IsAny<IProduct>()), Times.Once());
        }
    }
}
