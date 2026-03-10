using FirstConsoleApp.MazeStuff.Cells;

namespace FirstConsoleApp.MazeStuff
{
    public class MazeDrawer
    {
        public void Draw(Maze maze)
        {
            for (int y = 0; y < maze.Height; y++)
            {
                Console.WriteLine();// new line

                for (int x = 0; x < maze.Width; x++)
                {
                    var symbol = maze
                        .Cells
                        .First(cell => cell.X == x && cell.Y == y)
                        .Symbol;
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
        }
    }
}
