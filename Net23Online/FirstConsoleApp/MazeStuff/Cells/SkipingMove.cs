using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class SkipingMove : BaseCell
    {
        private const int _HP_COST = 10;
        private const int _Coins_COST = 1;
        public override char Symbol => 'O';

        public SkipingMove(IMaze maze) : base(maze)
        {

        }

        public override bool Interaction(IBaseCharacter character)
        {
            if (!character.HasHp(_HP_COST))
            {
                Maze.EventHistory.Add("opps! yuo in pit");
                Maze.EventHistory.Add("LAST LIFE LOST, It's skipping Move ");
                character.Hp = 0;
                character.GameOver();
                return false;
            }
            if (!character.HasCoins(_Coins_COST))
            {
                Maze.EventHistory.Add("opps! yuo in pit");
                Maze.EventHistory.Add("NO COINS TO COMPLETE! ");
                character.GameOver();
                return false;
            }
            Maze.EventHistory.Add("opps! you in pit");
            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("pit_sound.wav");


            character.SpendHp(_HP_COST);
            character.SpendCoins(_Coins_COST);

            return true;
        }

        public bool HasFallenIntoPit(IBaseCharacter character)
        {
            const int CHANCE_OUT_PERCENT = 75;
            const int MAX_VALUE_PERCENT = 100;

            var cellsWithPits = Maze
                .Surface
                .Where(pit => pit.Symbol == Symbol)
                .ToList();

            foreach (var item in cellsWithPits)
            {
                if (item.X == character.X && item.Y == character.Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
