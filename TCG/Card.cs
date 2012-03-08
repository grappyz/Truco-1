namespace TCG
{
    public class Card
    {
        public Card(char name, char symbol)
        {            
            this.Name = name;
            this.Symbol = symbol;
        }

        public char Symbol { get; private set; }

        public char Name { get; private set; }
    }
}