namespace Cosmetics.MyTests.Engine
{
    using System.Collections.Generic;

    using Moq;
    using NUnit.Framework;

    using Cosmetics.Contracts;
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

        //Start should read, parse and execute "AddToCategory" command, when the passed input string is in the format that represents a AddToCategory command, which should result in adding the selected product in the respective category.

        //Start should read, parse and execute "RemoveFromCategory" command, when the passed input string is in the format that represents a RemoveFromCategory command, which should result in removing the selected product from the respective category.

        //Start should read, parse and execute "ShowCategory" command, when the passed input string is in the format that represents a ShowCategory command, which should result in calling the Print() method of the respective cateogry.

        //Start should read, parse and execute "CreateShampoo" command, when the passed input string is in the format that represents a CreateShampoo command, which should result in adding the newly created shampoo in the list of products.

        //Start should read, parse and execute "CreateToothpaste" command, when the passed input string is in the format that represents a CreateToothpaste command, which should result in adding the newly created toothpaste in the list of products.

        //Start should read, parse and execute "AddToShoppingCart" command, when the passed input string is in the format that represents a AddToShoppingCart command, which should result in adding the selected product to the shopping cart.

        //Start should read, parse and execute "RemoveFromShoppingCart" command, when the passed input string is in the format that represents a RemoveFromShoppingCart command, which should result in removing the selected product from the shopping cart.
    }
}
