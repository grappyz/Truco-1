using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace TCG.Tests
{
    [TestFixture]
    public class TestCardMixer
    {
        private ICardManager cardDeck;

        [SetUp]
        public void TestStartUp()
        {
            var cardDeckMock = new Mock<ICardManager>();
            cardDeckMock.Setup(x => x.Cards).Returns(CreateCards());
            cardDeck = cardDeckMock.Object;
        }

        private IEnumerable<Card> CreateCards()
        {
            var cards = new List<Card>()
                            {
                                new Card('3','C'),
                                new Card('3','H'),
                                new Card('3','S'),
                                new Card('3','D')
                            };

            return cards.AsEnumerable();
        }

        [Test]
        public void RaffleACard()
        {
            var cardMixer = new CardMixer(cardDeck);

            cardDeck.Cards.Contains(cardMixer.Raffle()).Should().BeTrue();
        }

        [Test]
        public void AfterRaffleACardShouldRemoveFromCardMixerDeck()
        {
            var cardMixer = new CardMixer(cardDeck);
            var raffledCard = cardMixer.Raffle();

            cardMixer.Cards.Contains(raffledCard).Should().BeFalse();
        }

        [Test]
        public void ThrowATrucoExceptionIfRaffledMoreThenCardsTotal()
        {
            var cardMixer = new CardMixer(cardDeck);

            for (int i = 0; i < cardDeck.Cards.Count(); i++)            
                cardMixer.Raffle();

            try
            {
                cardMixer.Raffle();
                Assert.Fail("Should throw TrucoExecption because was raffled more then Cards Total");
            }
            catch (TrucoException ex)
            {
                ex.Message.Should().Be("Does not have enought cards.");
            }
        }
    }
}
