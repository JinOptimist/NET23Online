using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods
{
    internal class TradeSpeedPotions : TradeGoods
    {
        public TradeSpeedPotions(int unitPrice, int count) : base(unitPrice, count)
        {
            _name = "Speed Potion";
        }

        public override void Execute(BaseCharacter character)
        {
            throw new NotImplementedException();
        }
    }
}
