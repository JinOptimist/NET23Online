namespace FirstConsoleApp.TwentyOneGame
{
    public class Card
    {
        public Suit CardSuit;
        public Rank CardRank;

        public Card(Suit suit, Rank rank)
        {
            CardSuit = suit;
            CardRank = rank;
        }

        public int GetCardValue()
        {
            return (int)CardRank;
        }

        public override string ToString()
        {
            string rankText = "";

            if (CardRank >= Rank.Six && CardRank <= Rank.Ten)
            {
                rankText = ((int)CardRank).ToString();
            }
            else if (CardRank == Rank.Jack)
            {
                rankText = "J";
            }
            else if (CardRank == Rank.Queen)
            {
                rankText = "Q";
            }
            else if (CardRank == Rank.King)
            {
                rankText = "K";
            }
            else if (CardRank == Rank.Ace)
            {
                rankText = "A";
            }

            string suitText = "";

            switch (CardSuit)
            {
                case Suit.Hearts:
                    suitText = "♥";
                    break;
                case Suit.Diamonds:
                    suitText = "♦";
                    break;
                case Suit.Clubs:
                    suitText = "♣";
                    break;
                case Suit.Spades:
                    suitText = "♠";
                    break;
                default:
                    break;
            }

            return rankText + suitText;
        }
    }
}
