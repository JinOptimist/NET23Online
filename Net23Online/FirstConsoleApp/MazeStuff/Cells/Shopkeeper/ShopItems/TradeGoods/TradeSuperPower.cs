using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods
{
    internal class TradeSuperPower : TradeGoods
    {
        public TradeSuperPower(int unitPrice, int count) : base(unitPrice, count)
        {
            _name = "Super Power";
        }

        public override void Execute(BaseCharacter character)
        {
            throw new NotImplementedException();
        }
    }
}
