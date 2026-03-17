using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods
{
    internal abstract class TradeGood : ShopItem
    {
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
