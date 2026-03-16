using FirstConsoleApp.MazeStuff.Cells;
using System.Reflection.Metadata.Ecma335;

namespace FirstConsoleApp.MazeStuff.Characters
{
    public abstract class BaseCharacter : BaseCell
    {
        protected BaseCharacter(Maze maze) : base(maze)
        {
        }

        public string Name { get; set; }
        public int Hp { get; set; }
        public int Coins { get; set; }
        public int Speed { get; set; }
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
    }
}
