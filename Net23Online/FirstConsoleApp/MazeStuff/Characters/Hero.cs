using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Characters
{
    public class Hero : BaseCharacter, IBaseCharacter
    {
        public Hero(IMaze maze) : base(maze)
        {
        }
        
        

        public override char Symbol => '@';

        public override bool Interaction(IBaseCharacter character)
        {
            throw new NotImplementedException();
        }
        
    }
}
