using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.BullsAndCowsGame
{
    internal class RuleGenerator
    {
        public void SetRandomRule(GameRule gameRule)
        {
            var random = new Random();
            var PossibleNumbers = new List<int> {0,1,2,3,4,5,6,7,8,9};
            PossibleNumbers.Remove(0);
            int index1 = random.Next(PossibleNumbers.Count);
            gameRule.FullNumber[0] = PossibleNumbers[index1];
            PossibleNumbers.Add(0);
            PossibleNumbers.RemoveAt(index1);
            int index2 = random.Next(PossibleNumbers.Count);
            gameRule.FullNumber[1] = PossibleNumbers[index2];
            PossibleNumbers.RemoveAt(index2);
            int index3 = random.Next(PossibleNumbers.Count);
            gameRule.FullNumber[2] = PossibleNumbers[index3];
            PossibleNumbers.RemoveAt(index3);
            int index4 = random.Next(PossibleNumbers.Count);
            gameRule.FullNumber[3] = PossibleNumbers[index4];


        }
    }
}
