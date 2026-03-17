using firstconsoleapp.mazestuff.characters;
using FirstConsoleApp.MazeStuff.Characters;
using system;
using system.collections.generic;
using system.linq;
using system.text;
using system.threading.tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper
{
    internal class Shopkeeper : BaseCell
    {
        private BaseCharacter _character;
        private List<string> _goods { get; set; }
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
            var ShopController = new ShopController(this);
            ShopController.StartShopMenu();

        }

        private class shopdrawer
        {
            private char _cursormenu = '<';
            public int cursorposition { get; set; }
            public shopdrawer()
            {
                cursorposition = 0;
            }

            public void draw(shopkeeper shopkeeper)
            {
                console.clear();
                for (int wareindex = 0; wareindex < shopkeeper.wares.count; wareindex++)
                {
                    console.write($"{wareindex}. {shopkeeper.wares[wareindex]}");
                    if (wareindex == cursorposition)
                    {
                        console.writeline($" {_cursormenu}");
                    }
                    else
                    {
                        console.writeline();
                    }
                }
            }
        }


    }
}
