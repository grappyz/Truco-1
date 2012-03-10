using System;
using System.Collections.Generic;
using System.Linq;

namespace TCG
{
    public class CardMixer
    {
        private Random random;
        private List<Card> cards;

        public CardMixer(ICardManager cardDeck)
        {
            cards = cardDeck.Cards.ToList();
            random = new Random();
        }

        public virtual Card Raffle()
        {
            if(cards.Count < 1)
                throw new TrucoException("Does not have enought cards.");

            var raffledCard = cards[random.Next(0, cards.Count)];

            cards.Remove(raffledCard);

            return raffledCard;
        }

        public IEnumerable<Card> Cards
        {
            get { return cards.AsEnumerable(); }
        }

        public List<Card> Raffle(int quantity)
        {
            var raffledCards = new List<Card>();

            for (int i = 0; i < quantity; i++)
                raffledCards.Add(Raffle());

            return raffledCards;
        }
    }
}