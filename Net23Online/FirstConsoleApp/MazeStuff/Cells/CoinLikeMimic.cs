using FirstConsoleApp.MazeStuff.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class CoinLikeMimic : Mimic
    {
        public CoinLikeMimic(IMaze maze) : base(maze)
        {
        }

        public override char Symbol => Coin.SYMBOL;
    }
}
