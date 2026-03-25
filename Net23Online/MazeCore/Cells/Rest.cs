using MazeCore.Characters.Interfaces;
using MazeCore.Interfaces;

namespace MazeCore.Cells
{
    public class Rest : BaseCell
    {

        private const int _HP_COLLECT = 1;

        public Rest(IMaze maze) : base(maze)
        {
        }

        public override char Symbol => 'Q';
        public override bool IsBonusCell { get; init; } = true;


        public override bool Interaction(IBaseCharacter character)
        {
            character.CollectHp(_HP_COLLECT);
            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("rest_sound.wav");

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