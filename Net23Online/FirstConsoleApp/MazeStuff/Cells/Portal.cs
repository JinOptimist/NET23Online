using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Portal : BaseCell
    {
        public override char Symbol => '%';

        public Portal(Maze maze) : base(maze)
        {
        }

        public override bool Interaction(BaseCharacter character)
        {
            return true;
        }
    }
}
