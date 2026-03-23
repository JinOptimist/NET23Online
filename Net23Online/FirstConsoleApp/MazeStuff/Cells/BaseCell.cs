using FirstConsoleApp.MazeStuff.Cells.Interfaces;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using FirstConsoleApp.MazeStuff.MazeAudio;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public abstract class BaseCell : IBaseCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public IMaze Maze { get; set; }
        public abstract char Symbol { get; }
        public virtual bool IsBonusCell { get; init; } = false;

        public BaseCell(MazeStuff.Interfaces.IMaze maze)
        {
            Maze = maze;
        }

        protected void PlayCellSound()
        {
            var cue = CellSoundCatalog.GetCue(GetType());
            Maze.Audio.Play(cue.FileName, cue.Volume);
        }

        public abstract bool Interaction(IBaseCharacter character);
    }
}
