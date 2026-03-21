using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
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
        private Random _random;
        private Shopkeeper _shopKeeper;
        public TryStealCoins(Shopkeeper shopKeeper, Random random)
        {
            Name = "Try steal coins from Shopkeeper.";
            _shopKeeper = shopKeeper;
            _random = random;
        }

        public override void Execute(IBaseCharacter character)
        {
            var tryStealCoinsResult = _random.Next(1, 100) < TRY_STEAL_COINS_CHANCE;
            if(tryStealCoinsResult)
            {
                character.Coins++;
                MenuForShop.ShopHistory.Add("The dumb shopkeeper lost his coins");
            }
            else
            {
                character.Hp--;
                _shopKeeper._wantToTrade = false;
                _shopKeeper.Maze.EventHistory.Add("The theft failed! That freak of a shopkeeper got mad, \nbeat you up, and now refuses to trade with you.");
            }
        }
    }
}
