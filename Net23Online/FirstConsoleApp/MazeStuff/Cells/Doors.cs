
using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Doors : BaseCell
    {
        public Doors(Maze maze) : base(maze)
        {
        }

        public override char Symbol => 'D';
        public override bool Interaction(BaseCharacter character)
        {
            return true;
        }
    }
}