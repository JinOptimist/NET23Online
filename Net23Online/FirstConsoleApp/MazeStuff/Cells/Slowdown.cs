using FirstConsoleApp.MazeStuff;
using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Slowdown : BaseCell
    {
        public override char Symbol => 'O';

        public Slowdown(Maze maze) : base (maze) 
        {

        }

        public override bool Interaction(BaseCharacter character)
        {
            return true;
        }
    }
}
