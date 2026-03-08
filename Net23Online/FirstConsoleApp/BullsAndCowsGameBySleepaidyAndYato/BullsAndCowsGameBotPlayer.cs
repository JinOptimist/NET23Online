using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato
{
    public class BullsAndCowsGameBotPlayer : BaseBullsAndCowsGame
    {
        BullsAndCowsGameBotPlayer()
        {
            this._player = new BotPlayer();
        }
    }
}
