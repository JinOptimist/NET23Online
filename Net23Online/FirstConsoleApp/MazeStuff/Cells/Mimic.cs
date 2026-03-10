using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Mimic : BaseCell
    {
        public Mimic(Maze maze) : base(maze)
        {
        }

        public override char Symbol => 'M';

        public override bool Interaction(BaseCharacter character)
        {
            throw new NotImplementedException();
        }
    }
}
