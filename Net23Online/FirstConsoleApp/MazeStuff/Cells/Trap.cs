using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Trap : BaseCell
    {
        public IMazeSoundPlayer soundPlayer = new MazeSoundPlayer();//delete?
        public Trap(IMaze maze) : base(maze)
        {
           
        }

        public override char Symbol => '▣';

        public override bool Interaction(IBaseCharacter character)
        {
            //MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("trap_sound.wav");

            Maze.EventHistory.Add("Look out, it's a trap");
            character.Hp--;
            Maze.Surface.Remove(this);
            var ground = new Ground(Maze)
            {
                X = X,
                Y = Y,
            };
            Maze.Surface.Add(ground);

            return true;
        }
    }
}