using FirstConsoleApp.GuessTheNumberStuff;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.BullsAndCowsGame
{

    internal class BullsAndCowsBot : BullsAndCowsGame
    {
        protected override void ConigurateGameRule()
        {
            var ruleGenerator = new RuleGenerator();
            ruleGenerator.SetRandomRule(_rule);
            _rule.Attempt = 20;
        }

    }
}