using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Coin : BaseCell
    {
        public Coin(Maze maze) : base(maze)
        {
        }

        public override char Symbol => 'c';

        public override bool Interaction(BaseCharacter character)
        {
            character.Coins++;

            Maze.Cells.Remove(this);
            var ground = new Ground(Maze) { 
                X = X,
                Y = Y,
            };
            Maze.Cells.Add(ground);

            return true;
        }
    }
}
