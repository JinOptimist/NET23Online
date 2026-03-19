using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem
{
    internal class ShopMenuBuilder
    {
        private ShopMenu _shopMenu;
        public ShopMenu Build(List<BaseShopItem> goodsAndServices, char cursor = '<')
        {
            var menuItems = new List<BaseShopItem>();
            foreach (BaseShopItem shopItem in goodsAndServices)
            {
                menuItems.Add(shopItem);
            }

            _shopMenu = new ShopMenu
            {
                MenuItems = menuItems,
                _cursor = cursor
            };

            foreach (var item in _shopMenu.MenuItems)
            {
                item._shopMenu = _shopMenu;
            }

            return _shopMenu;
        }
    }
}
