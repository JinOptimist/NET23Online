using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenu
{
    internal class ShopMenuController
    {
        private ShopMenu _shopMenu;
        private Shopkeeper _shopkeeper { get; set; }
        public ShopMenuController(Shopkeeper shopkeeper)
        {
            _shopkeeper = shopkeeper;
        }
        public void StartShopMenu()
        {
            var shopMenuBuilder = new ShopMenuBuilder();
            _shopMenu = shopMenuBuilder.Build(_shopkeeper.GoodsAndServices, '<');

            var shopMenuDrawer = new ShopMenuDrawer();
            shopMenuDrawer.Draw(_shopMenu);

            Console.WriteLine("A kind shopkeeper shows you his goods.");
            var continueShoping = true;
            do
            {
                continueShoping = DoOneMenuAction();
                shopMenuDrawer.Draw(_shopMenu);
            } while (continueShoping);
        }
        private bool DoOneMenuAction()
        {
            var currentCursorPosition = _shopMenu._cursorPosition;
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.W:
                    {
                        if (currentCursorPosition != 0)
                        {
                            currentCursorPosition--;
                        }
                        break;
                    }
                case ConsoleKey.S:
                    {
                        if (currentCursorPosition != _shopMenu.MenuItems.Count)
                        {
                            currentCursorPosition++;
                        }
                        break;
                    }
                case ConsoleKey.Enter:
                    {
                        _shopMenu.MenuItems.Execute();
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        return false;
                    }
            }
            return true;
        }
       
    }
}
