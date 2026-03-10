using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public abstract class BaseCell
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public Maze Maze { get; set; }
        public abstract char Symbol { get; }

        public BaseCell(Maze maze)
        {
            Maze = maze;
        }

        public abstract bool Interaction(BaseCharacter character);
    }
}
