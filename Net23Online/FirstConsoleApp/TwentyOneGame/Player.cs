namespace FirstConsoleApp.TwentyOneGame
{
    public class Player : IPlayer
    {
        private Hand _hand;
        public string Name { get; }

        public Player(string name)
        {
            Name = name;
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
