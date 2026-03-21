using FirstConsoleApp.MazeStuff;
using FirstConsoleApp.MazeStuff.Cells.Interfaces;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public abstract class BaseCell : IBaseCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public IMaze Maze { get; set; }
        public abstract char Symbol { get; }
        public virtual bool IsBonusCell { get; init; } = false;

        protected MazeSoundPlayer soundPlayerForCells = new MazeSoundPlayer(new AudioOutput(), path => new AudioFile(path));

        public BaseCell(MazeStuff.Interfaces.IMaze maze)
        {
            Maze = maze;
        }

        public abstract bool Interaction(IBaseCharacter character);
    }
}
