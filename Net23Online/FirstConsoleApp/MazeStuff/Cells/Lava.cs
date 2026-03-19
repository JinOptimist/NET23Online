using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Lava : BaseCell
    {
        private const int _HP_COST = 1;
        public Lava(Maze maze) : base(maze)
        {
        }

        public override char Symbol => 'L';

        public override bool Interaction(BaseCharacter character)
        {
            if (!character.HasHp(_HP_COST) || character.Hp <= _HP_COST)
            {
                Maze.EventHistory.Add("LAST LIFE LOST, It's Lava ");
                character.Hp = 0;
                character.GameOver();
                return false;
            }
            Maze.EventHistory.Add("This 'hot pot' too hot for you.");
            character.SpendHp(_HP_COST);
            character.Burning++;

            return true;
        }
    }
}