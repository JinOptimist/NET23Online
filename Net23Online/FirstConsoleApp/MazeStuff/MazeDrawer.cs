using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Characters;
using static System.Net.Mime.MediaTypeNames;

namespace FirstConsoleApp.MazeStuff
{
    public class MazeDrawer
    {
        private Maze _maze;
        private const int EVENT_HISTORY_LENGTH = 5;

        public void Draw(Maze maze)
        {
            _maze = maze;
            Console.Clear();

            for (int y = 0; y < maze.Height; y++)
            {
                Console.WriteLine();// new line

                for (int x = 0; x < maze.Width; x++)
                {
                    BaseCell currentCell;

                    if (maze.Hero.X == x && maze.Hero.Y == y)
                    {
                        currentCell = maze.Hero;
                    }
                    else
                    {
                        currentCell = maze
                           .Surface
                           .First(cell => cell.X == x && cell.Y == y);
                    }

                    var symbol = currentCell.Symbol;
                    Console.Write(symbol);

                    //BaseCell currentCell;
                    //for (int i = 0; i < maze.Cells.Count; i++)
                    //{
                    //    var cell = maze.Cells[i];
                    //    if (cell.X == x && cell.Y == y)
                    //    {
                    //        currentCell = cell;
                    //        break;
                    //    }
                    //}
                }
            }

            Console.WriteLine();

            DrawHeroStats();
            DrawEventHsitory();
            DrawSeed();
        }

        private void DrawSeed()
        {
            Console.WriteLine($"Seed {_maze.Seed}");
        }

        private void DrawHeroStats()
        {
            var hero = _maze.Hero;
            Console.WriteLine($"Hp: {hero.Hp} Coins: {hero.Coins} SuperPower: {hero.SuperPower}");
        }

        private void DrawEventHsitory()
        {
            var messages = _maze
                .EventHistory
                .TakeLast(EVENT_HISTORY_LENGTH);

            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}
