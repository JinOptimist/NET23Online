namespace FirstConsoleApp.GameSudoku
{
    public class SudokuTransformer
    {
        private Random random = new Random();

        public void Transpose(Sudoku grid)
        {
            var sizeOfRowOrColumn = grid.GetSize();
            int[,] transposed = new int[sizeOfRowOrColumn, sizeOfRowOrColumn];
            for (int i = 0; i < sizeOfRowOrColumn; i++)
            {
                for (int j = 0; j < sizeOfRowOrColumn; j++)
                {
                    transposed[i, j] = grid.GetCell(j, i);
                }
            }
            for (int i = 0; i < sizeOfRowOrColumn; i++)
            {
                for (int j = 0; j < sizeOfRowOrColumn; j++)
                {
                    grid.SetCell(i, j, transposed[i, j]);
                }
            }
        }

        public void SwapRowsSmall(Sudoku grid)
        {
            var numberOfRowsAndColumnsInOneSqueare = (int)Math.Sqrt(grid.GetSize());
            var sizeOfRow = grid.GetSize();
            var areaOfGrid = random.Next(0, numberOfRowsAndColumnsInOneSqueare);
            var firstRandomLineInSqueare = random.Next(0, numberOfRowsAndColumnsInOneSqueare);
            var secondRandomlineOneInSqueare = random.Next(0, numberOfRowsAndColumnsInOneSqueare);
        
            while(firstRandomLineInSqueare == secondRandomlineOneInSqueare) 
            {
                secondRandomlineOneInSqueare = random.Next(0, numberOfRowsAndColumnsInOneSqueare);
            }

            var numberFirsttRowForSwapInGrid = areaOfGrid * numberOfRowsAndColumnsInOneSqueare + firstRandomLineInSqueare;
            var numberSecondRowForSwapInGrid = areaOfGrid * numberOfRowsAndColumnsInOneSqueare + secondRandomlineOneInSqueare;
            
            for(int k = 0; k < sizeOfRow; k++)
            {
                int temp = grid.GetCell(numberFirsttRowForSwapInGrid, k);
                grid.SetCell(numberFirsttRowForSwapInGrid, k, grid.GetCell(numberSecondRowForSwapInGrid, k));
                grid.SetCell(numberSecondRowForSwapInGrid, k, temp);
            }
        }
        public void SwapColumnsSmall(Sudoku grid)
        {
            Transpose(grid);
            SwapRowsSmall(grid);
            Transpose(grid);
        }
        public void SwapRowsArea(Sudoku grid)
        {
            var numberOfRowsAndColumnsInOneSqueare = (int)Math.Sqrt(grid.GetSize());
            var sizeOfRow = grid.GetSize();

            var firstRandomAreaInSqueare = random.Next(0, numberOfRowsAndColumnsInOneSqueare);
            var secondRandomAreaInSqueare = random.Next(0, numberOfRowsAndColumnsInOneSqueare);

            while (firstRandomAreaInSqueare == secondRandomAreaInSqueare)
            {
                secondRandomAreaInSqueare = random.Next(0, numberOfRowsAndColumnsInOneSqueare);
            }
                
            for (int i = 0; i < numberOfRowsAndColumnsInOneSqueare; i++)
            {
                var firstRandomAreaInGrid = firstRandomAreaInSqueare * numberOfRowsAndColumnsInOneSqueare + i;
                var secondRandomAreaInGrid = secondRandomAreaInSqueare * numberOfRowsAndColumnsInOneSqueare + i;

                for (int j = 0; j < sizeOfRow; j++)
                {
                    var temp = grid.GetCell(firstRandomAreaInGrid, j);
                    grid.SetCell(firstRandomAreaInGrid, j, grid.GetCell(secondRandomAreaInGrid, j));
                    grid.SetCell(secondRandomAreaInGrid, j, temp);
                }
            }
        }
        public void SwapColumnsArea(Sudoku grid)
        {
            Transpose(grid);
            SwapRowsArea(grid);
            Transpose(grid);
        }
    }
    
}
