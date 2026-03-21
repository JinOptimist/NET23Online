using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Trap : BaseCell
    {
        private const int _HP_COST = 1;
      
        public Trap(IMaze maze) : base(maze)
        {
        }

        public override char Symbol => '▣';

        public override bool Interaction(IBaseCharacter character)
        {
            if (!character.HasHp(_HP_COST) || character.Hp <= _HP_COST)
            {
                character.Hp = 0;
                Maze.EventHistory.Add("LAST LIFE LOST,it's a trap ");
                character.GameOver();
                return false;
            }
            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("trap_sound.wav");

            Maze.EventHistory.Add("Look out, it's a trap");
            character.SpendHp(_HP_COST);
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