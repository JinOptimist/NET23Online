using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Lava : BaseCell
    {
        public Lava(IMaze maze) : base(maze)
        {

        }
        private const int _HP_COST = 1;

        public override char Symbol => 'L';

        public override bool Interaction(IBaseCharacter character)
        {
            if (!character.HasHp(_HP_COST))
            {
                Maze.EventHistory.Add("LAST LIFE LOST, It's Lava ");
                character.Hp = 0;
                character.GameOver();
                return false;
            }
            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("lava_sound.wav");

            Maze.EventHistory.Add("This 'hot pot' too hot for you.");
            character.SpendHp(_HP_COST);
            character.Burning++;

            return true;
        }
    }
}