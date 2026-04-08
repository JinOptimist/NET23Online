using MazeCore.Characters.Interfaces;
using MazeCore.Interfaces;

namespace MazeCore.Cells
{
    public class Exit : BaseCell
    {
        private MazeController  _controller;
        public const char SYMBOL = 'e';
        public override bool IsBonusCell { get; init; } = true;

        public Exit(IMaze maze, MazeController controller) : base(maze)
        {
            _controller = controller;
        }

        public override char Symbol => SYMBOL;

        public override bool Interaction(IBaseCharacter character)
        {
            _controller.continuewGame = false;

            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();

            Maze.EventHistory.Add("Look, it's a exit");

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
