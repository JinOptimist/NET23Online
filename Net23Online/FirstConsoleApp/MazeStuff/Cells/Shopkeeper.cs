//using FirstConsoleApp.MazeStuff.Characters;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FirstConsoleApp.MazeStuff.Cells
//{
//    internal class Shopkeeper : BaseCell
//    {
//        возможно стоит к BaseCell добавить поле isGoods и искать по Surface.
//        private enum ShopAction
//        {
//            Heal,
//            BuyPotion,
//            BuyCourse,
//            StealCoin,
//            Leave
//        }
//        private BaseCharacter _character;
//        private List<string> Wares { get; set; }
//        private Random _random;
//        private bool _wantToTrade;
//        public Shopkeeper(Maze maze, Random random) : base(maze)
//        {
//            _random = random;
//        }
//        public override char Symbol => '$';
//        public override bool Interaction(BaseCharacter character)
//        {
//            Maze.EventHistory.Add("Shopkeeper here!");
//            var shopController = new ShopController(this);
//            shopController.StartShopMenu();

//        }

//        private class ShopDrawer
//        {
//            private char _cursorMenu = '<';
//            public int cursorPosition { get; set; }
//            public ShopDrawer()
//            {
//                cursorPosition = 0;
//            }

//            public void Draw(Shopkeeper shopkeeper)
//            {
//                Console.Clear();
//                for (int wareIndex = 0; wareIndex < shopkeeper.Wares.Count; wareIndex++) 
//                {
//                    Console.Write($"{wareIndex}. {shopkeeper.Wares[wareIndex]}");
//                    if(wareIndex == cursorPosition)
//                    {
//                        Console.WriteLine($" {_cursorMenu}");
//                    }
//                    else
//                    {
//                        Console.WriteLine();
//                    }
//                }
//            }
//        }

//        private class ShopController
//        {
//            private Shopkeeper _shopkeeper { get; set; }
//            public ShopController (Shopkeeper shopkeeper)
//            {
//                _shopkeeper = shopkeeper;
//            }
//            public void StartShopMenu()
//            {
//                var shopDrawer = new ShopDrawer();
//                Console.WriteLine("A kind shopkeeper shows you his goods.");
//                _shopkeeper.Wares = new List<string>()
//                {
//                    "Restore 1 HP (1c)",
//                    "Buy Speed potion. (1c)",
//                    "Buy Course: Learn to Earn Coins – No Investment. (1с)",
//                    "Try to steal a coin from the Shopkeeper. (10%)",
//                    "Leave"
//                };
//                var continueShop = true;
//                do
//                {
//                    doOneStepMenu(shopDrawer);
//                }while (continueShop);

//            }
//            private bool doOneStepMenu (ShopDrawer shopDrawer)
//            {
//                var newCursorPosition = shopDrawer.cursorPosition;
//                var key = Console.ReadKey();
//                switch (key.Key)
//                {
//                    case ConsoleKey.W:
//                        {
//                            newCursorPosition--;
//                            break;
//                        }
//                    case ConsoleKey.S:
//                        {
//                            newCursorPosition--;
//                            break;
//                        }
//                    case ConsoleKey.Enter:
//                        {
//                            BuyTheWare(newCursorPosition);
//                            break;
//                        }
//                    case ConsoleKey.Escape:
//                        {
//                            return false;
//                        }
//                }

//                if(newCursorPosition >= 0 && newCursorPosition < _shopkeeper.Wares.Count())
//                {
//                    shopDrawer.cursorPosition = newCursorPosition;
//                    return true;
//                }
//                return true;
//            }

//            private bool BuyTheWare(int cursorPosition)
//            {
//                var action = (ShopAction)cursorPosition;
//                switch (action)
//                {
//                    case ShopAction.Heal:
//                        {
//                            _shopkeeper._character.Hp++;
//                            break;
//                        }
//                    case ShopAction.BuyPotion:
//                        {
//                            _shopkeeper._character.Speed++;
//                            break;
//                        }
//                    case ShopAction.BuyCourse:
//                        {
//                            _shopkeeper._character.Coins--;
//                            break;
//                        }
//                    case ShopAction.StealCoin:
//                        {
//                            var trySteal = _shopkeeper._random.Next(1, 100);
//                            if(trySteal < 10)
//                            {
//                                Console.WriteLine("You stole one coin from the stupid shopkeeper!");
//                                _shopkeeper._character.Coins++;
//                            }
//                            else
//                            {
//                                Console.WriteLine("The crazy shopkeeper beat you up and refuses to do business with you anymore!");
//                                _shopkeeper._character.Hp--;

//                            }
//                            break;
//                        }
//                }
//            }
//        }
//    }
//}
