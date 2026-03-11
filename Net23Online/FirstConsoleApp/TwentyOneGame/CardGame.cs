namespace FirstConsoleApp.TwentyOneGame
{
    public class CardGame
    {
        private Deck _deck;
        private IPlayer _dealer;
        private IPlayer _player;

        public CardGame()
        {
            _deck = new Deck();
            _dealer = new Dealer("Dealer");
        }


        public void Start()
        {
            InitializePlayer();
            DisplayGreeting();
            while (true)
            {
                Run();

                Console.WriteLine("\n--- Do you want to play again? ---");
                Console.Write("Press (Y) to play again or any other key to exit: ");
                string choice = Console.ReadLine();

                if (choice.ToLower() == "y" || choice.ToLower() == "д")
                {
                    ResetGame();
                    Console.Clear();
                    Console.WriteLine("=== New Game ===\n");
                }
                else
                {
                    Console.WriteLine("\nThanks for playing! Goodbye.");
                    break;
                }
            }
        }

        private void ResetGame()
        {
            _player.ClearHand();
            _dealer.ClearHand();
            _deck.ResetDeck();
        }

        private void InitializePlayer()
        {
            Console.WriteLine("Please enter your name before starting the game:");
            string userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "Anonymous";
            }

            _player = new Player(userName);
        }

        private void DisplayGreeting()
        {
            Console.WriteLine($"Hello, {_player.Name}! Welcome to our game.");
            Console.WriteLine("-------------------------------------------");
        }

        private void Run()
        {
            Console.WriteLine("=== Game Start ===");

            _player.TakeCard(_deck);
            _player.TakeCard(_deck);
            _dealer.TakeCard(_deck);
            _dealer.TakeCard(_deck);

            PlayerTurns();
            DealerTurns();
            Console.WriteLine("\n=== Final Results ===");
            Console.WriteLine("Your cards: " + _player.GetCards());
            Console.WriteLine($"Your score: {_player.GetScore()}");

            Console.WriteLine("Dealer cards: " + _dealer.GetCards());
            Console.WriteLine($"Dealer score: {_dealer.GetScore()}");

            DetermineWinner();

            Console.WriteLine("Do you want to play again?");
            Console.WriteLine("\n=== Game End ===");
        }

        private void PlayerTurns()
        {
            while (true)
            {
                Console.WriteLine("\nYour cards: " + _player.GetCards());
                Console.WriteLine($"Your score: {_player.GetScore()}");

                if (_player.GetScore() > 21)
                {
                    Console.WriteLine("\n>>> BUST! You went over 21. You lose.");
                    return;
                }

                Console.Write("Take card (1) or Stand (2)? ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    _player.TakeCard(_deck);
                }
                else if (choice == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, please choose 1 or 2.");
                }
            }
        }

        private void DealerTurns()
        {
            Console.WriteLine("\n--- Dealer's Turn ---");
            while (_dealer.GetScore() < 17)
            {
                _dealer.TakeCard(_deck);
                Console.WriteLine("Dealer takes a card...");
            }
        }

        private void DetermineWinner()
        {
            int playerScore = _player.GetScore();
            int dealerScore = _dealer.GetScore();

            if (dealerScore > 21)
            {
                Console.WriteLine("\n>>> Dealer BUST! You Win!");
                return;
            }

            if (playerScore > dealerScore)
            {
                Console.WriteLine("\n>>> Congratulations! You Win!");
            }
            else if (playerScore < dealerScore)
            {
                Console.WriteLine("\n>>> Dealer Wins. Better luck next time.");
            }
            else
            {
                Console.WriteLine("\n>>> It's a Draw (Push)!");
            }
        }
    }
}
