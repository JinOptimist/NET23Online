using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Lava : BaseCell
    {
        public Lava(Maze maze) : base(maze)
        {
        }

        public override char Symbol => 'L';

        public override bool Interaction(BaseCharacter character)
        {
            character.Hp--;

            return true;
        }
    }
}