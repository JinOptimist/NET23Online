
using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Doors : BaseCell
    {
        public const char SYMBOL = 'D';
        public Doors(Maze maze) : base(maze)
        {
        }

        public override char Symbol => SYMBOL;
        public override bool Interaction(BaseCharacter character)
        {
            return true;
        }
    }
}