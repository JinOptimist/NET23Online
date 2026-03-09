using FirstConsoleApp.Interfaces;

namespace FirstConsoleApp.BullsAndCowsGame
{
    public class HiddenNumber
    {
        public string Value { get; }
        public IGameSettings Settings { get; }

        public HiddenNumber(IGameSettings settings, IRandomNumberGenerator randomNumberGenerator)
        {
            Settings = settings;
            Value = randomNumberGenerator.GenerateNumber(settings);
        }

        public GuessResult CheckGuess(string guess)
        {
            ValidateGuess(guess);

            var guessResult = new GuessResult();

            var hiddenNumberCount = new int[10];
            var guessNumberCount = new int[10];

            for (var i = 0; i < Value.Length; i++)
            {
                var hiddenDigit = Value[i] - '0';
                var guessDigit = guess[i] - '0';

                if (hiddenDigit == guessDigit)
                {
                    guessResult.Bulls++;
                }
                else
                {
                    hiddenNumberCount[hiddenDigit]++;
                    guessNumberCount[guessDigit]++;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                guessResult.Cows += Math.Min(hiddenNumberCount[i], guessNumberCount[i]);
            }


            return guessResult;
        }

        private void ValidateGuess(string guess)
        {
            if (guess.Length != Settings.NumberLength)
            {
                throw new ArgumentException($"Number must contain {Settings.NumberLength} digits.");
            }
                
            if (!guess.All(char.IsDigit))
            {
                throw new ArgumentException("Input must contain only digits.");
            }

            if (guess[0] == '0')
            {
                throw new ArgumentException("First digit cannot be zero.");
            }
                
            if (guess.Distinct().Count() != guess.Length)
            {
                throw new ArgumentException("Digits must not repeat.");
            }
                
        }
    }
}