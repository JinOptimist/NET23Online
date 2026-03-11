namespace FirstConsoleApp.TwentyOneGame
{
    public class Deck
    {
        private List<Card> _cards;
        private Random _random = new Random();
        public Deck()
        {
            _cards = new List<Card>();
            ResetDeck();
        }

        private void AddCard()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    _cards.Add(new Card(suit, rank));
                }
            }

        }

        private void Shuffle()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                int randomIndex = _random.Next(_cards.Count);
                Card temp = _cards[i];
                _cards[i] = _cards[randomIndex];
                _cards[randomIndex] = temp;
            }
        }

        public Card GetCard()
        {
            if (_cards.Count == 0)
                return null;
            int randomIndex = _random.Next(_cards.Count);
            Card card = _cards[randomIndex];
            _cards.RemoveAt(randomIndex);
            return card;
        }

        public void ResetDeck()
        {
            _cards.Clear();
            AddCard();
            Shuffle();
            Console.WriteLine("Deck has been reset and shuffled.");
        }

    }
}
