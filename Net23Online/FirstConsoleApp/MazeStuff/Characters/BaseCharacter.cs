using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Characters
{
    public abstract class BaseCharacter : BaseCell, IBaseCharacter
    {
        protected BaseCharacter(IMaze maze) : base(maze)
        {
        }

        public string Name { get; set; }
        public int Hp { get; set; }
        public int Coins { get; set; }
        public int Speed { get; set; }
        public int Burning { get; set; }

        public int Keys { get; set; }

        public bool HasKey()
        {
            if (Keys > 0)
            {
                return true;
            }
            return false;
        }

        public void UseKey(int amount)
        {
            Keys--;
            Coins += amount;
        }

        public void SpendCoins(int amount)
        {
            Coins -= amount;
        }

        public void CollectKey()
        {
            Keys++;
        }

        public void ProcessBurnEffect()
        {
            if (Burning > 0)
            {   
                Hp--;
                Maze.EventHistory.Add($"You've lost 1 HP from burning. Your HP: {Hp}");

                Burning--;

                if (Burning == 0)
                {
                    Maze.EventHistory.Add($"You put out the fire");
                }
            }
        }
    }
}
