using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    /// <summary>
    /// When a hero picks up a speed potion, his speed increases by 1.
    /// </summary>
    internal class SpeedPotions : BaseCell
    {
        private const int _SPEED_COLLECT = 1;
        private const int _MAX_SPEED = 5;
       
        public SpeedPotions(IMaze maze) : base(maze)
        {
        }
        public override char Symbol => 's';
        public override bool Interaction(IBaseCharacter character)
        {
            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("speedpotion_sound.flac");

            Maze.EventHistory.Add("You drank the speed potion! Now you move faster.");
            if (character.Speed + _SPEED_COLLECT <= _MAX_SPEED)
            {
                character.CollectSpeed(_SPEED_COLLECT);
            }
            

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
