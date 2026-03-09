using FirstConsoleApp.GuessTheNumberStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.Minesweeper
{
    public class EasyMode : BaseMinesweeper
    {
        protected override void ConigurateGameRule()
        {
            _rule.FieldHeight = 9;
            _rule.FieldWidth = 9;
            _rule.NumberOfBombs = 10;
        }
    }
}
