namespace FirstConsoleApp.TwentyOneGame
{
    public class Dealer : IPlayer
    {
        private Hand _hand;
        private string _name;

        public string Name { get { return _name; } }

        public Dealer(string name)
        {
            _name = name;
            _hand = new Hand();
        }

        public void TakeCard(Deck deck)
        {
            _hand.AddCard(deck.GetCard());
        }

        public int GetScore()
        {
            return _hand.GetScore();
        }

        public void ClearHand()
        {
            _hand.Clear();
        }

        public string GetCards()
        {
            return _hand.ToString();
        }
    }
}
