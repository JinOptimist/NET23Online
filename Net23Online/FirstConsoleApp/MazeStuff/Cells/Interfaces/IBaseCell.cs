using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells.Interfaces
{
    public interface IBaseCell
    {
        bool IsBonusCell { get; init; }
        IMaze Maze { get; set; }
        char Symbol { get; }
        int X { get; set; }
        int Y { get; set; }

        bool Interaction(IBaseCharacter character);
    }
}