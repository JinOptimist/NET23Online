
using MazeCore.Characters.Interfaces;
using MazeCore.Interfaces;

namespace MazeCore.Cells
{
    public class Doors : BaseCell
    {
        public const char SYMBOL = 'D';
        private const int _COIN_COST = 1;
        public override bool IsBonusCell { get; init; } = true;

        public Doors(IMaze maze) : base(maze)
        {
        }

        public override char Symbol => SYMBOL ;
        public override bool Interaction(IBaseCharacter character)
        {
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character));
            }
            Maze.EventHistory.Add($"door is locked !");
            if (TryOpenWithKey(character))
            {
                return true;
            }
            if (TryOpenWithCoins(character))
            {
                return true;
            }
            Maze.EventHistory.Add($"Door remains locked - no key or coins");
            return false;
        }
        public bool TryOpenWithKey(IBaseCharacter character)
        {
            if (character.Key <= 0)
            {
                return false;
            }
            character.Key--;
            Open();
            Maze.EventHistory.Add($"door opened with key ");
            return true;
        }

        public bool TryOpenWithCoins(IBaseCharacter character)
        {
            if (character.Coins < _COIN_COST)
            {
                return false;
            }
            character.Coins -= _COIN_COST;
            Open();
            Maze.EventHistory.Add($"door opened with coins ");
            return true;
        }

        private void Open()
        {

            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("door_sound.mp3", 0.7f);
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