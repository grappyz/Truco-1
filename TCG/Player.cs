namespace TCG
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        protected string Name { get; set; }

        public Card SelectedCard { get; set; }
    }
}