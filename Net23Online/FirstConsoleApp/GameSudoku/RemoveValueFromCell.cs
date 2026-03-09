namespace FirstConsoleApp.GameSudoku
{
    internal class RemoveValueFromCell
    {
        Random Random = new Random();
        public void PrepareGridToUser(Sudoku grid, int amountOfValueToDelete)
        {
            for (int i = 0; i < 20; i++)
            {
                grid.SetCell(Random.Next(0, 9), Random.Next(0, 9), 0);
            }
        }


    }
}
