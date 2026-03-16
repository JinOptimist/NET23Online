using FirstConsoleApp.MazeStuff.Cells;

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

        // Temporary Added here. Need an abstract class Obstacle
        public bool HasKey()
        {
            return Keys > 0;
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
    }
}
