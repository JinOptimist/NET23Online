using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods
{
    internal class TradeKeys : TradeGoods
    {
        public TradeKeys(int unitPrice, int count) : base(unitPrice, count)
        {
            _name = "Key";
        }

        public override void Execute(BaseCharacter character)
        {
            throw new NotImplementedException();
        }
    }
}
