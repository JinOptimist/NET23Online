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
            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("lava_sound.wav");

            Maze.EventHistory.Add("This 'hot pot' too hot for you.");
            character.Hp--;
            character.Burning++;

            return true;
        }
    }
}