namespace TCG
{
    public class Card
    {
        public Card(char name, char symbol)
        {            
            this.Name = name;
            this.Symbol = symbol;
        }

        public override bool Equals(object obj)
        {
            var cardObj = (Card) obj;

            return cardObj.Name == Name && cardObj.Symbol == Symbol;
        }

        public char Symbol { get; private set; }

        public char Name { get; private set; }
    }
}