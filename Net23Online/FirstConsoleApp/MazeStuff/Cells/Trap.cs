using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Trap : BaseCell
    {
        public Trap(Maze maze) : base(maze)
        {
        }

        public override char Symbol => '▣';

        public override bool Interaction(BaseCharacter character)
        {

            Maze.Surface.Remove(this);
            var ground = new Ground(Maze)
            {
                X = X,
                Y = Y,
            };
            Maze.Surface.Add(ground);

            return true;
        }
    }
}