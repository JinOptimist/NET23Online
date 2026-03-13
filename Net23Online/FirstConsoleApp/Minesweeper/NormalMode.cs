using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.Minesweeper
{
    public class NormalMode : BaseMinesweeper
    {
        protected override void ConigurateGameRule()
        {
            _rule.FieldHeight = 16;
            _rule.FieldWidth = 16;
            _rule.NumberOfBombs = 40;
        }

    }
}
