namespace ArmyOfCreatures.Tests.Extended
{
    using System.Collections.Generic;
    using System.Reflection;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Extended;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedBattleManagerTests
    {
        //Constructor should call base() constructor and instantiate the object
        //with all properties set up. (Use C# integrated PrivateObject class,
        //to expose private fields, so that you can assert, that the object was instantiated properly).
        [Test]
        public void Constructor_ShouldCallBaseConstructorAndInstntiateAllProperties()
        {
            var mockFactory = new Mock<ICreaturesFactory>();
            var mockLogger = new Mock<ILogger>();
            var manager = new ExtendedBattleManager(mockFactory.Object, mockLogger.Object);

            var actualFirstArmy = manager.GetType()
                .BaseType.GetField("firstArmyCreatures", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager);

            var actualSecondArmy = manager.GetType()
                .BaseType.GetField("secondArmyCreatures", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager);

            var actualICreaturesFactory = manager.GetType()
                .BaseType.GetField("creaturesFactory", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager);

            var actualILogger = manager.GetType()
                .BaseType.GetField("logger", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager);

            Assert.That(actualFirstArmy, Is.Not.Null.And.InstanceOf<ICollection<ICreaturesInBattle>>());
            Assert.That(actualSecondArmy, Is.Not.Null.And.InstanceOf<ICollection<ICreaturesInBattle>>());
            Assert.That(actualICreaturesFactory, Is.Not.Null.And.InstanceOf<ICreaturesFactory>());
            Assert.That(actualILogger, Is.Not.Null.And.InstanceOf<ILogger>());
        }
    }
}
