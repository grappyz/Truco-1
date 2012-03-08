using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace TCG.Tests
{
    [TestFixture]
    public class RoundTests
    {
        private ICardManager cardManager;
        Card ThreeOfClubs = new Card('3', 'C');
        Card TwoOfHearts = new Card('2', 'H');
        Card AceOfSpades = new Card('A', 'S');
        Card KingOfDiamond = new Card('K', 'D');
        private Player player1 = new Player("PlayerOne");
        private Player player2 = new Player("PlayerTwo");

        [SetUp]
        public void TestsInitialize()
        {
            var cardManagerMock = new Mock<ICardManager>();

            cardManagerMock.Setup(x => x.GetCardValue(ThreeOfClubs, It.IsAny<Card>())).Returns(100);
            cardManagerMock.Setup(x => x.GetCardValue(TwoOfHearts, It.IsAny<Card>())).Returns(90);

            cardManager = cardManagerMock.Object;
        }

        [Test]
        public void Player1CardHigherThanPlayer2()
        {
            TestCards(ThreeOfClubs, TwoOfHearts, KingOfDiamond).Should().Be(player1);
        }

        [Test]
        public void Player1CardLowerThanPlayer2()
        {
            TestCards(TwoOfHearts, ThreeOfClubs, KingOfDiamond).Should().Be(player2);
        }

        [Test]
        public void ShouldBeNullWhenPlayer1AndPlayer2SelectedTheSameCard()
        {
            TestCards(ThreeOfClubs, ThreeOfClubs, KingOfDiamond).Should().BeNull("This is a Draw.");
        }
        

        private Player TestCards(Card player1Card, Card player2card, Card turnedCard)
        {
            var round = new Round(cardManager);

            player1.SelectedCard = player1Card;
            player2.SelectedCard = player2card;

            return round.Play(player1, player2, turnedCard);
        }
    }
}
