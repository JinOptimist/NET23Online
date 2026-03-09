using FirstConsoleApp.MazeStuff.Cells;

namespace FirstConsoleApp.MazeStuff.Characters
{
    public abstract class BaseCharacter : BaseCell
    {
        protected BaseCharacter(Maze maze) : base(maze)
        {
        }

        public string Name { get; set; }
        public int Hp {  get; set; }
        public int Coins { get; set; }
    }
}
