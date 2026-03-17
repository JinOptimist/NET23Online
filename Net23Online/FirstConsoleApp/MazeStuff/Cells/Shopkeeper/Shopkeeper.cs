using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenu;
using FirstConsoleApp.MazeStuff.Characters;


namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper
{
    internal class Shopkeeper : BaseCell
    {
        private BaseCharacter _character;
        public List<string> _goods { get; set; }
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
            var shopMenuController = new ShopMenuController(this);
            shopMenuController.StartShopMenu();
            return true;
        }

    }
}
