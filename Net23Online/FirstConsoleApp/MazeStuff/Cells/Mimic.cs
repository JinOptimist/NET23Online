using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Mimic : BaseCell
    {
        Random _random;
        public Mimic(IMaze maze) : base(maze)
        {
            _random = new Random();
        }

        public override char Symbol
        {
            get
            {
                var mimicMasks = new List<char> { Coin.SYMBOL, Doors.SYMBOL };
                var index = _random.Next(mimicMasks.Count);
                return mimicMasks[index];
            }
        }

        public override bool Interaction(IBaseCharacter character)
        {
            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("mimic_sound.mp3");

            Maze.EventHistory.Add("You encounteder a mimic");
            if (character.Hp < 1)
            {
                Maze.EventHistory.Add("You are too tired (0 HP) to fight.");
                return false;
            }

            character.Hp--;
            character.Coins += 10;
            Maze.EventHistory.Add("You were wounded and awarded");
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
