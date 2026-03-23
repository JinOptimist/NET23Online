using FirstConsoleApp.MazeStuff.Cells.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells.ConsoleInputReader;

public class ConsoleInputReader : IInputReader
{
    public ConsoleKey ReadKey()
    {
        return Console.ReadKey(true).Key;
    }
}