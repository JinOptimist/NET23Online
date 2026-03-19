using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Special
{
    internal class TryStealCoins : BaseShopItem
    {
        private const int TRY_STEAL_COINS_CHANCE = 10;
        public TryStealCoins()
        {
            _name = "Try steal coins from Shopkeeper.";
        }

        public override void Execute(BaseCharacter character)
        {
            throw new NotImplementedException();
        }
    }
}
