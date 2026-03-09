namespace FirstConsoleApp.GameSudoku
{
    internal class GameSudoku
    {
        Sudoku _grid = new Sudoku();
        public GameSudoku() 
        {
        }
        public void PlayGameOfSudoku() 
        {
            var idRow = 0;
            var idColumn = 0;
            var value = 0;
            _grid.Show();
            do
            {
                
                idRow = GetIdAndNumberFromConsole("Write id Row", "It's wrong id, try again (from 0 to 8)", 0, 8);
                idColumn = GetIdAndNumberFromConsole("Write id Column", "It's wrong id, try again (from 0 to 8)", 0, 8);
                value = GetIdAndNumberFromConsole("Write value (from 1 to 9)", "it's Wrong value, try again (from 1 to 9)", 0, 9);
                if(CorrectOrNot(_grid, idRow, idColumn, value)) 
                {
                    _grid.SetCell(idRow, idColumn, value);
                    Console.Clear();
                    _grid.Show();
                }
            } while (!AnyEmpteCells(_grid));
            Console.Clear();
            Console.WriteLine("YOU WIN!");

        }
        protected bool CorrectOrNot(Sudoku grid, int idRow, int idColumn, int value)
        {
            var condition = true;
            if (grid.GetCell(idRow,idColumn) == 0) 
            {
                for (int i = 0; i < 8; i++) 
                {
                    if (grid.GetCell(idRow,i) == value) //rows
                    {
                        condition = false;
                        Console.WriteLine($"The value already exists in another intersected cell. ID = [{idRow},{i}]");
                        break;
                    }
                    else if(grid.GetCell(i, idColumn) == value) //columns
                    {
                        condition = false;
                        Console.WriteLine($"The value already exists in another intersected cell.ID = [{i},{idColumn}]");
                        break;
                    }

                }
            }


            return condition;
        }
        protected bool AnyEmpteCells(Sudoku grid)
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(grid.GetCell(i,j) == 0)
                    {
                        return false;
                    }
                }
            }
            return true; 
        }

        protected int GetIdAndNumberFromConsole(string messageForUser, string errorMessage, int minValue, int maxValue)
        {
            var isThisAnumberCorrect = false;
            var idOrValue = 0;
            do
            {
                Console.WriteLine(messageForUser);
                var guessStr = Console.ReadLine();

                isThisAnumberCorrect = int.TryParse(guessStr, out idOrValue);
                if (!isThisAnumberCorrect)
                {
                    Console.WriteLine(errorMessage);
                }
                else if( idOrValue > maxValue || minValue > idOrValue)
                {
                    Console.WriteLine(errorMessage);
                    isThisAnumberCorrect = false;
                }

            } while (!isThisAnumberCorrect);

            return idOrValue;
        }
    }
}
