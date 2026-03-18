using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenu
{
    internal class ShopMenuBuilder
    {
        private ShopMenu _shopMenu;
        public ShopMenu Build(List<ShopItem> goodsAndServices, char cursor = '<')
        {
            var menuItems = new List<ShopItem>();
            foreach (ShopItem shopItem in goodsAndServices)
            {
                menuItems.Add(shopItem);
            }

            _shopMenu = new ShopMenu
            {
                MenuItems = menuItems,
                _cursor = cursor
            };
            return _shopMenu;
        }
    }
}
