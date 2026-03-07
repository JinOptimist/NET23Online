namespace FirstConsoleApp.SeaBattleHumanVsBot;

public class PlayerBot : Player
{
    private List<Cell> _hitCellsInEnemysField = new List<Cell>();
    private List<Cell> _untryedToMoveCells = new List<Cell>();
    private Random _random = new Random();

    private List<Cell> _availableCellsToPlace = new List<Cell>();

    public override bool MakeMove(Player enemy)
    {
        _untryedToMoveCells.RemoveAll(c => c.State != CellState.Empty);
        
        var row = 0;
        var col = 0;
        if (_hitCellsInEnemysField.Count == 0) //если подстреленных кораблей нет
        {
            int index = _random.Next(_untryedToMoveCells.Count);
            row = _untryedToMoveCells[index].Row;
            col = _untryedToMoveCells[index].Col;
        }
        else if (_hitCellsInEnemysField.Count == 1) //если подстрелена только одна клетка корабля
        {
            var possibleCells = new List<Cell>();
            row = _hitCellsInEnemysField[0].Row;
            col = _hitCellsInEnemysField[0].Col;

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
            
            int indexOfCellToShoot = _random.Next(possibleCells.Count);
            
            row = possibleCells[indexOfCellToShoot].Row;
            col = possibleCells[indexOfCellToShoot].Col;
        }
        else //если подстрелено 2 и больше
        {
            var possibleCellsToShoot = new List<Cell>();
            
            //подбит по горизонтали
            if (_hitCellsInEnemysField[0].Row == _hitCellsInEnemysField[_hitCellsInEnemysField.Count - 1].Row)
            {
                //для того чтобы первая клетка находилась выше последней на поле)
                if (_hitCellsInEnemysField[0].Col > _hitCellsInEnemysField[_hitCellsInEnemysField.Count - 1].Col)
                {
                    _hitCellsInEnemysField.Reverse();
                }
                
                row = _hitCellsInEnemysField[0].Row;
                var colFirst = _hitCellsInEnemysField[0].Col;
                var colLast = _hitCellsInEnemysField[_hitCellsInEnemysField.Count - 1].Col;
                
                if (colFirst - 1 >= 0)
                {
                    if (enemy.Field.Cells[row, colFirst - 1].State == CellState.Empty)
                    {
                        possibleCellsToShoot.Add(enemy.Field.Cells[row, colFirst - 1]);
                    }
                }
                if (colLast + 1 < 10)
                {
                    if (enemy.Field.Cells[row, colLast + 1].State == CellState.Empty)
                    {
                        possibleCellsToShoot.Add(enemy.Field.Cells[row, colLast + 1]);
                    }
                }
            }

            //подбит по вертикали
            if (_hitCellsInEnemysField[0].Col == _hitCellsInEnemysField[_hitCellsInEnemysField.Count - 1].Col)
            {
                //для того чтобы первая клетка находилась левее последней клетки на поле)
                if (_hitCellsInEnemysField[0].Row > _hitCellsInEnemysField[_hitCellsInEnemysField.Count - 1].Row)
                {
                    _hitCellsInEnemysField.Reverse();
                }
                
                col = _hitCellsInEnemysField[0].Col;
                var rowFirst = _hitCellsInEnemysField[0].Row;
                var rowLast = _hitCellsInEnemysField[_hitCellsInEnemysField.Count - 1].Row;

                if (rowFirst - 1 >= 0)
                {
                    if (enemy.Field.Cells[rowFirst - 1, col].State == CellState.Empty)
                    {
                        possibleCellsToShoot.Add(enemy.Field.Cells[rowFirst - 1, col]);
                    }
                }
                if (_hitCellsInEnemysField[_hitCellsInEnemysField.Count - 1].Row + 1 < 10)
                {
                    if (enemy.Field.Cells[rowLast + 1, col].State == CellState.Empty)
                    {
                        possibleCellsToShoot.Add(enemy.Field.Cells[rowLast + 1, col]);
                    }
                }

            }

            int indexOfCellToShoot = _random.Next(possibleCellsToShoot.Count);
            
            row = possibleCellsToShoot[indexOfCellToShoot].Row;
            col = possibleCellsToShoot[indexOfCellToShoot].Col;
        }

        var chosenCell = enemy.Field.Cells[row, col];
        
        var shotState = enemy.Field.Shot(chosenCell);
        
        if (shotState == ShotState.Miss)
        {
            return false;
        }
        if (shotState == ShotState.Damaged)
        {
            _hitCellsInEnemysField.Add(chosenCell);
            return true;
        }

        if (shotState == ShotState.Destroy)
        {
            _hitCellsInEnemysField.Clear();
            return true;
        }
        
        Console.WriteLine("Somethimg go wrong!"); //если ни одно из значений не присвоилось к shotState
        return false;
    }

    public override void PlaceShips()
    {
        FillCells(_availableCellsToPlace);
        
        //сначала создаем все корабли
        var shipSizes = new List<int>() {4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
        foreach (var size in shipSizes)
        {
            do
            {
                ///рандом координаты
                var row = 0;
                var col = 0;
                int index = _random.Next(_availableCellsToPlace.Count);
                row = _availableCellsToPlace[index].Row;
                col = _availableCellsToPlace[index].Col;
                
                //выбранная клетка для того, чтобы попробовать вставить в нее корабль
                //верхняя/левая палуба корабля

                bool isHorisontal = _random.Next(0, 2) == 1;

                if (!Field.CanPlaceShip(row, col, size, isHorisontal))
                {
                    continue;
                }

                var ship = new Ship();
                var cellsOfShip = new List<Cell>();
                
                for (var i = 0; i < size; i++)
                {
                    if (isHorisontal)
                    {
                        cellsOfShip.Add(Field.Cells[row, col + i]);
                        Field.Cells[row, col + i].Ship = ship;
                    }
                    else
                    {
                        cellsOfShip.Add(Field.Cells[row + i, col]);
                        Field.Cells[row + i, col].Ship = ship;
                    }
                }

                ship.Coordinates = cellsOfShip;
                Ships.Add(ship);
                foreach (var cell in cellsOfShip)
                {
                    cell.State = CellState.Ship;
                }
                
                _availableCellsToPlace.RemoveAll(c => cellsOfShip.Contains(c));
                foreach (var neighbor in ship.GetNeighboringCells(this.Field))
                {
                    _availableCellsToPlace.Remove(neighbor);
                }
                break;
                
            } while (true);
        }
        
        FillCells(_untryedToMoveCells);
    }

    public void FillCells(List<Cell> untryedCells)
    {
        for (var row = 0; row < 10; row++)
        {
            for (var col = 0; col < 10; col++)
            {
                untryedCells.Add(Field.Cells[row, col]);
            }
        }
    }
}