using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Lava : BaseCell
    {
        public Lava(IMaze maze) : base(maze)
        {
        }

        public override char Symbol => 'L';

        public override bool Interaction(IBaseCharacter character)
        {
            soundPlayerForCells.Play("lava_sound.wav", 0.4f);

            Maze.EventHistory.Add("This 'hot pot' too hot for you.");
            character.Hp--;
            character.Burning++;

            return true;
        }
    }
}