namespace FirstConsoleApp.GameSudoku
{
    public class BaseSudokuGenerator
    {
        public static GridOfSudoku GenerateBaseGrid(int n = 3)
        {
            GridOfSudoku grid = new GridOfSudoku();
            var sizeOfRowOrColumn = grid.GetSize();

            for (int i = 0; i < sizeOfRowOrColumn; i++)
            {
                for (int j = 0; j < sizeOfRowOrColumn; j++)
                {
                    grid.SetCell(i, j, ((i * n + i / n + j) % (sizeOfRowOrColumn) + 1));
                }
            }

            return grid;
        }
    }
}