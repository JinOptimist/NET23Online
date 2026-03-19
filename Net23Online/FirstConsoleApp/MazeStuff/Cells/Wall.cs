using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Wall : BaseCell
    {
        private const int _SUPERPOWER_COST = 1;
        public Wall(Maze maze) : base(maze)
        {
        }

        public override char Symbol => '█';

        public override bool Interaction(BaseCharacter character)
        {
            if (character is Hero hero && hero.SuperPower > 0)
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
