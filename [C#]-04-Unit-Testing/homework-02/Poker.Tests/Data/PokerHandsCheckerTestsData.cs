namespace Poker.Tests.Data
{
    using System.Collections;
    using System.Collections.Generic;

    using NUnit.Framework;

    using Poker.Tests.Fakes;

    public class PokerHandsCheckerTestsData
    {
        public const string IsFlushAllSuitsCasesAsString = "IsFlushAllSuitsCases";
        public const string IsFourOfAKindAllFacesCasesAsString = "IsFourOfAKindAllFacesCases";

        public static IEnumerable IsFlushAllSuitsCases
        {
            get
            {
                yield return new TestCaseData(new FakeHand(new List<ICard>()
                {
                    new FakeCard(CardFace.Ace, CardSuit.Clubs),
                    new FakeCard(CardFace.King, CardSuit.Clubs),
                    new FakeCard(CardFace.Two, CardSuit.Clubs),
                    new FakeCard(CardFace.Six, CardSuit.Clubs),
                    new FakeCard(CardFace.Ten, CardSuit.Clubs)

                })).Returns(true);

                yield return new TestCaseData(new FakeHand(new List<ICard>()
                {
                    new FakeCard(CardFace.Ace, CardSuit.Diamonds),
                    new FakeCard(CardFace.King, CardSuit.Diamonds),
                    new FakeCard(CardFace.Two, CardSuit.Diamonds),
                    new FakeCard(CardFace.Six, CardSuit.Diamonds),
                    new FakeCard(CardFace.Ten, CardSuit.Diamonds)

                })).Returns(true);

                yield return new TestCaseData(new FakeHand(new List<ICard>()
                {
                    new FakeCard(CardFace.Ace, CardSuit.Hearts),
                    new FakeCard(CardFace.King, CardSuit.Hearts),
                    new FakeCard(CardFace.Two, CardSuit.Hearts),
                    new FakeCard(CardFace.Six, CardSuit.Hearts),
                    new FakeCard(CardFace.Ten, CardSuit.Hearts)

                })).Returns(true);

                yield return new TestCaseData(new FakeHand(new List<ICard>()
                {
                    new FakeCard(CardFace.Ace, CardSuit.Spades),
                    new FakeCard(CardFace.King, CardSuit.Spades),
                    new FakeCard(CardFace.Two, CardSuit.Spades),
                    new FakeCard(CardFace.Six, CardSuit.Spades),
                    new FakeCard(CardFace.Ten, CardSuit.Spades)

                })).Returns(true);

                yield return new TestCaseData(new FakeHand(new List<ICard>()
                {
                    new FakeCard(CardFace.Ace, CardSuit.Spades),
                    new FakeCard(CardFace.King, CardSuit.Spades),
                    new FakeCard(CardFace.Two, CardSuit.Spades),
                    new FakeCard(CardFace.Six, CardSuit.Spades),
                    new FakeCard(CardFace.Ten, CardSuit.Hearts)

                })).Returns(false);

                yield return new TestCaseData(new FakeHand(new List<ICard>()
                {
                    new FakeCard(CardFace.Ace, CardSuit.Spades),
                    new FakeCard(CardFace.King, CardSuit.Spades),
                    new FakeCard(CardFace.Queen, CardSuit.Spades),
                    new FakeCard(CardFace.Jack, CardSuit.Spades),
                    new FakeCard(CardFace.Ten, CardSuit.Spades)

                })).Returns(false);
            }
        }

        public static IEnumerable IsFourOfAKindAllFacesCases
        {
            get
            {
                for (int faceValueAsInt = 2; faceValueAsInt <= 14; faceValueAsInt++)
                {
                    yield return new TestCaseData(new FakeHand(new List<ICard>()
                    {
                        new FakeCard((CardFace)faceValueAsInt, CardSuit.Clubs),
                        new FakeCard((CardFace)faceValueAsInt, CardSuit.Diamonds),
                        new FakeCard((CardFace)faceValueAsInt, CardSuit.Hearts),
                        new FakeCard((CardFace)faceValueAsInt, CardSuit.Spades),
                        new FakeCard(faceValueAsInt == 10 ? CardFace.Four : CardFace.Ten, CardSuit.Clubs)

                    })).Returns(true);
                }
            }
        }
    }
}
