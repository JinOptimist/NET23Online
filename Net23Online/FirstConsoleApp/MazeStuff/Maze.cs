using FirstConsoleApp.MazeStuff.Cells;

namespace FirstConsoleApp.MazeStuff
{
    public class Maze
    {
        public int Width { get; set; }
        public int Height { get; set; }

        // ground == '.'
        // wall '#'
        // coin 'c'
        public List<BaseCell> Cells { get; set; } = new();


    }
}
