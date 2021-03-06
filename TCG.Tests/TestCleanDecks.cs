﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace TCG.Tests
{
    [TestFixture]
    public class TestCleanDecks
    {
        private Dictionary<char, int> nameValues = new Dictionary<char, int>()
                                                       {
                                                           {'Q',10},
                                                           {'J',20},
                                                           {'K',30},
                                                           {'A',40},
                                                           {'2',50},
                                                           {'3',60}
                                                       };

        public Dictionary<char, int> symbolValues = new Dictionary<char, int>()
                                                        {
                                                            {'D',100},
                                                            {'S',200},
                                                            {'H',300},
                                                            {'C',400}
                                                        };

        private ICardManager cardManager;

        [SetUp]
        public void TestsInitialize()
        {
            cardManager = new CleanDeck();
        }

        [Test]
        public void CheckCardNameValues()
        {
            foreach (var nameValue in nameValues)
            {
                var card = new Card(nameValue.Key, 'S');
                cardManager.GetCardValue(card, card).Should().Be(nameValues[nameValue.Key]);
            }
        }

        [Test]
        public void CheckManilha()
        {
            foreach (var symbol in symbolValues)
            {
                var card = new Card('2', symbol.Key);
                var turnedCard = new Card('A', 'S');
                cardManager.GetCardValue(card, turnedCard).Should().Be(symbolValues[symbol.Key]);
            }
        }

        [Test]
        public void ShouldThrowErroWithAnInexistentCard()
        {
            var inexistentCard = new Card('5', 'P');
            var turnedCard = new Card('A', 'S');

            try
            {
                cardManager.GetCardValue(inexistentCard, turnedCard);
                Assert.Fail("Should never get here with an Inexistent card");
            }
            catch (TrucoException ex)
            {
                ex.Message.Should().Be("The card does not exist.");
            }
        }

        [Test]
        public void DoNotConsiderManilhaWhenHasNotAnyTurnedCard()
        {
            foreach (var nameValue in nameValues)
            {
                var card = new Card(nameValue.Key, 'S');
                cardManager.GetCardValue(card, null).Should().Be(nameValues[nameValue.Key]);
            }
        }

        [Test]
        public void ShouldContains24Cards()
        {
            cardManager.Cards.Count().Should().Be(24);
        }

        [Test]
        public void ShouldContainsAllCards()
        {
            var cards = CreateCardDeck();

            foreach (var card in cards)
                cardManager.Cards.Contains(card).Should().BeTrue();
        }

        private IEnumerable<Card> CreateCardDeck()
        {
            return from symbolValue in symbolValues from nameValue in nameValues select new Card(nameValue.Key, symbolValue.Key);
        }
    }
}
