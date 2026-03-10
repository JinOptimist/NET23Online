namespace FirstConsoleApp.TwentyOneGame
{
    public class Hand
    {
        private List<Card> _cards;

        public Hand()
        {
            _cards = new List<Card>();
        }

        public void Clear()
        {
            _cards.Clear();
        }

        public List<Card> GetCards()
        {
            return _cards;
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public int GetScore()
        {
            int score = 0;
            for (int i = 0; i < _cards.Count; i++)
            {
                score += _cards[i].GetCardValue();
            }
            return score;
        }


        public override string ToString()
        {
            return string.Join(", ", _cards);
        }
    }
}
