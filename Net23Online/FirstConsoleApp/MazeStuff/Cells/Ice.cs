using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Ice : BaseCell
    {
        private const int _HP_COST = 1;
        private const int _Speed_COST = 1;
        public override char Symbol => 'i';
        public Ice(IMaze maze) : base(maze)
        {
        }

        public override bool Interaction(IBaseCharacter character)
        {

            if (!character.HasHp(_HP_COST))
            {
                Maze.EventHistory.Add("LAST LIFE LOST, It's An Ice");
                character.Hp = 0;
                character.GameOver();
                return false;
            }
            if (!character.HasSpeeds(_Speed_COST))
            {
                Maze.EventHistory.Add("You are freezing!");
                character.Speed = 0;
            }

            character.SpendHp(_HP_COST);
            character.SpendSpeed(_Speed_COST);

            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("ice_sound.wav");


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
