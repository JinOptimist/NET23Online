using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Services
{
    internal abstract class ShopkeeperService : ShopItem
    {
        protected int _unitPrice;
        protected ShopkeeperService(int unitPrice)
        {
            _unitPrice = unitPrice;
        }
    }
}
