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
            for (var menuItemIndex = 0; menuItemIndex < _shopMenu.MenuItems.Count; menuItemIndex++)
            {
                Console.Write(_shopMenu.MenuItems[menuItemIndex]);
                if(_shopMenu._cursorPosition == menuItemIndex)
                {
                    Console.WriteLine($" {_shopMenu._cursor}");
                }
                else
                {
                    Console.WriteLine();
                }
            }
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
