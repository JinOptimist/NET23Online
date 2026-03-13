using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Ground : BaseCell
    {
        public Ground(Maze maze) : base(maze)
        {
        }

        //public override char Symbol
        //{
        //    get
        //    {
        //        return '.';
        //    }
        //}
        public override char Symbol => '.';

        public override bool Interaction(BaseCharacter character)
        {
            return true;
        }
    }
}
