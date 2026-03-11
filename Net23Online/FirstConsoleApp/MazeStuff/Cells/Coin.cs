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
            Maze.EventHistory.Add("Look, it's a coin");
            character.Coins++;

            Maze.Surface.Remove(this);
            var ground = new Ground(Maze) { 
                X = X,
                Y = Y,
            };
            Maze.Surface.Add(ground);

            return true;
        }
    }
}
