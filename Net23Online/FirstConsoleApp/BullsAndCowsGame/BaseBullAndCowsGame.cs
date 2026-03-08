using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.BullsAndCowsGame
{

    public abstract class BullsAndCowsGame
    {

        protected GameRule _rule = new();
        private bool _isUserAreWinner = false;
        private int[] Number = new int[4];

        /// <summary>
        /// This is a main method to play The Cows and Bulls
        /// </summary>
        public void Play()
        {
            ConigurateGameRule();

            PlayOneRound();

            SayToUserTheGameResult();
        }
        /// <summary>
        /// This is a abstract method to enter GameRules
        /// </summary>
        protected abstract void ConigurateGameRule();
        /// <summary>
        /// This is a method to comparison of the mystery number with the entered one
        /// </summary>
        private void PlayOneRound()
        {
            int Attempt = 0;
            int Bulls;
            int Cows;
            for (int i = 0; i < 4; i++)
            {
                Number[i] = _rule.FullNumber[i];
            }
            do
            {
                Bulls = 0;
                Cows = 0;
                Attempt++;
                Console.WriteLine("Guess the four-digit number");
                int[] NumberGuess = new int[4];
                NumberGuess = GetNumberFromConsole($"Enter your Guess, {Attempt} attempt:");
                for (int i = 0; i < 4; i++)
                    for(int j = 0; j < 4; j++)
                    {
                        if(NumberGuess[i] == Number[j] && i == j)
                        {
                            Bulls++;
                        }
                        else if(NumberGuess[i] == Number[j])
                        {
                            Cows++;
                        }
                    }

                Console.WriteLine($"Cows: {Cows} Bulls: {Bulls}");
            if(Bulls == 4)
                {
                    _isUserAreWinner = true;
                }


            } while (Attempt < _rule.Attempt && !_isUserAreWinner);

        }
        /// <summary>
        /// This is a method to Outputting the game state
        /// </summary>
        private void SayToUserTheGameResult()
        {
            if (_isUserAreWinner)
            {
                Console.WriteLine("You are winner");
            }
            else
            {
                Console.WriteLine("Looser");
            }

            Console.WriteLine("The end");
        }
        /// <summary>
        /// This is a method to Enter Number from Console
        /// </summary>
        protected int[] GetNumberFromConsole(string messageForUser)
        {
            int[] Number = new int[4];
            bool AllDigits;
            do
            {
                AllDigits = true;
                Console.WriteLine(messageForUser);
                var guessStr = Console.ReadLine();

                if (guessStr.Length != 4)
                {
                    Console.WriteLine("You need to enter the four-digit number");
                }
                for (int i = 0; i < 4; i++)
                {
                    if (int.TryParse(guessStr[i].ToString(), out int Digit))
                    {

                        Number[i] = Digit;
                    }
                    else
                    {
                        AllDigits = false;
                    }
                }
                if (!AllDigits)
                {

                    Console.WriteLine("You need to enter the four-digit number");
                }

            } while (!AllDigits);
            return Number;

        }
    }
}