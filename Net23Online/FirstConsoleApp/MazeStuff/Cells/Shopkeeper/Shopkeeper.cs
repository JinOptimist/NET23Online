using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Services;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Special;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using System.Runtime.CompilerServices;


namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper
{
    internal class Shopkeeper : BaseCell
    {
        public IBaseCharacter Character;
        private Random _random;
        public bool _wantToTrade;
        public List<BaseShopItem> GoodsAndServices { get; set; }
        public Shopkeeper(IMaze maze, Random random) : base(maze)
        {
            _random = random;
            _wantToTrade = true;
        }
        public override char Symbol => '$';
        public override bool Interaction(IBaseCharacter character)
        {
            Character = character;
            Console.Clear();
            if (_wantToTrade)
            {
                Maze.EventHistory.Add("Shopkeeper here!");
            }
            else
            {
                Maze.EventHistory.Add("Shopkeeper ignore you!");
                return true;
            }
            GoodsAndServices = new List<BaseShopItem>
            {
                new TradeKeys(unitPrice: 2, count: 1),
                new TradeSpeedPotions(unitPrice: 1, count: 3),
                new TradeSuperPower(unitPrice: 3, count: 1),
                new ShopkeeperServiceRestoreHP(unitPrice: 2),
                new TryStealCoins(this, _random)
            };
            var shopMenuController = new ShopMenuController(this);
            shopMenuController.StartShopMenu();
            return true;

        }


    }
}
