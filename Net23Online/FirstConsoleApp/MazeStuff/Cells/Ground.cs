using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Ground : BaseCell
    {
        public Ground(IMaze maze) : base(maze)
        {
        }

        //public override char Symbol
        //{
        //    get
        //    {
        //        return '.';
        //    }
        //}
        public override char Symbol => '░';

        public override bool Interaction(IBaseCharacter character)
        {
            return true;
        }
    }
}
