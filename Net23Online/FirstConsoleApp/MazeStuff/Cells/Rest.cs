using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Rest : BaseCell
    {


        public Rest(Maze maze) : base(maze)
        {
        }

        public override char Symbol => 'Q';

        public override bool Interaction(BaseCharacter character)
        {
            character.Hp++;
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