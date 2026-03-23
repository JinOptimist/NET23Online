using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Coin : BaseCell
    {
        public const char SYMBOL = 'c';
        public override bool IsBonusCell { get; init; } = true;

        public Coin(IMaze maze) : base(maze)
        {
        }

        public override char Symbol => SYMBOL;

        public override bool Interaction(IBaseCharacter character)
        {
            PlayCellSound();

            Maze.EventHistory.Add("Look, it's a coin");

            character.Coins++;

            Replace();

            return true;
        }

        private void Replace()
        {
            Maze.Surface.Remove(this);
            var ground = new Ground(Maze)
            {
                X = X,
                Y = Y,
            };
            Maze.Surface.Add(ground);
        }
    }
}
