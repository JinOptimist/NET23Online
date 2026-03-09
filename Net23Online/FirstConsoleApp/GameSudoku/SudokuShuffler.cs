
namespace FirstConsoleApp.GameSudoku
{
    public class SudokuShuffler
    {
        private SudokuTransformer _transformer = new SudokuTransformer();
        private Random _random = new Random();
        public void Shuffle(Sudoku grid, int amt = 10)
        {
            var operations = new List<Action<Sudoku>>
            {
            _transformer.Transpose,
            _transformer.SwapRowsSmall,
            _transformer.SwapColumnsSmall,
            _transformer.SwapRowsArea,
            _transformer.SwapColumnsArea
            };
            for (int i = 0; i < amt; i++)
            {
                var idOperation = _random.Next(0, operations.Count);
                operations[idOperation](grid);
            }
        }
    }
}
