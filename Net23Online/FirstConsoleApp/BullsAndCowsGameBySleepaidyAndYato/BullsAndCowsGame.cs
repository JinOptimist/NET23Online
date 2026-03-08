using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato
{
    public class BullsAndCowsGame
    {
        public int Round { get; private set; }
        protected Player _player { get; set; }
        protected int amountBulls { get; private set; }
        protected int amountCows { get; private set; }
        public void Play()
        {

        }
        public BullsAndCowsGame(Player player)
        {
            this.Round = 0;
            this._player = player;
            if (_player is BotPlayer botPlayer)
            {
                botPlayer.SetGame(this);
            }
        }
        private void PlayOneRound()
        {
            var isPlayerEnteredCorrectDigits = false;
            var enteredDigitsFromPlayer = "";
            do
            {
                enteredDigitsFromPlayer = TakeTheNumberFromConsoleForBullsAndCows();
                isPlayerEnteredCorrectDigits = IsEnteredNumberCorrect(enteredDigitsFromPlayer);
            } while (!isPlayerEnteredCorrectDigits);
            var guessedDigitsFromPlayer = _player.MakeGuess();
            SearchForBullsAndCows(enteredDigitsFromPlayer, guessedDigitsFromPlayer);
            _player.ProcessGuessResult(amountBulls, amountCows);

        }

        protected string TakeTheNumberFromConsoleForBullsAndCows()
        {
            var numberFromConsoleForBullsAndCows = "";
            Console.WriteLine("Please enter a four-digit number with unique digits.");
            numberFromConsoleForBullsAndCows = Console.ReadLine();
            return numberFromConsoleForBullsAndCows;
        }
        protected bool IsEnteredNumberCorrect(string enteredDigits)
        {
            var isPlayerEnteredCorrectDigit = false;
            do
            {

                if (!enteredDigits.All(char.IsDigit) || enteredDigits.Length != 4)
                {
                    Console.WriteLine("Incorrect input. Please try again.");
                }
                else if (enteredDigits.Distinct().Count() != 4)
                {
                    Console.WriteLine("The input contains non-unique numbers. Please try again.");
                }
                else
                {
                    isPlayerEnteredCorrectDigit = true;
                }

            } while (!isPlayerEnteredCorrectDigit);


            return isPlayerEnteredCorrectDigit;
        }
        protected void SearchForBullsAndCows(string enteredDigits, string guessedDigits)
        {
            amountBulls = 0;
            amountCows = 0;

            bool[] isPlayerEnteredDigitsMatch = new bool[enteredDigits.Length];
            bool[] isPlayerGuessedDigitsMatch = new bool[guessedDigits.Length];

            for (int i = 0; i < enteredDigits.Length; i++)
            {
                if (enteredDigits[i] == guessedDigits[i])
                {
                    amountBulls++;
                    isPlayerEnteredDigitsMatch[i] = true;
                    isPlayerGuessedDigitsMatch[i] = true;
                }
            }
            for (int i = 0; i < enteredDigits.Length; i++)
            {
                if (isPlayerEnteredDigitsMatch[i])
                {
                    continue;
                }
                for (int j = 0; j < isPlayerGuessedDigitsMatch.Length; j++)
                {
                    if (isPlayerGuessedDigitsMatch[i])
                    {
                        continue;
                    }
                    if (isPlayerEnteredDigitsMatch[i] == isPlayerGuessedDigitsMatch[j])
                    {
                        amountCows++;
                        isPlayerEnteredDigitsMatch[i] = true;
                        isPlayerGuessedDigitsMatch[j] = true;
                        break;
                    }
                }
            }
        }
    }
}
