using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Mimic : BaseCell
    {
        public Mimic(IMaze maze) : base(maze)
        {
        }

        public override char Symbol => 'M';

        public override bool Interaction(IBaseCharacter character)
        {
            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("mimic_sound.mp3");

            return true;
        }
    }
}
