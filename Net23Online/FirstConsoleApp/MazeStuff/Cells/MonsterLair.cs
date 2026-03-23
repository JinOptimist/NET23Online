using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class MonsterLair : BaseCell
    {
        public override char Symbol => 'H';

        public MonsterLair(IMaze maze) : base(maze) 
        {

        }

        public override bool Interaction(IBaseCharacter character)
        {
            return true;
        }
    }
}
