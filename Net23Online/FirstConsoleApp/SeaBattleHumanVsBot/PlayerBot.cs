namespace FirstConsoleApp.SeaBattleHumanVsBot;

public class PlayerBot : Player
{
    private List<Cell> hitCells = new List<Cell>();
    private List<Cell> untryedCells = new List<Cell>();
    
    public override bool MakeMove(Player enemy)
    {
        var random = new Random();

        var row = 0;
        var col = 0;
        var chosenCell = enemy.Field.Cells[0, 0];
        if (hitCells.Count == 0)
        {
            int index = random.Next(untryedCells.Count);
            row = untryedCells[index].Row;
            col = untryedCells[index].Col;
        }
        else if (hitCells.Count == 1)
        {
            var possibleCells = new List<Cell>();
            row = hitCells[0].Row;
            col = hitCells[0].Col;

            if (row + 1 < 10)
            {
                if (enemy.Field.Cells[row + 1, col].State == CellState.Empty)
                {
                    possibleCells.Add(enemy.Field.Cells[row + 1, col]);
                }
            }
            if (row - 1 >= 0)
            {
                if (enemy.Field.Cells[row - 1, col].State == CellState.Empty)
                {
                    possibleCells.Add(enemy.Field.Cells[row - 1, col]);
                }
            }
            if (col + 1 < 10)
            {
                if (enemy.Field.Cells[row, col + 1].State == CellState.Empty)
                {
                    possibleCells.Add(enemy.Field.Cells[row, col + 1]);
                }
            }
            if (col - 1 >= 0)
            {
                if (enemy.Field.Cells[row, col - 1].State == CellState.Empty)
                {
                    possibleCells.Add(enemy.Field.Cells[row, col - 1]);
                }
            }
            
            int indexOfCellToShoot = random.Next(possibleCells.Count);
            
            row = possibleCells[indexOfCellToShoot].Row;
            col = possibleCells[indexOfCellToShoot].Col;
        }
        else
        {
            var possibleCellsToShoot = new List<Cell>();
            
            if (hitCells[0].Row == hitCells[hitCells.Count - 1].Row)
            {
                //для того чтобы первый элемент находился выше последнего на поле)
                if (hitCells[0].Col > hitCells[hitCells.Count - 1].Col)
                {
                    hitCells.Reverse();
                }
                
                if (hitCells[0].Col - 1 >= 0)
                {
                    row = hitCells[0].Row;
                    col = hitCells[0].Col - 1;
                    if (enemy.Field.Cells[row, col].State == CellState.Empty)
                    {
                        possibleCellsToShoot.Add(enemy.Field.Cells[row, col]);
                    }
                }
                if (hitCells[hitCells.Count - 1].Col + 1 < 10)
                {
                    row = hitCells[0].Row;
                    col = hitCells[0].Col + 1;

                    if (enemy.Field.Cells[row, col].State == CellState.Empty)
                    {
                        possibleCellsToShoot.Add(enemy.Field.Cells[row, col]);
                    }
                }
            }

            if (hitCells[0].Col == hitCells[hitCells.Count - 1].Col)
            {
                //для того чтобы первый элемент находился левее последнего на поле)
                if (hitCells[0].Row > hitCells[hitCells.Count - 1].Row)
                {
                    hitCells.Reverse();
                }
                
                if (hitCells[0].Row - 1 >= 0)
                {
                    row = hitCells[0].Row;
                    col = hitCells[0].Col - 1;

                    if (enemy.Field.Cells[row, col].State == CellState.Empty)
                    {
                        possibleCellsToShoot.Add(enemy.Field.Cells[row, col]);
                    }
                }
                if (hitCells[hitCells.Count - 1].Row + 1 < 10)
                {
                    row = hitCells[0].Row;
                    col = hitCells[0].Col - 1;

                    if (enemy.Field.Cells[row, col].State == CellState.Empty)
                    {
                        possibleCellsToShoot.Add(enemy.Field.Cells[row, col]);
                    }
                }

            }

            int indexOfCellToShoot = random.Next(possibleCellsToShoot.Count);
            
            row = possibleCellsToShoot[indexOfCellToShoot].Row;
            col = possibleCellsToShoot[indexOfCellToShoot].Col;
        }

        chosenCell = enemy.Field.Cells[row, col];
        
        var shotState = enemy.Field.Shot(chosenCell, enemy.Field);
        
        untryedCells.Remove(chosenCell);

        if (shotState == ShotState.Miss)
        {
            return false;
        }
        if (shotState == ShotState.Damaged)
        {
            hitCells.Add(chosenCell);
            return true;
        }

        if (shotState == ShotState.Destroy)
        {
            hitCells.Clear();
            return true;
        }
        
        Console.WriteLine("Somethimg go wrong!"); //если ни одно из значений не присвоилось к shotState
        return false;
    }

    public override void PlaceShips()
    {
        ///рандом координаты
        /// рандом направление
        ///

        for (var row = 0; row < 10; row++)
        {
            for (var col = 0; col < 10; col++)
            {
                untryedCells.Add(Field.Cells[row, col]);
            }
        }
    }
}