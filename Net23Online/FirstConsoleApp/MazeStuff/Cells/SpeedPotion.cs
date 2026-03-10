using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    /// <summary>
    /// speed potion allows: 1. If the game environment moves in turns, then the potion allows you to move twice. 2. If the game environment is static, the potion allows you to pass through 2 cells, for example, bypassing traps.
    /// </summary>
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

