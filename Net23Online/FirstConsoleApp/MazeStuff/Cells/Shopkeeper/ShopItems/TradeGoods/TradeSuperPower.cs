using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using FirstConsoleApp.MazeStuff.Characters;
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
            _name = "Super Power";
        }

        public override void Execute(BaseCharacter character)
        {
            var SpeedPotionsCount = _shopMenu.MenuItems
                .OfType<TradeSpeedPotions>()
                .FirstOrDefault()?._count;
            if (SpeedPotionsCount != null)
            {
                if (character.Coins > 0 && SpeedPotionsCount > 0)
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
