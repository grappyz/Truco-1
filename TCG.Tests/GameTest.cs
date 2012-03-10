using System;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace TCG.Tests
{
    [TestFixture]
    public class GameTest
    {

        [Test]
        public void PlayerShouldReceive3CardsWhenANewGameStarts()
        {
            var game = new Game();

            game.HumanPlayer.Cards.Count.Should().Be(3);
        }

        [Test]
        public void AfterPlayerComputerShouldPlay()
        {
            var game = new Game();
            var card = new Card('3','C');

            game.Play(card);

            game.IsRoundEnd().Should().BeTrue();
        }

        [Test]
        public void ShouldThrowATrucoexceptionIfPlayWhenRoundIsOver()
        {
            var game = new Game();
            var card = new Card('3', 'C');

            game.Play(card);

            try
            {
                game.Play(card);
                Assert.Fail("Should throw an exception because round is over");
            }
            catch (TrucoException ex)
            {
                ex.Message.Should().Be("Cannot play when round is over.");
            }
        }

        [Test]
        public void StartANewRound()
        {
            var game = new Game();
            var card = new Card('3', 'C');

            game.Play(card);
            game.StartNewRound();

            game.IsRoundEnd().Should().BeFalse();
        }

        [Test]
        public void ComputerShouldWinTheFirstRound()
        {
            var game = new Game();
            var card = new Card('Q', 'C');

            game.Play(card);

            game.RoundWinner.Name.Should().Be("Computer");
        }
    }
}
