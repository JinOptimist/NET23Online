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
        public ShopMenu Build(List<string> goods, char cursor = '<')
        {
            var menuItems = new List<string>();
            for(int i = 0; i < goods.Count; i++)
            {
                menuItems.Add($"{i + 1}. Buy a " + goods[i]);
            }
            menuItems.AddRange(new List<string>
            {
                $"{menuItems.Count}. Restore 1 HP.",
                $"{menuItems.Count + 1}. Try to steal a coin from the Shopkeeper. (10%)",
                $"{menuItems.Count + 2}. Leave"
            });
            _shopMenu = new ShopMenu
            {
                MenuItems = menuItems,
                _cursor = cursor
            };
            return _shopMenu;
        }
    }
}
