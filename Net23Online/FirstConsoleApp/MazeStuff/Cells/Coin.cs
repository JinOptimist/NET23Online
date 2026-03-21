using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Coin : BaseCell
    {
        public const char SYMBOL = 'c';
        public override bool IsBonusCell { get; init; } = true;

        public Coin(IMaze maze) : base(maze)
        {

        }
        private const int _COINS_COLLECT = 1;
        

        public override char Symbol => SYMBOL;

        public override bool Interaction(IBaseCharacter character)
        {
            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("coin_sound.mp3");

            Maze.EventHistory.Add("Look, it's a coin");
            character.CollectCoin(_COINS_COLLECT);

            Replace();

            return true;
        }

        private void Replace()
        {
            Maze.Surface.Remove(this);
            var ground = new Ground(Maze)
            {
                X = X,
                Y = Y,
            };
            Maze.Surface.Add(ground);
        }
    }
}
