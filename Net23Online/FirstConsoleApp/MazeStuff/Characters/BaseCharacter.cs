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

        public bool HasKey(int amount)
        {
            if (Keys >= amount)
            {
                return true;
            }
            return false;
        }

        public void UseKey(int amount)
        {
            Keys -= amount;
        }

        public void SpendCoins(int amount)
        {
            Coins -= amount;
        }

        public void CollectKey(int amount)
        {
            Keys += amount;
        }
    }
}
