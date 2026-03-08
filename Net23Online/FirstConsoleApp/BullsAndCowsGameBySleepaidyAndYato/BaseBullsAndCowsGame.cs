using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato
{
    public abstract class BaseBullsAndCowsGame
    {
        protected Player _player;

        public void Play()
        {

        }

        
        protected string TakeTheNumberFromConsoleForBullsAndCows()
        {
            var numberFromConsoleForBullsAndCows = "";
            var isPlayerEnteredCorrectDigit = false;
            do
            {
                Console.WriteLine("Please enter a four-digit number with unique digits.");
                numberFromConsoleForBullsAndCows = Console.ReadLine();
                if (!numberFromConsoleForBullsAndCows.All(char.IsDigit) || numberFromConsoleForBullsAndCows.Length != 4)
                {
                    Console.WriteLine("Incorrect input. Please try again.");
                }
                else if (numberFromConsoleForBullsAndCows.Distinct().Count() != 4)
                {
                    Console.WriteLine("The input contains non-unique numbers. Please try again.");
                }
                else
                {
                    isPlayerEnteredCorrectDigit = true;
                }    

            } while (!isPlayerEnteredCorrectDigit);


            return numberFromConsoleForBullsAndCows;
        }
    }
}
