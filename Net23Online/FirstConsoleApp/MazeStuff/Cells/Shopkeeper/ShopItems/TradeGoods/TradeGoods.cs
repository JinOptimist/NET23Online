using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods
{
    internal abstract class TradeGoods : ShopItem
    {
        protected int _unitPrice { get; set; }
        protected int _count { get; set; }

        protected TradeGoods(int unitPrice, int count) 
        {
            _unitPrice = unitPrice;
            _count = count;
        }
    }
}
