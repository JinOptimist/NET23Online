using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Services
{
    internal abstract class BaseShopkeeperService : BaseShopItem
    {
        protected int _unitPrice;
        protected BaseShopkeeperService(int unitPrice)
        {
            _unitPrice = unitPrice;
        }
    }
}
