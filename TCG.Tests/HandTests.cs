using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace TCG.Tests
{
    [TestFixture]
    public class HandTests
    {
        private List<Player> players;

        [SetUp]
        public void TestStartUp()
        {
            players = new List<Player>()
                          {
                              new Player("PlayerOne"),
                              new Player("PlayerTwo")
                          };
        }

        [Test]
        public void StartingAHand()
        {
            var hand = new Hand(players);

            hand.IsOver.Should().BeFalse();
        }

        [Test]
        public void ShouldBeTheFirstPlayerToStartAHand()
        {
            var hand = new Hand(players);

            hand.ActivePlayer.Should().Be(players[0]);
        }

        [Test]
        public void Scored3PointsAtVictory()
        {
            var hand = new Hand(players);

            hand.Winner(players[0]);

            hand.Score(players[0]).Should().Be(3);
        }

        [Test]
        public void HandEndAfterTheSamePlayerWin2TimesInARow()
        {
            var hand = new Hand(players);

            hand.Winner(players[0]);
            hand.Winner(players[0]);

            hand.IsOver.Should().BeTrue();
        } 
       
        [Test]
        public void HandWhenAPlayerWinAfterADraw()
        {
            var hand = new Hand(players);

            hand.Draw();
            hand.Winner(players[0]);

            hand.IsOver.Should().BeTrue();
        }   
     
        [Test]
        public void PlayerWinAfterWinLoseWin()
        {
            var hand = new Hand(players);

            hand.Winner(players[0]);
            hand.Winner(players[1]);
            hand.Winner(players[0]);

            hand.GetWinner().Should().Be(players[0]);
        }

        [Test]
        public void ThrowTrucoExceptionWhenTryToGetWinnerBeforeHandIsOver()
        {
            var hand = new Hand(players);

            hand.Winner(players[0]);
            hand.Winner(players[1]);
            try
            {
                hand.GetWinner().Should().Be(players[0]);
                Assert.Fail("Should throw an exception if try to get winner before hand has over");
            }
            catch (TrucoException ex)
            {
                ex.Message.Should().Be("Cannot define a winner before the hand has over");
            }
        }
    }
}
