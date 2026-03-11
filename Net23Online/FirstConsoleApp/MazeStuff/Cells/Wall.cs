using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Wall : BaseCell
    {
        public Wall(Maze maze) : base(maze)
        {
        }

        public override char Symbol => '#';

        public override bool Interaction(BaseCharacter character)
        {
            return false;
        }
    }
}
