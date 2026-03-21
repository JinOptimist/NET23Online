using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods
{
    internal abstract class BaseTradeGoods : BaseShopItem
    {
        protected int _unitPrice { get; set; }
        protected int _count { get; set; }

        protected BaseTradeGoods(int unitPrice, int count)
        {
            _unitPrice = unitPrice;
            _count = count;
        }
    }
}
