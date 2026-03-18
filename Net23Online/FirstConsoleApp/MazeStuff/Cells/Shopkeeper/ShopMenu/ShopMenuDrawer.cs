using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenu
{
    internal class ShopMenuDrawer
    {
        private ShopMenu _shopMenu;
        private const int SHOP_HISTORY_LENGHT = 3;
        public void Draw(ShopMenu shopMenu)
        {
            _shopMenu = shopMenu;

            for (var menuItemIndex = 0; menuItemIndex < shopMenu.MenuItems.Count(); menuItemIndex++)
            {
                var currentMenuItem = shopMenu.MenuItems[menuItemIndex];
                Console.Write($"{menuItemIndex + 1}. ");
                if(currentMenuItem is TradeGoods)
                {
                    Console.Write("Buy ");
                }

                Console.Write($"{currentMenuItem._name}");
                
                if(shopMenu._cursorPosition == menuItemIndex)
                {
                    Console.WriteLine($"{shopMenu._cursor}");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"{_shopMenu.MenuItems.Count}. Leave");
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
