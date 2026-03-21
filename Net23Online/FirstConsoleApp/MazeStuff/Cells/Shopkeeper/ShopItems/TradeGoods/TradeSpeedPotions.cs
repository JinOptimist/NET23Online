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
    internal class TradeSpeedPotions : BaseTradeGoods
    {
        public TradeSpeedPotions(int unitPrice, int count) : base(unitPrice, count)
        {
            Name = "Speed Potion";
        }

        public override void Execute(IBaseCharacter character)
        {
            var speedPotionsCount = MenuForShop.MenuItems
                .OfType<TradeSpeedPotions>()
                .FirstOrDefault()?._count;
            if (speedPotionsCount != null)
            {
                if (character.Coins > 0 && speedPotionsCount > 0)
                {
                    character.Coins--;
                    character.Speed++;
                    MenuForShop.ShopHistory.Add("You bought 1 Speed Potion");
                }
                else
                {
                    MenuForShop.ShopHistory.Add("You don't have any coin");
                }
            }
        }
    }
}
