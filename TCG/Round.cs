namespace TCG
{
    public class Round
    {
        public Round(ICardManager cardManager)
        {
            CardManager = cardManager;
        }

        protected ICardManager CardManager { get; set; }

        public Player Play(Player player1, Player player2, Card turnedCard)
        {
            if (player1.SelectedCard == null || player2.SelectedCard == null || turnedCard == null)
                throw new TrucoException("Player Selected Card and Turned Card should not be null.");

            var player1CardValue = CardManager.GetCardValue(player1.SelectedCard, turnedCard);
            var player2CardValue = CardManager.GetCardValue(player2.SelectedCard, turnedCard);

            if (player1CardValue == player2CardValue)
                return null;

            return player1CardValue > player2CardValue ? player1 : player2;
        }
    }
}