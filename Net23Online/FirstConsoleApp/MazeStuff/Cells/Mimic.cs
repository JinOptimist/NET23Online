using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Mimic : BaseCell
    {
        Random _random;

        public Mimic(Maze maze) : base(maze)
        {
            _random = new Random();
        }

        public override char Symbol
        {
            get
            {
                var mimicMasks = new List<char> { 'c', 'D' };
                var index = _random.Next(mimicMasks.Count);
                return mimicMasks[index];
            }
        }

        public override bool Interaction(BaseCharacter character)
        {
            Maze.EventHistory.Add("You encounteder a mimic");
            if (character.Hp < 1)
            {
                Maze.EventHistory.Add("You must be dead.");
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
