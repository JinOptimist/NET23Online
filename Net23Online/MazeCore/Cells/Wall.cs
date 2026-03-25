using MazeCore.Characters;
using MazeCore.Characters.Interfaces;
using MazeCore.Interfaces;

namespace MazeCore.Cells
{
    public class Wall : BaseCell
    {
        private const int _SUPERPOWER_COST = 1;
       
        public Wall(IMaze maze) : base(maze)
        {
        }

        public override char Symbol => '█';

        public override bool Interaction(IBaseCharacter character)
        {
            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("wall_sound.wav");

           
            if (character is Hero hero && hero.SuperPower >= _SUPERPOWER_COST)
            {
                Maze.Surface.Remove(this);
                var ground = new Ground(Maze)
                {
                    X = X,
                    Y = Y,
                };
                Maze.Surface.Add(ground);
                
                character.SpendSuperPower(_SUPERPOWER_COST);
                Maze.EventHistory.Add("You break the wall");
                return true;
            }
            
            Maze.EventHistory.Add("Boom. It's a wall");
            return false;
        }
    }
}
