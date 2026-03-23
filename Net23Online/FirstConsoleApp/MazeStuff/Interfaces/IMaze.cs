using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Cells.Interfaces;
using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Interfaces
{
    public interface IMaze
    {
        IBaseCell? this[int x, int y] { get; }

        IList<string> EventHistory { get; set; }
        int Height { get; set; }
        Hero Hero { get; set; }
        Monster Monster { get; set; }

        int Seed { get; set; }
        IList<IBaseCell> Surface { get; set; }
        int Width { get; set; }
    }
}