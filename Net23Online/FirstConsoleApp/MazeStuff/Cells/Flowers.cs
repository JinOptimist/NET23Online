using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Flowers : BaseCell
    {
        public Flowers(Maze maze) : base(maze)
        {
        }

        public override char Symbol => '@';

        public override bool Interaction(BaseCharacter character)
        {
            return true;
        }
    }
}
