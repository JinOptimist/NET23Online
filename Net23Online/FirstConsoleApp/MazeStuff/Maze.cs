using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff
{
    public class Maze
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Hero Hero { get; set; }

        // ground == '.'
        // wall '#'
        // coin 'c'
        public List<BaseCell> Surface { get; set; } = new();

        public List<string> EventHistory { get; set; } = new();

        public BaseCell? this[int x, int y]
        {
            get
            {
                //var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

                //numbers.First(number => number > 5); // => 6
                //numbers.First(number => number > 12); // !!! EXCEPTION !!!

                //numbers.FirstOrDefault(number => number > 5); // => 6
                //numbers.FirstOrDefault(number => number > 12); // 0 DEFAULT NULL

                //numbers.Single(number => number > 5); // !!! EXCEPTION !!!
                //numbers.Single(number => number > 7); // => 8 
                //numbers.Single(number => number > 12); // !!! EXCEPTION !!!

                //numbers.SingleOrDefault(number => number > 5); // !!! EXCEPTION !!!
                //numbers.SingleOrDefault(number => number > 7); // => 8 
                //numbers.SingleOrDefault(number => number > 12); // => 0 DEFAULT NULL

                return Surface.SingleOrDefault(cell => cell.X == x && cell.Y == y);
            }
        }
    }
}
