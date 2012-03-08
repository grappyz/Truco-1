using System.Collections.Generic;

namespace TCG
{
    public interface ICardManager
    {
        IEnumerable<Card> Cards { get; }
        int GetCardValue(Card selectedCard, Card turnedCard);
    }
}