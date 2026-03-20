using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using FirstConsoleApp.MazeStuff.Characters;
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
            _name = "Speed Potion";
        }

        public override void Execute(BaseCharacter character)
        {
            var speedPotionsCount = _shopMenu.MenuItems
                .OfType<TradeSpeedPotions>()
                .FirstOrDefault()?._count;
            if (speedPotionsCount != null)
            {
                if (character.Coins > 0 && speedPotionsCount > 0)
                {
                    character.Coins--;
                    character.Speed++;
                    _shopMenu.ShopHistory.Add("You bought 1 Speed Potion");
                }
                else
                {
                    _shopMenu.ShopHistory.Add("You don't have any coin");
                }
            }
        }
    }
}
