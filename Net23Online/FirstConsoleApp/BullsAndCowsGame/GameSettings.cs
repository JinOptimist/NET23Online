using FirstConsoleApp.Interfaces;

namespace FirstConsoleApp.BullsAndCowsGame
{
    public class GameSettings : IGameSettings
    {
        public int MinValue { get; }
        public int MaxValue { get; }
        public int NumberLength { get; }

        public GameSettings(int minValue, int maxValue)
        {
            if (minValue >= maxValue)
            {
                throw new ArgumentException("MinValue must be less than MaxValue");
            }

            MinValue = minValue;
            MaxValue = maxValue;
            NumberLength = minValue.ToString().Length;
        }

        public static GameSettings ChooseDifficulty()
        {
            while (true)
            {
                Console.WriteLine("Choose difficulty:");
                Console.WriteLine("1 - Easy (3 digits)");
                Console.WriteLine("2 - Medium (4 digits)");
                Console.WriteLine("3 - Hard (5 digits)");

                var choice = Console.ReadLine();

                try
                {
                    var settings = CreateDifficultyForGame(choice);
                    Console.WriteLine($"You've chosen {settings.NumberLength}-digits difficulty");
                    return settings;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}. Try again.");
                }
            }
        }

        private static GameSettings CreateDifficultyForGame(string difficulty)
        {
            return difficulty switch
            {
                "1" => new GameSettings(100, 999),
                "2" => new GameSettings(1000, 9999),
                "3" => new GameSettings(10000, 99999),
                _ => throw new ArgumentException("Wrong key. Choose 1, 2 or 3.")
            };
        }
    }
}