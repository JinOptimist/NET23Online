using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem
{
    internal class ShopMenuDrawer
    {
        private ShopMenu _shopMenu;
        private Shopkeeper _shopkeeper;
        private const int SHOP_HISTORY_LENGHT = 3;
        public void Draw(ShopMenu shopMenu, Shopkeeper shopkeeper)
        {
            _shopMenu = shopMenu;
            _shopkeeper = shopkeeper;
            Console.Clear();
            for (var menuItemIndex = 0; menuItemIndex < shopMenu.MenuItems.Count(); menuItemIndex++)
            {
                var currentMenuItem = shopMenu.MenuItems[menuItemIndex];
                Console.Write($"{menuItemIndex + 1}. ");
                if(currentMenuItem is BaseTradeGoods)
                {
                    Console.Write("Buy ");
                }

                Console.Write($"{currentMenuItem.Name}");
                
                if(shopMenu._cursorPosition == menuItemIndex)
                {
                    Console.WriteLine($"{shopMenu._cursor}");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"\nCoins: {_shopkeeper.Character.Coins}");
            Console.WriteLine("\nShop History:");
            DrawShopMenuHistory();
        }
        private void DrawShopMenuHistory()
        {
            var messages = _shopMenu
                .ShopHistory
                .TakeLast(SHOP_HISTORY_LENGHT);

            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}
