using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Services;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Special;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenu;
using FirstConsoleApp.MazeStuff.Characters;


namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper
{
    internal class Shopkeeper : BaseCell
    {
        public BaseCharacter _character;
        public List<ShopItem> GoodsAndServices { get; set; }
        private Random _random;
        private bool _wantToTrade;
        public Shopkeeper(Maze maze, Random random) : base(maze)
        {
            _random = random;
        }
        public override char Symbol => '$';
        public override bool Interaction(BaseCharacter character)
        {
            Maze.EventHistory.Add("Shopkeeper here!");

            GoodsAndServices = new List<ShopItem>
            {
                new TradeKeys(unitPrice: 3, count: 1),
                new TradeSpeedPotions (unitPrice: 2, count: 2),
                new TradeSuperPower (unitPrice: 3, count: 1),
                new ShopkeeperServiceRestoreHP(unitPrice: 2),
                new TryStealCoins()
            };

            var shopMenuController = new ShopMenuController(this);
            shopMenuController.StartShopMenu();
            return true;
        }

    }
}
