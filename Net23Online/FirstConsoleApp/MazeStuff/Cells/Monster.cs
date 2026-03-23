using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Monster : BaseCell
    {
        public override char Symbol => 'W';

        public Monster(IMaze maze) : base(maze)
        {

        }

        public override bool Interaction(IBaseCharacter character)
        {
            Maze.EventHistory.Add("Game Over!");

            return true;
        }
    }
}
