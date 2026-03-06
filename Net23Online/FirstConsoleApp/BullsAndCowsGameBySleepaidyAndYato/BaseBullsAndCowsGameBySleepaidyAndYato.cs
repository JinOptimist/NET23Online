using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato
{
    public abstract class BaseBullsAndCowsGameBySleepaidyAndYato
    {
        protected int TakeTheNumberFromConsoleForBullsAndCows()
        {
            Console.WriteLine("Please enter a four-digit number with unique digits.");
            var NumberFromConsoleForBullsAndCows = Console.ReadLine();
            Console.WriteLine(NumberFromConsoleForBullsAndCows);
            return 1;
        }
    }
}
