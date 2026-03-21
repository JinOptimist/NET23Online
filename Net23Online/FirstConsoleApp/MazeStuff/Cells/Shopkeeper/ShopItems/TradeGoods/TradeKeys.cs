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
    internal class TradeKeys : BaseTradeGoods
    {
        public TradeKeys(int unitPrice, int count) : base(unitPrice, count)
        {
            Name = "Key";
        }

        public override void Execute(IBaseCharacter character)
        {
            var keysCount = MenuForShop.MenuItems
                .OfType<TradeKeys>()
                .FirstOrDefault()?._count;
            if (keysCount != null)
            {
                if (character.Coins > 0 && keysCount > 0)
                {
                    character.Coins--;
                    character.Keys++;
                    MenuForShop.ShopHistory.Add("You bought 1 Key");
                }
                else
                {
                    MenuForShop.ShopHistory.Add("You don't have any coin");
                }
            }
        }
    }
}
