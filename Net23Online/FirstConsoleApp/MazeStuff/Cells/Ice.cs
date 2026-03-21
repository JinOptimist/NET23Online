using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Ice : BaseCell
    {
        public override char Symbol => 'i';
        public Ice(IMaze maze) : base(maze)
        {
        }

        public override bool Interaction(IBaseCharacter character)
        {
            soundPlayerForCells.Play("ice_sound.wav", 0.3f);

            character.Hp -= 1; // Need a new method in Character for logic. (Other cells can change hp, speed)
            character.Speed -= 1;

            Maze.EventHistory.Add("You are freezing!");

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
