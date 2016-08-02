namespace ArmyOfCreatures.Tests.Logic.Specialties
{
    using System;

    using Moq;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Tests.Fakes;

    [TestFixture]
    public class ResurrectionTests
    {
        [Test]
        public void ApplyAfterDefending_ShouldThrowWithCorrectMessage_IfDefenderWithSpecialtyParamenterIsNull()
        {
            ICreaturesInBattle defenderWithSpecialty = null;
            var specialty = new Resurrection();

            var exception = Assert.Throws<ArgumentNullException>(() => specialty.ApplyAfterDefending(defenderWithSpecialty));
            StringAssert.Contains("defenderWithSpecialty", exception.Message);
        }

        [Test]
        public void ApplyAfterDefending_ShouldNotSetDefenderWithSpecialtyTotalHitPoints_WhenTotalHitPointsAreLessThanOrEqualToZero()
        {
            var defenderWithSpecialty = new Mock<ICreaturesInBattle>();
            defenderWithSpecialty.SetupGet(mock => mock.TotalHitPoints).Returns(0);
            defenderWithSpecialty.SetupSet(mock => mock.TotalHitPoints = It.IsAny<int>());

            var specialty = new Resurrection();

            specialty.ApplyAfterDefending(defenderWithSpecialty.Object);

            defenderWithSpecialty.VerifySet(mock => mock.TotalHitPoints = It.IsAny<int>(), Times.Never());
        }

        [Test]
        public void AppleyAfterDefending_ShouldSetDefenderWithSpecialtyTotalHitPoiints_WhenTotalHitPointsIsLargerThanZero()
        {
            var stubCreature = new FakeCreature();
            var defenderWithSpecialty = new Mock<ICreaturesInBattle>();
            defenderWithSpecialty.SetupGet(mock => mock.Count).Returns(1);
            defenderWithSpecialty.SetupGet(mock => mock.Creature).Returns(stubCreature);
            defenderWithSpecialty.SetupGet(mock => mock.TotalHitPoints).Returns(10);
            defenderWithSpecialty.SetupSet(mock => mock.TotalHitPoints = It.IsAny<int>());
            var specialty = new Resurrection();

            specialty.ApplyAfterDefending(defenderWithSpecialty.Object);

            defenderWithSpecialty.VerifySet(mock => mock.TotalHitPoints = It.IsAny<int>(), Times.Once());
        }
    }
}
