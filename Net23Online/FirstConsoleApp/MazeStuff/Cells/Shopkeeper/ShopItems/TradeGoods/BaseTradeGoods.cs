using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods.Interfaces;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods
{
    internal abstract class BaseTradeGoods : BaseShopItem, IBaseTradeGoods
    {
        protected int _unitPrice { get; set; }
        public int UnitPrice => _unitPrice;
        protected int _count { get; set; }
        public int Count => _count;

        protected BaseTradeGoods(int unitPrice, int count)
        {
            _unitPrice = unitPrice;
            _count = count;
        }
    }
}
