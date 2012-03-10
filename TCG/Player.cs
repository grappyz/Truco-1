using System.Collections.Generic;

namespace TCG
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public Card SelectedCard { get; set; }

        public bool IsNpc { get; set; }

        public List<Card> Cards { get; set; }
    }
}