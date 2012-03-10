using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCG
{
    public class Hand
    {
        private List<Player> players;
        private Dictionary<Player, int> scoreBoard = new Dictionary<Player, int>();

        public Hand(List<Player> players)
        {            
            this.players = players;
            ActivePlayer = players[0];
            StartScoreBoard();
        }

        private void StartScoreBoard()
        {
            foreach (var player in players)            
                scoreBoard.Add(player,0);            
        }

        public bool IsOver { get; set; }

        public Player ActivePlayer { get; set; }

        public Card TurnedCard { get; set; }

        public void Winner(Player player)
        {
            SetScore(player, 3);
        }

        private void SetScore(Player player, int score)
        {
            scoreBoard[player] += score;

            IsOver = scoreBoard.Count(x => x.Value > 3) > 0;
        }

        public int Score(Player player)
        {
            return scoreBoard[player];
        }

        public void Draw()
        {
            foreach (var player in players)            
                SetScore(player,1);            
        }

        public Player GetWinner()
        {
            if(!IsOver)
                throw new TrucoException("Cannot define a winner before the hand has over");

            return scoreBoard.First(x => x.Value > 3).Key;
        }
    }
}
