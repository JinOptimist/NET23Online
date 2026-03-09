
namespace FirstConsoleApp.GameSudoku
{
    public class GridOfSudoku
    {
        protected int _sizeOfRowsOrColumnsInOneSquare;
        protected int _sizeOfOneSquare;
        protected int[,] _tableOfSudoku;
        
        public GridOfSudoku()
        {
            _sizeOfRowsOrColumnsInOneSquare = 3;
            _sizeOfOneSquare = _sizeOfRowsOrColumnsInOneSquare * _sizeOfRowsOrColumnsInOneSquare;
            _tableOfSudoku = new int[_sizeOfOneSquare, _sizeOfOneSquare];
            this.FillValueInTable();
        }
        private GridOfSudoku FillValueInTable()
        {
            for (int i = 0; i < _sizeOfOneSquare; i++)
            {
                for (int j = 0; j < _sizeOfOneSquare; j++)
                {
                    this.SetCell(i, j, ((i * _sizeOfRowsOrColumnsInOneSquare + i / _sizeOfRowsOrColumnsInOneSquare + j) % (_sizeOfOneSquare) + 1));
                }
            }
            return this;
        }
        public int GetCell(int row, int column) 
        {
            return _tableOfSudoku[row, column];
        }
        public void SetCell(int row, int column, int value)
        {
           _tableOfSudoku[row, column] = value;
        }
        public int GetSize()
        {
            return _sizeOfOneSquare;
        }
        public virtual void Show()
        {
            Console.WriteLine("__________________________");
            Console.WriteLine(" ID  0 1 2 |3 4 5 |6 7 8 |");
            Console.WriteLine("__________________________");
            for (int i = 0; i < _sizeOfOneSquare; i++)
            {
                Console.Write($"|{i}|  ");
                for (int j = 0; j < _sizeOfOneSquare; j++) 
                {
                    Console.Write(_tableOfSudoku[i, j] + " ");
                    if (j == 2 || j == 5 || j == 8)
                    {
                        Console.Write("|");
                    }
                    
                }
                Console.WriteLine();
                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine("__________________________");
                }
                
            }
        }
        
    }
}
   
     

