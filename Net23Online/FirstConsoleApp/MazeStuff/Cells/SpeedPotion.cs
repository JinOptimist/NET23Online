using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class SpeedPotion : BaseCell
    {
        public SpeedPotion(Maze maze) : base(maze)
        {
        }
        public override char Symbol => 's';

        public override bool Interaction(BaseCharacter character)
        {
            character.SpeedPotions++;

            Maze.Cells.Remove(this);
            var ground = new Ground(Maze)
            {
                X = X,
                Y = Y,
            };
            Maze.Cells.Add(ground);

            return true;
        }
    }
}

