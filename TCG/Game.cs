using System.Collections.Generic;

namespace TCG.Tests
{
    public class Game
    {
        private List<Player> players;
        private Hand hand;
        private CardMixer cardMixer;
        private ICardManager cardManager;
        private Round round;

        public Game()
        {
            cardManager = new CleanDeck();
            this.players = new List<Player>()
                               {
                                   new Player("Player"),
                                   new Player("Computer") {IsNpc = true}
                               };

            HumanPlayer = players[0];
            ComputerPlayer = players[1];

            StartNewHand();
        }

        private void StartNewHand()
        {
            this.hand = new Hand(players);
            this.cardMixer = new CardMixer(cardManager);
            this.round = new Round(cardManager);
            this.hand.TurnedCard = cardMixer.Raffle();

            foreach (var player in players)
                player.Cards = cardMixer.Raffle(3);
        }


        public Player HumanPlayer { get; private set; }
        public Player ComputerPlayer { get; set; }

        public Player RoundWinner { get; private set; }

        public void Play(Card card)
        {
            if (IsRoundEnd())
                throw new TrucoException("Cannot play when round is over.");

            HumanPlayer.SelectedCard = card;
            if (ComputerPlayer.SelectedCard == null)
                ComputerPlayer.SelectedCard = new Card('2', 'C');

            var winner = round.Play(HumanPlayer, ComputerPlayer, this.hand.TurnedCard);
            if (winner == null)
                hand.Draw();
            else
                hand.Winner(winner);
            RoundWinner = winner;
        }

        public bool IsRoundEnd()
        {
            return HumanPlayer.SelectedCard != null && ComputerPlayer.SelectedCard != null;
        }

        public void StartNewRound()
        {
            HumanPlayer.SelectedCard = null;
            ComputerPlayer.SelectedCard = null;
        }
    }
}