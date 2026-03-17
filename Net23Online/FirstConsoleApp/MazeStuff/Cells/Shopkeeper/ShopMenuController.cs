using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper
{
    internal class ShopMenuController
    {
        private class ShopMenuController
        {
            private Shopkeeper _shopkeeper { get; set; }
            public ShopMenuController(Shopkeeper shopkeeper)
            {
                _shopkeeper = shopkeeper;
            }
            public void StartShopMenu()
            {
                var ShopMenuBuilder = new ShopMenuBuilder();
                var shopdrawer = new shopdrawer();
                console.writeline("a kind shopkeeper shows you his goods.");
                _shopkeeper.wares = new list<string>()
                {
                    "restore 1 hp (1c)",
                    "buy speed potion. (1c)",
                    "buy course: learn to earn coins – no investment. (1с)",
                    "try to steal a coin from the shopkeeper. (10%)",
                    "leave"
                };
                var continueshop = true;
                do
                {
                    doonestepmenu(shopdrawer);
                } while (continueshop);

            }
            private bool doonestepmenu(shopdrawer shopdrawer)
            {
                var newcursorposition = shopdrawer.cursorposition;
                var key = console.readkey();
                switch (key.key)
                {
                    case consolekey.w:
                        {
                            newcursorposition--;
                            break;
                        }
                    case consolekey.s:
                        {
                            newcursorposition--;
                            break;
                        }
                    case consolekey.enter:
                        {
                            buytheware(newcursorposition);
                            break;
                        }
                    case consolekey.escape:
                        {
                            return false;
                        }
                }

                if (newcursorposition >= 0 && newcursorposition < _shopkeeper.wares.count())
                {
                    shopdrawer.cursorposition = newcursorposition;
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
}
