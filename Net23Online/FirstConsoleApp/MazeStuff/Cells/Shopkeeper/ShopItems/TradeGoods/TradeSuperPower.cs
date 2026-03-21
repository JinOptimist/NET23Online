using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods
{
    internal class TradeSuperPower : BaseTradeGoods
    {
        public TradeSuperPower(int unitPrice, int count) : base(unitPrice, count)
        {
            Name = "Super Power";
        }

        public override void Execute(IBaseCharacter character)
        {
            var superPowerCount = MenuForShop.MenuItems
                .OfType<TradeSuperPower>()
                .FirstOrDefault()?._count;
            if (superPowerCount != null)
            {
                if (character.Coins > 0 && superPowerCount > 0)
                {
                    character.Coins--;
                    character.SuperPower++;
                    MenuForShop.ShopHistory.Add("You bought 1 SuperPower");
                }
                else
                {
                    MenuForShop.ShopHistory.Add("You don't have any coin");
                }
            }
        }
    }
}
