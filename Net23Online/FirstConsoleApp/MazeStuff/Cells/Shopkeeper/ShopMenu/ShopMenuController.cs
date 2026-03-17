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
            _shopMenu = shopMenuBuilder.Build(_shopkeeper._goods, '<');

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
            var newCursorPosition = _shopMenu._cursorPosition;
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.W:
                    {
                        newCursorPosition--;
                        break;
                    }
                case ConsoleKey.S:
                    {
                        newCursorPosition++;
                        break;
                    }
                case ConsoleKey.Enter:
                    {
                        ProcessMen(newCursorPosition);
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        return false;
                    }
            }
            if (newCursorPosition >= 0 && newCursorPosition < _shopkeeper.wares.count())
            {
                shopdrawer.cursorposition = newCursorPosition;
                return true;
            }
            return true;
        }
        private bool buytheware(int cursorposition)
        {
            var action = (shopaction)cursorposition;
            switch (action)
            {
                case shopaction.heal:
                    {
                        _shopkeeper._character.hp++;
                        break;
                    }
                case shopaction.buypotion:
                    {
                        _shopkeeper._character.speed++;
                        break;
                    }
                case shopaction.buycourse:
                    {
                        _shopkeeper._character.coins--;
                        break;
                    }
                case shopaction.stealcoin:
                    {
                        var trysteal = _shopkeeper._random.next(1, 100);
                        if (trysteal < 10)
                        {
                            console.writeline("you stole one coin from the stupid shopkeeper!");
                            _shopkeeper._character.coins++;
                        }
                        else
                        {
                            console.writeline("the crazy shopkeeper beat you up and refuses to do business with you anymore!");
                            _shopkeeper._character.hp--;
                        }
                        break;
                    }
            }
        }
    }
}
