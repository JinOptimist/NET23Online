using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Services;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Special;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using FirstConsoleApp.MazeStuff.Characters;
using System.Runtime.CompilerServices;


namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper
{
    internal class Shopkeeper : BaseCell
    {
        public BaseCharacter Character;
        private Random _random;
        private bool _wantToTrade;
        public List<BaseShopItem> GoodsAndServices { get; set; }
        public Shopkeeper(Maze maze, Random random) : base(maze)
        {
            _random = random;
        }
        public override char Symbol => '$';
        public override bool Interaction(BaseCharacter character)
        {
            Maze.EventHistory.Add("Shopkeeper here!");
            GoodsAndServices = new List<BaseShopItem>
            {
                new TradeKeys(unitPrice: 2, count: 1),
                new TradeSpeedPotions(unitPrice: 1, count: 3),
                new TradeSuperPower(unitPrice: 3, count: 1),
                new ShopkeeperServiceRestoreHP(unitPrice: 2),
                new TryStealCoins()
            };
            var shopMenuController = new ShopMenuController(this);
            shopMenuController.StartShopMenu();
            return true;

        }


    }
}
