using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class SkipingMove : BaseCell
    {
        public override char Symbol => 'O';

        public SkipingMove(Maze maze) : base(maze)
        {

        }

        public override bool Interaction(BaseCharacter character)
        {
            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("pit_sound.wav");

            Maze.EventHistory.Add("opps! yuo in pit");

            character.Hp -= 10;
            character.Coins--;

            return true;
        }

        public bool HasFallenIntoPit(BaseCharacter character)
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
