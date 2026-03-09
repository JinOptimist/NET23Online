
namespace FirstConsoleApp.GameSudoku
{
    public class Sudoku:GridOfSudoku
    {
        private SudokuShuffler Shuffler = new SudokuShuffler();
        Random Random = new Random();

        public Sudoku() 
        {
            RemoveValuesInGridForStartGame(this, 20);
            Shuffler.Shuffle(this, 20);
        }

        private void RemoveValuesInGridForStartGame(Sudoku grid, int amountOfValueToDelete)
        {
            for (int i = 0; i < 20; i++)
            {
                grid.SetCell(Random.Next(0, 9), Random.Next(0, 9), 0);
            }
        }

    }
   
}
