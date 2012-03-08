using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace TCG.Tests
{
    [TestFixture]
    public class IntegratedRoundAndCleanDeckTests
    {
        private Round round;
        private Card turnedCard = new Card('A', 'S');
        private Card HigherManilha = new Card('2','C');
        private Card LowerManilha = new Card('2','S');
        private Card ThreeOfClubs = new Card('3','C');
        private Player player1 = new Player("Player One");
        private Player player2 = new Player("Player Two");

        [SetUp]
        public void TestInitialize()
        {
            round = new Round(new CleanDeck());
        }

        [Test]
        public void HigherManilhaWins()
        {
            player1.SelectedCard = HigherManilha;
            player2.SelectedCard = LowerManilha;

            round.Play(player1, player2, turnedCard).Should().Be(player1);
        }

        [Test]
        public void LowerManilhaWinsHigherCardName()
        {
            player1.SelectedCard = LowerManilha;
            player2.SelectedCard = ThreeOfClubs;

            round.Play(player1, player2, turnedCard).Should().Be(player1);
        }

        [Test]
        public void ShouldBeNullWhenADraw()
        {
            player1.SelectedCard = ThreeOfClubs;
            player2.SelectedCard = ThreeOfClubs;

            round.Play(player1, player2, turnedCard).Should().BeNull();
        }
    }
}
