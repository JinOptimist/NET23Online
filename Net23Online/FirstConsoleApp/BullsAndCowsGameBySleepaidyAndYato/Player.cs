using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato
{
    public abstract class Player
    {
        public Player()
        {
           
        }
        public abstract string MakeGuess();

        public abstract void ProcessGuessResult(int Bulls, int Cows);
    }
}
