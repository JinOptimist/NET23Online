using FirstConsoleApp.MazeStuff.Characters;
using System.Text.RegularExpressions;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Portal : BaseCell
    {
        public override char Symbol => '%';
        public Portal LinkedPortal { get; set; }
        public bool IsSingleUse {  get; set; }

        public Portal(Maze maze) : base(maze)
        {
        }

        public override bool Interaction(BaseCharacter character)
        {
            Console.WriteLine("A portal stands here. Use it? (Y/N)");
            
            var key = Console.ReadKey(true).Key;
            if (key != ConsoleKey.Y)
            {
                Maze.EventHistory.Add("You decided not to use the portal");
                return true;
            }

            character.X = LinkedPortal.X;
            character.Y = LinkedPortal.Y;

            Maze.EventHistory.Add("You stepped through the portal");

            if (IsSingleUse)
            {
                RemovePortals();
            }

            return false;
        }

        private void RemovePortals()
        {
            Maze.Surface.Remove(this);
            Maze.Surface.Remove(LinkedPortal);

            var groundOnEntrancePortal = new Ground(Maze)
            {
                X = X,
                Y = Y,
            };

            var groundOnDestinationPortal = new Ground(Maze)
            {
                X = LinkedPortal.X,
                Y = LinkedPortal.Y,
            };

            Maze.Surface.Add(groundOnEntrancePortal);
            Maze.Surface.Add(groundOnDestinationPortal);
        }
    }
}
