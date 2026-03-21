using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Services.Interfaces;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Services
{
    public abstract class IBaseShopkeeperService : BaseShopItem, IIBaseShopkeeperService
    {
        protected int _unitPrice;
        public int UnitPrice => _unitPrice;
        public override string PriceDisplay => $"Cost:{_unitPrice}";
        protected IBaseShopkeeperService(int unitPrice)
        {
            _unitPrice = unitPrice;
        }

    }
}
